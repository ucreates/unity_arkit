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
using System;
using System.IO;
using System.Collections.Generic;
namespace Core.IO.Format.Asset {
public class MtlAssetFormat : MtlAssetBaseFormat {
    public List<MtlAssetNewmtlFormat> newmtlList {
        get;
        set;
    }
    public Dictionary<string, MtlAssetShininessFormat> niDictionary {
        get;
        set;
    }
    public Dictionary<string, MtlAssetSpecularIndexFormat> nsDictionary {
        get;
        set;
    }
    public Dictionary<string, MtlAssetAmbientFormat> kaDictionary {
        get;
        set;
    }
    public Dictionary<string, MtlAssetDiffuseFormat> kdDictionary {
        get;
        set;
    }
    public Dictionary<string, MtlAssetSpecularFormat> ksDictionary {
        get;
        set;
    }
    public Dictionary<string, MtlAssetDissolveFormat> dDictionary {
        get;
        set;
    }
    public Dictionary<string, MtlAssetSpectralFormat> tfDictionary {
        get;
        set;
    }
    public Dictionary<string, MtlAssetDissolveFormat> trDictionary {
        get;
        set;
    }
    public Dictionary<string, MtlAssetIlluminationFormat> illumDictionary {
        get;
        set;
    }
    public Dictionary<string, MtlAssetAmbientTextureMapFormat> mapkaDictionary {
        get;
        set;
    }
    public Dictionary<string, MtlAssetDiffuseTextureMapFormat> mapkdDictionary {
        get;
        set;
    }
    public Dictionary<string, MtlAssetSpecularTextureMapFormat> mapksDictionary {
        get;
        set;
    }
    public Dictionary<string, MtlAssetSpecularIndexTextureMapFormat> mapnsDictionary {
        get;
        set;
    }
    public Dictionary<string, MtlAssetBumpTextureMapFormat> mapbumpDictionary {
        get;
        set;
    }
    public MtlAssetFormat() {
        this.newmtlList = new List<MtlAssetNewmtlFormat>();
        this.niDictionary = new Dictionary<string, MtlAssetShininessFormat>();
        this.nsDictionary = new Dictionary<string, MtlAssetSpecularIndexFormat>();
        this.kaDictionary = new Dictionary<string, MtlAssetAmbientFormat>();
        this.kdDictionary = new Dictionary<string, MtlAssetDiffuseFormat>();
        this.ksDictionary = new Dictionary<string, MtlAssetSpecularFormat>();
        this.dDictionary = new Dictionary<string, MtlAssetDissolveFormat>();
        this.tfDictionary = new Dictionary<string, MtlAssetSpectralFormat>();
        this.trDictionary = new Dictionary<string, MtlAssetDissolveFormat>();
        this.illumDictionary = new Dictionary<string, MtlAssetIlluminationFormat>();
        this.mapkaDictionary = new Dictionary<string, MtlAssetAmbientTextureMapFormat>();
        this.mapkdDictionary = new Dictionary<string, MtlAssetDiffuseTextureMapFormat>();
        this.mapksDictionary = new Dictionary<string, MtlAssetSpecularTextureMapFormat>();
        this.mapnsDictionary = new Dictionary<string, MtlAssetSpecularIndexTextureMapFormat>();
        this.mapbumpDictionary = new Dictionary<string, MtlAssetBumpTextureMapFormat>();
    }
    public void Add<T>(T format) where T : MtlAssetBaseFormat, new() {
        Type type = format.GetType();
        Dictionary<string, T> formatDictionary = null;
        if (typeof(MtlAssetShininessFormat) == type) {
            formatDictionary = this.niDictionary as Dictionary<string, T>;
        } else if (typeof(MtlAssetSpecularIndexFormat) == type) {
            formatDictionary = this.nsDictionary as Dictionary<string, T>;
        } else if (typeof(MtlAssetAmbientFormat) == type) {
            formatDictionary = this.kaDictionary as Dictionary<string, T>;
        } else if (typeof(MtlAssetDiffuseFormat) == type) {
            formatDictionary = this.kdDictionary as Dictionary<string, T>;
        } else if (typeof(MtlAssetSpecularFormat) == type) {
            formatDictionary = this.ksDictionary as Dictionary<string, T>;
        } else if (typeof(MtlAssetDissolveFormat) == type) {
            formatDictionary = this.dDictionary as Dictionary<string, T>;
        } else if (typeof(MtlAssetSpectralFormat) == type) {
            formatDictionary = this.tfDictionary as Dictionary<string, T>;
        } else if (typeof(MtlAssetDissolveFormat) == type) {
            formatDictionary = this.trDictionary as Dictionary<string, T>;
        } else if (typeof(MtlAssetIlluminationFormat) == type) {
            formatDictionary = this.illumDictionary as Dictionary<string, T>;
        } else if (typeof(MtlAssetAmbientTextureMapFormat) == type) {
            formatDictionary = this.mapkaDictionary as Dictionary<string, T>;
        } else if (typeof(MtlAssetDiffuseTextureMapFormat) == type) {
            formatDictionary = this.mapkdDictionary as Dictionary<string, T>;
        } else if (typeof(MtlAssetSpecularTextureMapFormat) == type) {
            formatDictionary = this.mapksDictionary as Dictionary<string, T>;
        } else if (typeof(MtlAssetSpecularIndexTextureMapFormat) == type) {
            formatDictionary = this.mapnsDictionary as Dictionary<string, T>;
        } else if (typeof(MtlAssetBumpTextureMapFormat) == type) {
            formatDictionary = this.mapbumpDictionary as Dictionary<string, T>;
        }
        int lastIndex = this.newmtlList.Count - 1;
        MtlAssetNewmtlFormat newmtlFormat = this.newmtlList[lastIndex];
        if (false == formatDictionary.ContainsKey(newmtlFormat.name)) {
            formatDictionary.Add(newmtlFormat.name, format);
        }
        return;
    }
    public override void Dump() {
        Debug.Log(string.Format("newmtl::{0}", this.newmtlList.Count));
        Debug.Log(string.Format("ni::{0}", this.niDictionary.Count));
        Debug.Log(string.Format("ns::{0}", this.nsDictionary.Count));
        Debug.Log(string.Format("ka::{0}", this.kaDictionary.Count));
        Debug.Log(string.Format("kd::{0}", this.kdDictionary.Count));
        Debug.Log(string.Format("illum::{0}", this.illumDictionary.Count));
        return;
    }
}
}
