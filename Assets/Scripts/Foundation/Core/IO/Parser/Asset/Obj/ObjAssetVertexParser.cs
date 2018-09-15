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
public class ObjAssetVertexParser : ObjAssetBaseParser<ObjAssetVertexFormat> {
    public override ObjAssetVertexFormat Read(string header, string body) {
        Regex pattern = new Regex(@"\s+");
        string[] elements = pattern.Split(body);
        if (0 == elements.Length) {
            return null;
        }
        float vx = Convert.ToSingle(elements[0]);
        float vy = Convert.ToSingle(elements[1]);
        float vz = Convert.ToSingle(elements[2]);
        Vector3 vertex = new Vector3(vx, vy, vz);
        ObjAssetVertexFormat format = new ObjAssetVertexFormat();
        format.header = header;
        format.vertex = vertex;
        if (4 == elements.Length) {
            format.w = Convert.ToSingle(elements[3]);
        }
        return format;
    }
}
}
