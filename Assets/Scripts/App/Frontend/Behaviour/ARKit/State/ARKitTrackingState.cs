//======================================================================
// Project Name    : ar
//
// Copyright © 2017 U-CREATES. All rights reserved.
//
// This source code is the property of U-CREATES.
// If such findings are accepted at any time.
// We hope the tips and helpful in developing.
//======================================================================
using UnityEngine;
using UnityEngine.XR.iOS;
using System.Collections.Generic;
using Frontend.Notify;
using Frontend.Component.State;
using Core.Entity;
using Core.Device.Touch;
namespace Frontend.Behaviour.State {
public sealed class ARKitTrackingState : FiniteState<ARKitBehaviour> {
    public override void Update() {
        TouchEntity entity = TouchHandler.Pop();
        if (0 == entity.touchPositionList.Count || TouchPhase.Began != entity.touchPhase) {
            return;
        }
        Vector3 touchPosition = entity.touchPositionList[0];
        Vector3 viewportPoint = Camera.main.ScreenToViewportPoint(touchPosition);
        ARPoint point = new ARPoint();
        point.x = viewportPoint.x;
        point.y = viewportPoint.y;
        UnityARSessionNativeInterface nativeInterface = UnityARSessionNativeInterface.GetARSessionNativeInterface();
        List<ARHitTestResult> hitResultList = nativeInterface.HitTest(point, ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent);
        if (0 == hitResultList.Count) {
            return;
        } else {
            Notifier notifier = Notifier.GetInstance();
            notifier.Notify(NotifyMessage.OnRaycastHit);
        }
        return;
    }
}
}
