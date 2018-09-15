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
public sealed class CanvasShowState : FiniteState<CanvasBehaviour> {
    private Text text {
        get;
        set;
    }
    public override void Create() {
        UnityEngine.Canvas canvas = Core.Object.Finder.Find<UnityEngine.Canvas>("Canvas");
        this.text = Core.Object.Finder.Find<Text>("LoadingText");
        canvas.enabled = true;
        this.timeLine.Restore();
        return;
    }
    public override void Update() {
        Color color = this.text.color;
        color.a = Flash.Update(this.timeLine.currentTime);
        this.text.color = color;
        this.timeLine.Next();
        return;
    }
}
}
