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
using System.Collections.Generic;
using Frontend.Notify;
using Frontend.Component.State;
using Frontend.Component.Property;
using Frontend.Behaviour.Canvas.State;
using Core.Entity;
public class CanvasBehaviour : BaseBehaviour, IStateMachine<CanvasBehaviour>, INotify {
    public FiniteStateMachine<CanvasBehaviour> stateMachine {
        get;
        set;
    }
    // Use this for initialization
    void Start() {
        this.property = new BaseProperty(this);
        this.stateMachine = new FiniteStateMachine<CanvasBehaviour>(this);
        this.stateMachine.Add("show", new CanvasShowState());
        this.stateMachine.Add("hide", new CanvasHideState());
        this.stateMachine.Change("show");
        this.stateMachine.Play();
        Notifier notifier = Notifier.GetInstance();
        notifier.Add(this, this.property);
        return;
    }
    // Update is called once per frame
    void Update() {
        this.stateMachine.Update();
    }
    public void OnNotify(NotifyMessage notifyMessage, Parameter parameter = null) {
        if (NotifyMessage.OnLoadingComplete == notifyMessage) {
            this.stateMachine.Change("hide");
            this.stateMachine.Play();
        }
    }
}
