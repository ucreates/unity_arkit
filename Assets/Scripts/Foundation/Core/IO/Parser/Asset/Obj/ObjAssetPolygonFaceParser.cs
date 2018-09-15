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
using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;
using Core.IO.Format.Asset;
namespace Core.IO.Parser.Asset {
public class ObjAssetPolygonFaceParser: ObjAssetBaseParser<ObjAssetPolygonFaceFormat> {
    public override ObjAssetPolygonFaceFormat Read(string header, string body) {
        Regex pattern = new Regex(@"\s+");
        string[] elements = pattern.Split(body);
        ObjAssetPolygonFaceFormat format = new ObjAssetPolygonFaceFormat();
        format.header = header;
        ObjAssetPolygonFaceFormat.Index[] indicies = new ObjAssetPolygonFaceFormat.Index[elements.Length];
        for (int i = 0; i < elements.Length; i++) {
            string element = elements[i];
            string[] faces = element.Split('/');
            ObjAssetPolygonFaceFormat.Index index = new ObjAssetPolygonFaceFormat.Index();
            index.vertexIndex = Convert.ToInt32(faces[0]) - 1;
            if (1 < faces.Length) {
                index.uvIndex = Convert.ToInt32(faces[1]) - 1;
            }
            if (2 < faces.Length) {
                index.normalVectorIndex = Convert.ToInt32(faces[2]) - 1;
            }
            indicies[i] = index;
        }
        if (3 == indicies.Length) {
            format.indexList.Add(indicies[0]);
            format.indexList.Add(indicies[1]);
            format.indexList.Add(indicies[2]);
        } else if (4 == indicies.Length) {
            format.indexList.Add(indicies[0]);
            format.indexList.Add(indicies[1]);
            format.indexList.Add(indicies[3]);
            format.indexList.Add(indicies[3]);
            format.indexList.Add(indicies[1]);
            format.indexList.Add(indicies[2]);
        }
        return format;
    }
}
}
