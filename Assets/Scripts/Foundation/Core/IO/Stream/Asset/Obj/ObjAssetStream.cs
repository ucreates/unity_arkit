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
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using Frontend.Component.Asset.Render;
using Core.IO.Parser.Asset;
using Core.IO.Format.Asset;
namespace Core.IO.Stream.Asset {
public class ObjAssetStream : AssetBaseStream<ObjAssetFormat> {
    public override ObjAssetFormat Read(string assetPath) {
        string objAllData = System.IO.File.ReadAllText(assetPath);
        string[] objDatas = objAllData.Split('\n');
        ObjAssetFormat objAssetFormat = new ObjAssetFormat();
        objAssetFormat.Create();
        foreach (string objData in objDatas) {
            if (0 == objData.Length) {
                continue;
            }
            string trimedObjData = objData.Trim();
            int firstWhiteSpaceIndex = trimedObjData.IndexOf(" ", 0);
            if (-1 == firstWhiteSpaceIndex) {
                continue;
            }
            string header = trimedObjData.Substring(0, firstWhiteSpaceIndex).Trim();
            string body = trimedObjData.Substring(firstWhiteSpaceIndex, trimedObjData.Length - firstWhiteSpaceIndex).Trim();
            switch (header) {
            case ObjAssetBaseFormat.COMMENT:
                break;
            case ObjAssetBaseFormat.F:
                ObjAssetBaseParser<ObjAssetPolygonFaceFormat> fStream = new ObjAssetPolygonFaceParser();
                ObjAssetPolygonFaceFormat fformat = fStream.Read(header, body);
                objAssetFormat.AddPolygonFace(fformat);
                break;
            case ObjAssetBaseFormat.G:
                ObjAssetBaseParser<ObjAssetGroupFormat> gstream = new ObjAssetGroupParser();
                ObjAssetGroupFormat gformat = gstream.Read(header, body);
                objAssetFormat.AddGroup(gformat);
                break;
            case ObjAssetBaseFormat.MTLLIB:
                ObjAssetBaseParser<ObjAssetMaterialFormat> mtlibstream = new ObjAssetMaterialParser();
                ObjAssetMaterialFormat mtlibFormat = mtlibstream.Read(header, body);
                objAssetFormat.mtllibList.Add(mtlibFormat);
                break;
            case ObjAssetBaseFormat.O:
                ObjAssetBaseParser<ObjAssetObjectFormat> ostream = new ObjAssetObjectParser();
                ObjAssetObjectFormat oformat = ostream.Read(header, body);
                objAssetFormat.AddObject(oformat);
                break;
            case ObjAssetBaseFormat.USEMTL:
                ObjAssetBaseParser<ObjAssetUseMaterialFormat> usemtlstream = new ObjAssetUseMaterialParser();
                ObjAssetUseMaterialFormat usemtlformat = usemtlstream.Read(header, body);
                objAssetFormat.AddUseMaterial(usemtlformat);
                break;
            case ObjAssetBaseFormat.V:
                ObjAssetBaseParser<ObjAssetVertexFormat> vstream = new ObjAssetVertexParser();
                ObjAssetVertexFormat vformat = vstream.Read(header, body);
                objAssetFormat.vList.Add(vformat);
                break;
            case ObjAssetBaseFormat.VT:
                ObjAssetBaseParser<ObjAssetTextureFormat> vtstream = new ObjAssetTextureParser();
                ObjAssetTextureFormat vtformat = vtstream.Read(header, body);
                objAssetFormat.vtList.Add(vtformat);
                break;
            case ObjAssetBaseFormat.VN:
                ObjAssetBaseParser<ObjAssetNormalVectorFormat> vnstream = new ObjAssetNormalVectorParser();
                ObjAssetNormalVectorFormat vnformat = vnstream.Read(header, body);
                objAssetFormat.vnList.Add(vnformat);
                break;
            default:
                string log = string.Format("unknown format.header::{0},body{1}", header, body);
                Debug.LogWarning(log);
                break;
            }
        }
        return objAssetFormat;
    }
}
}
