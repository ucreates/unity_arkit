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
using System;
using System.Collections;
namespace Core.IO {
public sealed class Path {
    public static string Combine(params string[] path) {
        string ret = string.Empty;
        for (int i = 0; i < path.Length; i++) {
            ret = System.IO.Path.Combine(ret, path[i]);
        }
        return ret;
    }
}
}
