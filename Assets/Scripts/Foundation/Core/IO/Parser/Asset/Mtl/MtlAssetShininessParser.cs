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
public class MtlAssetShininessParser : MtlAssetBaseParser<MtlAssetShininessFormat> {
    public override MtlAssetShininessFormat Read(string header, string body) {
        MtlAssetShininessFormat format = new MtlAssetShininessFormat();
        format.header = header;
        format.shininess = Convert.ToSingle(body);
        return format;
    }
}
}
