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
namespace Core.Object {
public class ChildGameObject {
    public static GameObject Instanciate(string name, Vector3 position, Quaternion rotation, GameObject parent, string tag) {
        GameObject child = new GameObject();
        child.transform.parent = parent.transform;
        child.transform.localPosition = Vector3.zero;
        child.transform.localRotation = rotation;
        child.tag = tag;
        child.name = name;
        return child;
    }
    public static T Instanciate<T>(string name, Vector3 position, Quaternion rotation, GameObject parent, string tag) where T : MonoBehaviour {
        GameObject child = Core.Object.ChildGameObject.Instanciate(name, position, rotation, parent, tag);
        return child.AddComponent<T>();
    }
}
}
