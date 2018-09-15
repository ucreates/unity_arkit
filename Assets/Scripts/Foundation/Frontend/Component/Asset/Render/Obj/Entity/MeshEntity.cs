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
using System.Collections.Generic;
namespace Frontend.Component.Asset.Render {
public class MeshEntity {
    public List<Vector3[]> verticiesList {
        get;
        set;
    }
    public List<Vector2[]> uvsList {
        get;
        set;
    }
    public List<Vector3[]> normalVectorsList {
        get;
        set;
    }
    public List<int[]> trianglesList {
        get;
        set;
    }
    public int totalMeshCount {
        get;
        set;
    }
    public MeshEntity() {
        this.verticiesList = new List<Vector3[]>();
        this.uvsList = new List<Vector2[]>();
        this.normalVectorsList = new List<Vector3[]>();
        this.trianglesList = new List<int[]>();
        this.totalMeshCount = 0;
    }
}
}
