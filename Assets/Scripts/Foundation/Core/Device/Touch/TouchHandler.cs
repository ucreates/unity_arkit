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
namespace Core.Device.Touch {
public class TouchHandler {
    public static TouchEntity Pop() {
        List<Vector3> positionList = new List<Vector3>();
        TouchPhase phase = TouchPhase.Canceled;
        if (RuntimePlatform.OSXEditor == Application.platform) {
            if (false != Input.GetMouseButtonDown(0)) {
                positionList.Add(Input.mousePosition);
                phase = TouchPhase.Began;
            } else if (false != Input.GetMouseButton(0)) {
                positionList.Add(Input.mousePosition);
                phase = TouchPhase.Moved;
            }
            if (false != Input.GetMouseButtonUp(0)) {
                positionList.Add(Input.mousePosition);
                phase = TouchPhase.Ended;
            }
        } else if (RuntimePlatform.IPhonePlayer == Application.platform || RuntimePlatform.Android == Application.platform) {
            bool recognizedTouchPhase = false;
            for (int i = 0; i < Input.touchCount; i++) {
                UnityEngine.Touch touch = Input.GetTouch(i);
                positionList.Add(touch.position);
                if (false == recognizedTouchPhase) {
                    phase = touch.phase;
                    recognizedTouchPhase = true;
                }
            }
        }
        TouchEntity entity = new TouchEntity();
        entity.touchPhase = phase;
        entity.touchPositionList = positionList;
        return entity;
    }
}
}
