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
using Service.Integration.Table;
using Service.Integration.Schema;
namespace Service.Integration.Table {
public sealed class TTestTable : BaseTable {
    public int value {
        get;
        set;
    }
    public TTestTable() {
        this.value = 0;
    }
    public override BaseTable Clone() {
        return base.MemberwiseClone() as TTestTable;
    }
}
}
