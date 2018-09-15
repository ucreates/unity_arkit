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
using System.Collections.Generic;
namespace Core.Device {
public sealed class UserAgent {
    private List<string> deviceInfoList {
        get;
        set;
    }
    public UserAgent() {
        this.deviceInfoList = new List<string>();
        this.deviceInfoList.Add(UnityEngine.SystemInfo.deviceName);
        this.deviceInfoList.Add(UnityEngine.SystemInfo.deviceModel);
        this.deviceInfoList.Add(UnityEngine.SystemInfo.operatingSystem);
    }
    public string Create() {
        string uastring = string.Empty;
        for (int i = 0; i < this.deviceInfoList.Count; i++) {
            string data = this.deviceInfoList[i];
            uastring += string.Format("{0} ", data);
        }
        uastring = string.Format("({0})", uastring);
        return uastring;
    }
}
}
