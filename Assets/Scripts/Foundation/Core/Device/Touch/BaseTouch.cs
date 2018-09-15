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
using System.Collections.Generic;
using Frontend.Behaviour.Base;
namespace Core.Device.Touch {
public abstract class BaseTouch {
    public BaseBehaviour owner {
        get;
        set;
    }
    public bool firstTouch {
        get;
        set;
    }
    public bool enable {
        get;
        set;
    }
    protected Vector3 beganPoint {
        get;
        set;
    }
    protected Vector3 endPoint {
        get;
        set;
    }
    protected Vector3 previousTouchPoint {
        get;
        set;
    }
    protected List<Vector3> movePointList {
        get;
        set;
    }
    public BaseTouch() {
        this.firstTouch = true;
        this.enable = true;
        this.movePointList = new List<Vector3>();
    }
    public virtual void OnBegan(Vector3 touchPoint) {
    }
    public virtual void OnMove(Vector3 touchPoint) {
    }
    public virtual void OnEnd(Vector3 touchPoint) {
    }
    public virtual void OnExecute(Vector3 touchPoint) {
    }
}
}
