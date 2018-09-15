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
namespace Frontend.Component.Vfx.Sprine {
public sealed class Bezier {
    public static Vector3 Create(float currentTime, float totalTime, Vector3 start, Vector3 control, Vector3 end) {
        float t = currentTime / totalTime;
        if (t > 1.0f) {
            t = 1.0f;
        }
        float tp = 1.0f - t;
        if (tp < 0.0f) {
            tp = 0.0f;
        }
        float x = t * t * end.x + 2 * t * tp * control.x + tp * tp * start.x;
        float y = t * t * end.y + 2 * t * tp * control.y + tp * tp * start.y;
        float z = t * t * end.z + 2 * t * tp * control.z + tp * tp * start.z;
        return new Vector3(x, y, z);
    }
    public static Vector3 Create(float currentTime, float totalTime, Vector3 start, Vector3 control1, Vector3 control2, Vector3 end) {
        float t = currentTime / totalTime;
        if (t > 1.0f) {
            t = 1.0f;
        }
        float tp = 1.0f - t;
        if (tp < 0.0f) {
            tp = 0.0f;
        }
        float x = t * t * t * end.x + 3 * t * t * tp * control2.x + 3 * t * tp * tp * control1.x + tp * tp * tp * start.x;
        float y = t * t * t * end.y + 3 * t * t * tp * control2.y + 3 * t * tp * tp * control1.y + tp * tp * tp * start.y;
        float z = t * t * t * end.z + 3 * t * t * tp * control2.z + 3 * t * tp * tp * control1.z + tp * tp * tp * start.z;
        return new Vector3(x, y, z);
    }
}
}
