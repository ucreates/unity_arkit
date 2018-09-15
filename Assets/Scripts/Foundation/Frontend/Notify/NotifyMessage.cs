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
namespace Frontend.Notify {
public enum NotifyMessage {
    OnTrackingFound = 0x0000,
    OnTrackingLost = 0x0001,
    OnRaycastHit = 0x0002,
    OnLoadingComplete = 0x0003,
}
}
