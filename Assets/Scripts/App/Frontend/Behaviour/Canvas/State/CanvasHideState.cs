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
using UnityEngine.UI;
using System.Collections;
using Frontend.Component.Vfx;
using Frontend.Component.Vfx.Sprine;
using Frontend.Component.Vfx.Easing;
using Frontend.Component.State;
namespace Frontend.Behaviour.Canvas.State {
public sealed class CanvasHideState : FiniteState<CanvasBehaviour> {
    public override void Create() {
        UnityEngine.Canvas canvas = Core.Object.Finder.Find<UnityEngine.Canvas>("Canvas");
        canvas.enabled = false;
        return;
    }
}
}
