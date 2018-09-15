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
public class ObjAssetTextureFormat : ObjAssetBaseFormat {
    public Vector2 uv {
        get;
        set;
    }
    public float w {
        get;
        set;
    }
    public ObjAssetTextureFormat() {
        this.uv = Vector2.zero;
        this.w = 0.0f;
    }
}
}
