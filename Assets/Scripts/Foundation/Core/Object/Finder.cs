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
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
namespace Core.Object {
public sealed class Finder {
    public static T Find<T>(params string[] path) {
        string gameObjectPath = Core.IO.Path.Combine(path);
        GameObject gameObject = GameObject.Find(gameObjectPath);
        return gameObject.GetComponent<T>();
    }
    public static T[] FindChild<T>(params string[] path) {
        string gameObjectPath = Core.IO.Path.Combine(path);
        GameObject gameObject = GameObject.Find(gameObjectPath);
        return gameObject.GetComponentsInChildren<T>(true);
    }
    public static T FindChild<T>(MonoBehaviour parent, string gameObjectName) where T : UnityEngine.Object {
        T ret = null;
        string keyName = gameObjectName.ToLower();
        T[] componens = parent.GetComponentsInChildren<T>(true);
        foreach (T component in componens) {
            if (false != component.name.ToLower().Equals(keyName)) {
                ret = component;
                break;
            }
        }
        return ret;
    }
}
}
