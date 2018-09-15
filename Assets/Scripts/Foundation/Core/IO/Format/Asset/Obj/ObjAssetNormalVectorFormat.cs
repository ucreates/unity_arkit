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
using System.Collections;
namespace Core.IO.Format.Asset {
public class ObjAssetNormalVectorFormat : ObjAssetBaseFormat {
    public Vector3 normal {
        get;
        set;
    }
    public ObjAssetNormalVectorFormat() {
        this.normal = Vector3.zero;
    }
}
}
