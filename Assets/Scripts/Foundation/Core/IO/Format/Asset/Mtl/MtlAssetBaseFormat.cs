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
using System.IO;
using System.Collections;
namespace Core.IO.Format.Asset {
public abstract class MtlAssetBaseFormat : AssetBaseFormat {
    public const string NEWMTL = "newmtl";
    public const string NS = "Ns";
    public const string NI = "Ni";
    public const string KA = "Ka";
    public const string KD = "Kd";
    public const string KS = "Ks";
    public const string D = "d";
    public const string TF = "Tf";
    public const string TR = "Tr";
    public const string ILLUM = "illum";
    public const string MAP_KA = "map_Ka";
    public const string MAP_KD = "map_Kd";
    public const string MAP_KS = "map_Ks";
    public const string MAP_NS = "map_Ns";
    public const string MAP_BUMP = "map_Bump";
    public const string BUMP = "bump";
    public string header {
        get;
        set;
    }
    public MtlAssetBaseFormat() {
        this.header = string.Empty;
    }
    public virtual void Dump() {
        return;
    }
}
}
