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
using System.IO;
using System.Collections;
using Core.IO.Format.Asset;
namespace Core.IO.Parser.Asset {
public class MtlAssetIlluminationParser : MtlAssetBaseParser<MtlAssetIlluminationFormat> {
    public override MtlAssetIlluminationFormat Read(string header, string body) {
        MtlAssetIlluminationFormat format = new MtlAssetIlluminationFormat();
        format.header = header;
        format.illuminationType = Convert.ToInt32(body);
        return format;
    }
}
}
