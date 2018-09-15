//======================================================================
// Project Name    : unity_foundation
//
// Copyright © 2016 U-CREATES. All rights reserved.
//
// This source code is the property of U-CREATES.
// If such findings are accepted at any time.
// We hope the tips and helpful in developing.
//======================================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Frontend.Component.Asset {
public abstract class BaseAsset {
    public virtual string type {
        get {
            return string.Empty;
        }
    }
    public virtual List<GameObject> Build(string path) {
        return null;
    }
    public virtual IEnumerator AsyncBuild(string path) {
        return null;
    }
}
}
