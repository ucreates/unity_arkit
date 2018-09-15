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
public sealed class IconShowState : FiniteState<IconBehaviour> {
    private const float ROTATE_DEGREE = 360f * 10f;
    private const float ANIMATION_TIME = 5f;
    private const float VFX_SCALE = 500f;
    public override void Create() {
        this.owner.enableTouch = false;
        Collider[] colliders = this.owner.GetComponentsInChildren<Collider>(true);
        Renderer[] renderers = this.owner.GetComponentsInChildren<Renderer>(true);
        foreach (Collider collider in colliders) {
            collider.enabled = true;
        }
        foreach (Renderer renderer in renderers) {
            renderer.enabled = true;
            if (false != renderer.gameObject.name.ToLower().Equals("apple")) {
                Vector3 vfxpos = renderer.gameObject.transform.position;
                this.owner.vortexVfx.transform.position = vfxpos;
                this.owner.hitVfx.transform.position = vfxpos;
            }
        }
        this.timeLine.Restore();
        this.owner.vortexVfx.SetActive(true);
        return;
    }
    public override void Update() {
        if (IconShowState.ANIMATION_TIME < this.timeLine.currentTime) {
            this.owner.transform.localScale = new Vector3(IconBehaviour.SCALE_RATE_IOS, IconBehaviour.SCALE_RATE_IOS, IconBehaviour.SCALE_RATE_IOS);
            this.owner.transform.localRotation = Quaternion.Euler(Vector3.zero);
            this.owner.enableTouch = true;
            this.owner.vortexVfx.SetActive(false);
            return;
        }
        float scale = Quadratic.EaseOut(this.timeLine.currentTime, 0f, IconBehaviour.SCALE_RATE_IOS, IconShowState.ANIMATION_TIME);
        float vfxScale = Quadratic.EaseOut(this.timeLine.currentTime, 0f, IconShowState.VFX_SCALE, IconShowState.ANIMATION_TIME);
        float rotate = IconShowState.ROTATE_DEGREE - Quadratic.EaseOut(this.timeLine.currentTime, 0f, IconShowState.ROTATE_DEGREE, IconShowState.ANIMATION_TIME);
        this.owner.transform.localScale = new Vector3(scale, IconBehaviour.SCALE_RATE_IOS, scale);
        this.owner.transform.localRotation = Quaternion.Euler(new Vector3(0, -1f * rotate, 0));
        this.owner.vortexVfx.transform.localScale = new Vector3(vfxScale, vfxScale, vfxScale);
        this.timeLine.Next();
        return;
    }
}
}
