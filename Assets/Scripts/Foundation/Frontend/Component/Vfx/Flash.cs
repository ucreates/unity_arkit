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
namespace Frontend.Component.Vfx {
public sealed class Flash {
    public static float Update(float time) {
        return Flash.Update(time, 1.0f, 1.0f);
    }
    public static float Update(float time, float maxRate) {
        return Flash.Update(time, 1.0f, maxRate);
    }
    public static float Update(float time, float times, float maxRate) {
        float sin = Mathf.Sin(time * times) * maxRate;
        return Mathf.Abs(sin);
    }
}
}
