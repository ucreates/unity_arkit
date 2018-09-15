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
namespace Core.IO.Format.Asset {
public class ObjAssetPolygonFaceFormat : ObjAssetBaseFormat {
    public enum SignType {
        Plus,
        Minus
    }
    public class Index {
        public int vertexIndex {
            get;
            set;
        }
        public int uvIndex {
            get;
            set;
        }
        public int normalVectorIndex {
            get;
            set;
        }
        public Index() {
            this.vertexIndex = 0;
            this.uvIndex = 0;
            this.normalVectorIndex = 0;
        }
    }
    public bool firstGroup {
        get;
        set;
    }
    public SignType signType {
        get;
        set;
    }
    public List<Index> indexList {
        get;
        set;
    }
    public ObjAssetPolygonFaceFormat() {
        this.firstGroup = false;
        this.signType = SignType.Plus;
        this.indexList = new List<Index>();
    }
}
}
