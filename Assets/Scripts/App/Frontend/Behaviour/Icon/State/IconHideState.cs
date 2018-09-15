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
using Service;
using Frontend.Component.Vfx;
using Frontend.Component.Vfx.Sprine;
using Frontend.Component.Vfx.Easing;
using Frontend.Component.State;
namespace Frontend.Behaviour.Asset.State {
public sealed class IconHideState : FiniteState<IconBehaviour> {
    public override void Create() {
        Collider[] colliders = this.owner.GetComponentsInChildren<Collider>(true);
        Renderer[] renderers = this.owner.GetComponentsInChildren<Renderer>(true);
        foreach (Collider collider in colliders) {
            collider.enabled = false;
        }
        foreach (Renderer renderer in renderers) {
            renderer.enabled = false;
        }
        this.owner.vortexVfx.SetActive(false);
        this.owner.hitVfx.SetActive(false);
        return;
    }
}
}
