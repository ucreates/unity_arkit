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
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Core.IO.Stream.Asset;
using Core.IO.Format.Asset;
namespace Frontend.Component.Asset.Render {
public class ObjAsset : BaseRenderAsset {
    private const int MAX_UNITY_TRIANGLES_COUNT = 64998;
    private Dictionary<string, ObjAssetUseMaterialFormat> usemtlDictionary {
        get;
        set;
    }
    public bool hasMaterial {
        get;
        private set;
    }
    public string mtlAssetName {
        get;
        private set;
    }
    public List<GameObject> objList {
        get;
        private set;
    }
    public override List<GameObject> Build(string path) {
        ObjAssetStream stream = new ObjAssetStream();
        ObjAssetFormat format = stream.Read(path);
        this.hasMaterial = (0 < format.mtllibList.Count);
        if (false != this.hasMaterial) {
            this.mtlAssetName = format.mtllibList[0].name;
        }
        this.usemtlDictionary = format.usemtlDictionary;
        ObjAssetMeshBuilder builder = new ObjAssetMeshBuilder();
        builder.SetFormat(format);
        List<GameObject> objGameObjectList = new List<GameObject>();
        foreach (ObjAssetObjectFormat oformat in format.oList) {
            if (false == format.gDictionary.ContainsKey(oformat.name)) {
                continue;
            }
            GameObject objGameObject = new GameObject();
            objGameObject.name = oformat.name;
            List<ObjAssetGroupFormat> glist = format.gDictionary[oformat.name];
            foreach (ObjAssetGroupFormat gformat in glist) {
                string groupPath = Path.Combine(oformat.name, gformat.name);
                List<Mesh> meshList = builder.SetGroupPath(groupPath).Build();
                if (0 == meshList.Count) {
                    continue;
                }
                for (int meshCount = 0; meshCount < meshList.Count; meshCount++) {
                    GameObject groupGameObject = new GameObject();
                    groupGameObject.name = gformat.name;
                    groupGameObject.transform.position = objGameObject.transform.position;
                    groupGameObject.transform.parent = objGameObject.transform;
                    groupGameObject.AddComponent<MeshRenderer>();
                    MeshFilter meshFilter = groupGameObject.AddComponent<MeshFilter>();
                    meshFilter.mesh = meshList[meshCount];
                }
            }
            objGameObjectList.Add(objGameObject);
        }
        return objGameObjectList;
    }
    public override IEnumerator AsyncBuild(string path) {
        this.objList = null;
        ObjAssetStream stream = new ObjAssetStream();
        stream.AsyncRead(path);
        while (false == stream.asyncReadComplete) {
            yield return null;
        }
        ObjAssetFormat format = stream.data;
        this.hasMaterial = (0 < format.mtllibList.Count);
        if (false != this.hasMaterial) {
            this.mtlAssetName = format.mtllibList[0].name;
        }
        this.usemtlDictionary = format.usemtlDictionary;
        ObjAssetMeshBuilder builder = new ObjAssetMeshBuilder();
        builder.SetFormat(format);
        List<GameObject> objGameObjectList = new List<GameObject>();
        foreach (ObjAssetObjectFormat oformat in format.oList) {
            if (false == format.gDictionary.ContainsKey(oformat.name)) {
                continue;
            }
            GameObject objGameObject = new GameObject();
            objGameObject.name = oformat.name;
            List<ObjAssetGroupFormat> glist = format.gDictionary[oformat.name];
            foreach (ObjAssetGroupFormat gformat in glist) {
                string groupPath = Path.Combine(oformat.name, gformat.name);
                List<Mesh> meshList = builder.SetGroupPath(groupPath).Build();
                if (0 == meshList.Count) {
                    continue;
                }
                for (int meshCount = 0; meshCount < meshList.Count; meshCount++) {
                    GameObject groupGameObject = new GameObject();
                    groupGameObject.name = gformat.name;
                    groupGameObject.transform.position = objGameObject.transform.position;
                    groupGameObject.transform.parent = objGameObject.transform;
                    groupGameObject.AddComponent<MeshRenderer>();
                    MeshFilter meshFilter = groupGameObject.AddComponent<MeshFilter>();
                    meshFilter.mesh = meshList[meshCount];
                }
            }
            objGameObjectList.Add(objGameObject);
            yield return null;
        }
        this.objList = objGameObjectList;
        yield return null;
    }
    public string GetMtlAssetName(string groupPath) {
        if (false == this.usemtlDictionary.ContainsKey(groupPath)) {
            return string.Empty;
        }
        return this.usemtlDictionary[groupPath].name;
    }
}
}
