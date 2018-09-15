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
public sealed class Bouncy {
    public const float GRAVITY = 0.98f;
    public const float E = 0.5f;
    public float gravity {
        get;
        private set;
    }
    public float velocity {
        get;
        set;
    }
    public float originVelocity {
        get;
        set;
    }
    public Bouncy() : this(0f, 1f) {}
    public Bouncy(float velocity, float rate) {
        this.velocity = velocity;
        this.originVelocity = velocity;
        this.gravity = Bouncy.GRAVITY * rate;
        return;
    }
    public float Update() {
        this.velocity -= this.gravity;
        return this.velocity;
    }
    public void Restore() {
        this.originVelocity *= Bouncy.E;
        this.velocity = this.originVelocity;
        return;
    }
}
}
