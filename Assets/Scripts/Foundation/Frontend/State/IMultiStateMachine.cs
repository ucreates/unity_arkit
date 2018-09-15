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
using System.Collections.Generic;
namespace Frontend.Component.State {
public interface IMultiStateMachine<T> where T : MonoBehaviour {
    List<FiniteStateMachine<T>> stateMachineList {
        get;
        set;
    }
}
}
