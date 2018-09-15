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
using Core.IO.Format.Asset;
namespace Core.IO.Parser.Asset {
public class MtlAssetAmbientTextureMapParser : MtlAssetBaseParser<MtlAssetAmbientTextureMapFormat> {
    public override MtlAssetAmbientTextureMapFormat Read(string header, string body) {
        MtlAssetAmbientTextureMapFormat format = new MtlAssetAmbientTextureMapFormat();
        format.header = header;
        format.name = body;
        return format;
    }
}
}
