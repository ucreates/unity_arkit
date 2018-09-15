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
using System.Collections;
using Frontend.Component.Vfx;
using Frontend.Component.Vfx.Sprine;
using Frontend.Component.Vfx.Easing;
using Frontend.Component.State;
namespace Frontend.Behaviour.Asset.State {
public sealed class IconJumpState : FiniteState<IconBehaviour> {
    private Parabora parabora {
        get;
        set;
    }
    private bool first {
        get;
        set;
    }
    public override void Create() {
        this.parabora = new Parabora();
        this.parabora.velocity = 1f;
        this.parabora.mass = 1.5f;
        this.parabora.radian = 90f * Mathf.Deg2Rad;
        this.timeLine.Restore();
        this.timeLine.rate = 0.1f;
        this.first = true;
        return;
    }
    public override void Update() {
        Vector3 npos = this.parabora.Create(this.timeLine.currentFrame);
        foreach (Transform transform in this.owner.transform) {
            if (0f > npos.y) {
                transform.localPosition = Vector3.zero;
                this.owner.enableTouch = true;
                this.owner.hitVfx.SetActive(false);
            } else {
                transform.localPosition = npos;
            }
        }
        this.timeLine.Next();
        return;
    }
}
}
