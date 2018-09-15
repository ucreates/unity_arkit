//======================================================================
// Project Name    : unity_foundation
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
using Frontend.Behaviour;
using Frontend.Behaviour.Base;
namespace Frontend.Behaviour.Stage.Vfx {
public class VfxBaseBehaviour : BaseBehaviour {
    protected bool recycle {
        get;
        set;
    }
    private void OnEnable() {
        this.StartCoroutine("Show");
        return;
    }
    private IEnumerator Show() {
        while (true) {
            yield return new WaitForSeconds(0.5f);
            ParticleSystem particleSystem = this.GetComponent<ParticleSystem>();
            if (false != particleSystem.IsAlive(true)) {
                continue;
            }
            if (false != this.recycle) {
                this.gameObject.SetActive(false);
            } else {
                UnityEngine.GameObject.Destroy(this.gameObject);
            }
            break;
        }
    }
}
}
