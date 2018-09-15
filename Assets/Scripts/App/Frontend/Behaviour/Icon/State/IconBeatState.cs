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
public sealed class IconBeatState : FiniteState<IconBehaviour> {
    private Bouncy bouncy {
        get;
        set;
    }
    public override void Create() {
        this.bouncy = new Bouncy(0.25f, 0.025f);
        return;
    }
    public override void Update() {
        if (0.05 > this.bouncy.originVelocity) {
            this.owner.enableTouch = true;
            this.owner.hitVfx.SetActive(false);
            return;
        }
        float rate = this.bouncy.Update();
        if (rate <= 0f) {
            this.bouncy.Restore();
        }
        float scale = IconBehaviour.SCALE_RATE_IOS + rate;
        this.owner.transform.localScale = new Vector3(scale, scale, scale);
        return;
    }
}
}
