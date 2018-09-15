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
using System.Threading;
using System.IO;
using System.Collections.Generic;
using Frontend.Component.Asset;
using Core.IO.Format.Asset;
namespace Core.IO.Stream.Asset {
public abstract class AssetBaseStream<T> where T : AssetBaseFormat, new() {
    public T data {
        get;
        protected set;
    }
    public bool asyncReadComplete {
        get;
        protected set;
    }
    public virtual T Read(string assetPath) {
        return null;
    }
    private void Read(object filePath) {
        this.data = this.Read(filePath.ToString());
        this.asyncReadComplete = true;
        return;
    }
    public void AsyncRead(string filePath) {
        object oFilePath = filePath;
        ParameterizedThreadStart pts = new ParameterizedThreadStart(this.Read);
        Thread thread = new Thread(pts);
        thread.Start(oFilePath);
        return;
    }
}
}
