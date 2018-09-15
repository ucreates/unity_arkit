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
public class ObjAssetTextureParser : ObjAssetBaseParser<ObjAssetTextureFormat> {
    public override ObjAssetTextureFormat Read(string header, string body) {
        Regex pattern = new Regex(@"\s+");
        string[] elements = pattern.Split(body);
        if (0 == elements.Length) {
            return null;
        }
        ObjAssetTextureFormat format = new ObjAssetTextureFormat();
        format.header = header;
        float u = Convert.ToSingle(elements[0]);
        float v = Convert.ToSingle(elements[1]);
        format.uv = new Vector2(u, v);
        if (3 == elements.Length) {
            format.w = Convert.ToSingle(elements[2]);
        }
        return format;
    }
}
}
