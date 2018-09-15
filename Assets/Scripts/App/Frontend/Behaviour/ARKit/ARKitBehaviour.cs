//======================================================================
// Project Name    : unity_arkit
//
// Copyright © 2018 U-CREATES. All rights reserved.
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
using Frontend.Behaviour.State;
//using Core.Device.Touch;
public class ARKitBehaviour : BaseBehaviour, IStateMachine<ARKitBehaviour> {
    public FiniteStateMachine<ARKitBehaviour> stateMachine {
        get;
        set;
    }
    private GameObject icon {
        get;
        set;
    }
    private Dictionary<string, ARPlaneAnchorGameObject> planeAnchorDictionary {
        get;
        set;
    }
    private bool tracked {
        get;
        set;
    }
    void Start() {
        UnityARSessionNativeInterface.ARAnchorUpdatedEvent += OnARKitAnchorUpdated;
        UnityARSessionNativeInterface.ARAnchorAddedEvent += OnARKitAnchorAdded;
        UnityARSessionNativeInterface.ARAnchorRemovedEvent += OnARKitAnchorRemoved;
        this.tracked = false;
        this.planeAnchorDictionary = new Dictionary<string, ARPlaneAnchorGameObject>();
        this.icon = GameObject.Find("Icon");
        this.stateMachine = new FiniteStateMachine<ARKitBehaviour>(this);
        this.stateMachine.Add("tracking", new ARKitTrackingState());
        this.stateMachine.Stop();
        return;
    }
    void Update() {
        this.stateMachine.Update();
        return;
    }
    public void OnARKitAnchorUpdated(ARPlaneAnchor planeAnchor) {
        if (false == this.planeAnchorDictionary.ContainsKey(planeAnchor.identifier)) {
            return;
        }
        ARPlaneAnchorGameObject planeAnchorObject = this.planeAnchorDictionary [planeAnchor.identifier];
        planeAnchorObject.planeAnchor = planeAnchor;
        Vector3 originPosition = UnityARMatrixOps.GetPosition(planeAnchor.transform);
        this.icon.name = planeAnchor.identifier;
        this.icon.transform.position = UnityARMatrixOps.GetPosition(planeAnchor.transform);
        this.icon.transform.rotation = UnityARMatrixOps.GetRotation(planeAnchor.transform);
        return;
    }
    public void OnARKitAnchorAdded(ARPlaneAnchor planeAnchor) {
        if (false != this.tracked || false != this.planeAnchorDictionary.ContainsKey(planeAnchor.identifier)) {
            return;
        }
        this.tracked = true;
        Vector3 originPosition = UnityARMatrixOps.GetPosition(planeAnchor.transform);
        Renderer[] renderers = this.icon.GetComponentsInChildren<Renderer>();
        foreach (Renderer child in renderers) {
            child.gameObject.transform.localScale = Vector3.one * IconBehaviour.SCALE_RATE_IOS;
        }
        this.icon.name = planeAnchor.identifier;
        this.icon.transform.position = new Vector3(originPosition.x, originPosition.y, originPosition.z);
        this.icon.transform.rotation = UnityARMatrixOps.GetRotation(planeAnchor.transform);
        ARPlaneAnchorGameObject planeAnchorObject = new ARPlaneAnchorGameObject();
        planeAnchorObject.planeAnchor = planeAnchor;
        planeAnchorObject.gameObject = this.icon;
        this.planeAnchorDictionary.Add(planeAnchor.identifier, planeAnchorObject);
        Notifier notifier = Notifier.GetInstance();
        notifier.Notify(NotifyMessage.OnTrackingFound);
        this.stateMachine.Change("tracking");
        this.stateMachine.Play();
        return;
    }
    public void OnARKitAnchorRemoved(ARPlaneAnchor planeAnchor) {
        if (false == this.planeAnchorDictionary.ContainsKey(planeAnchor.identifier)) {
            return;
        }
        ARPlaneAnchorGameObject planeAnchorObject = this.planeAnchorDictionary [planeAnchor.identifier];
        GameObject.Destroy(planeAnchorObject.gameObject);
        this.planeAnchorDictionary.Remove(planeAnchor.identifier);
        return;
    }
}
