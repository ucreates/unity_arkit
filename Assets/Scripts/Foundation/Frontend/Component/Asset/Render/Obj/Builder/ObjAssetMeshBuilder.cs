//======================================================================
// Project Name    : unity_foundation
//
// Copyright © 2017 U-CREATES. All rights reserved.
//
// This source code is the property of U-CREATES.
// If such findings are accepted at any time.
// We hope the tips and helpful in developing.
//======================================================================
using UnityEngine;
using System.Collections.Generic;
using Core.IO.Stream.Asset;
using Core.IO.Format.Asset;
namespace Frontend.Component.Asset.Render {
public class ObjAssetMeshBuilder {
    private const int MAX_UNITY_TRIANGLES_COUNT = 64998;
    private ObjAssetFormat format {
        get;
        set;
    }
    private string groupPath {
        get;
        set;
    }
    public ObjAssetMeshBuilder SetGroupPath(string groupPath) {
        this.groupPath = groupPath;
        return this;
    }
    public ObjAssetMeshBuilder SetFormat(ObjAssetFormat format) {
        this.format = format;
        return this;
    }
    public List<Mesh> Build() {
        List<Mesh> meshList = new List<Mesh>();
        int polygonFaceCount = format.GetPolygonFaceCount(this.groupPath);
        if (0 == polygonFaceCount) {
            return meshList;
        }
        int quotient = polygonFaceCount / ObjAssetMeshBuilder.MAX_UNITY_TRIANGLES_COUNT;
        int surplus = polygonFaceCount % ObjAssetMeshBuilder.MAX_UNITY_TRIANGLES_COUNT;
        MeshEntity entity = new MeshEntity();
        if (0 == quotient) {
            Vector3[] verticies = new Vector3[polygonFaceCount];
            Vector2[] uvs = new Vector2[polygonFaceCount];
            Vector3[] normalVectors = new Vector3[polygonFaceCount];
            int[] triangles = new int[polygonFaceCount];
            entity.verticiesList.Add(verticies);
            entity.uvsList.Add(uvs);
            entity.normalVectorsList.Add(normalVectors);
            entity.trianglesList.Add(triangles);
            entity.totalMeshCount++;
        } else {
            int lastMeshInfoIdx = quotient + 1;
            for (int meshInfoIdx = 0; meshInfoIdx < lastMeshInfoIdx; meshInfoIdx++) {
                Vector3[] verticies = null;
                Vector2[] uvs = null;
                Vector3[] normalVectors = null;
                int[] triangles = null;
                if (meshInfoIdx == quotient) {
                    verticies = new Vector3[surplus];
                    uvs = new Vector2[surplus];
                    normalVectors = new Vector3[surplus];
                    triangles = new int[surplus];
                } else {
                    verticies = new Vector3[ObjAssetMeshBuilder.MAX_UNITY_TRIANGLES_COUNT];
                    uvs = new Vector2[ObjAssetMeshBuilder.MAX_UNITY_TRIANGLES_COUNT];
                    normalVectors = new Vector3[ObjAssetMeshBuilder.MAX_UNITY_TRIANGLES_COUNT];
                    triangles = new int[ObjAssetMeshBuilder.MAX_UNITY_TRIANGLES_COUNT];
                }
                entity.verticiesList.Add(verticies);
                entity.uvsList.Add(uvs);
                entity.normalVectorsList.Add(normalVectors);
                entity.trianglesList.Add(triangles);
                entity.totalMeshCount++;
            }
        }
        int polygonFaceIndex = 0;
        int triangleIndex = 0;
        int entityIndex = 0;
        List<ObjAssetPolygonFaceFormat> flist = format.fDictionary[groupPath];
        for (int fidx = 0; fidx < flist.Count; fidx++) {
            ObjAssetPolygonFaceFormat fformat = flist[fidx];
            //ポリゴン面情報の頂点インデックス、UVインデックス、法線インデックスと頂点、UV、法線情報を用いて、Objのポリゴン面情報を生成する。
            for (int iidx = 0; iidx < fformat.indexList.Count; iidx++) {
                if (polygonFaceIndex == ObjAssetMeshBuilder.MAX_UNITY_TRIANGLES_COUNT) {
                    polygonFaceIndex = 0;
                    triangleIndex = 0;
                    entityIndex++;
                }
                ObjAssetPolygonFaceFormat.Index fformatIndex = fformat.indexList[iidx];
                if (0 < format.vList.Count) {
                    ObjAssetVertexFormat vformat = format.vList[fformatIndex.vertexIndex];
                    entity.verticiesList[entityIndex][polygonFaceIndex] = vformat.vertex;
                }
                if (0 < format.vtList.Count) {
                    ObjAssetTextureFormat vtformat = format.vtList[fformatIndex.uvIndex];
                    entity.uvsList[entityIndex][polygonFaceIndex] = vtformat.uv;
                }
                if (0 < format.vnList.Count) {
                    ObjAssetNormalVectorFormat vnformat = format.vnList[fformatIndex.normalVectorIndex];
                    entity.normalVectorsList[entityIndex][polygonFaceIndex] = vnformat.normal;
                }
                entity.trianglesList[entityIndex][polygonFaceIndex] = triangleIndex;
                triangleIndex++;
                polygonFaceIndex++;
            }
        }
        for (int meshCount = 0; meshCount < entity.totalMeshCount; meshCount++) {
            Vector3[] verticies = entity.verticiesList[meshCount];
            Vector2[] uvs = entity.uvsList[meshCount];
            Vector3[] normalVectors = entity.normalVectorsList[meshCount];
            int[] triangles = entity.trianglesList[meshCount];
            //メッシュ作成
            Mesh mesh = new Mesh();
            mesh.vertices = verticies;
            mesh.uv = uvs;
            mesh.normals = normalVectors;
            mesh.subMeshCount = 1;
            mesh.triangles = triangles;
            mesh.RecalculateBounds();
            meshList.Add(mesh);
        }
        return meshList;
    }
}
}
