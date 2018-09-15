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
using System.Collections.Generic;
namespace Core.IO.Format.Asset {
public class ObjAssetFormat : ObjAssetBaseFormat {
    public Dictionary<string, List<ObjAssetPolygonFaceFormat>> fDictionary {
        get;
        set;
    }
    public Dictionary<string, List<ObjAssetGroupFormat>> gDictionary {
        get;
        set;
    }
    public List<ObjAssetMaterialFormat> mtllibList {
        get;
        set;
    }
    public List<ObjAssetObjectFormat> oList {
        get;
        set;
    }
    public Dictionary<string, ObjAssetUseMaterialFormat> usemtlDictionary {
        get;
        set;
    }
    public List<ObjAssetVertexFormat> vList {
        get;
        set;
    }
    public List<ObjAssetTextureFormat> vtList {
        get;
        set;
    }
    public List<ObjAssetNormalVectorFormat> vnList {
        get;
        set;
    }
    public ObjAssetFormat() {
        this.fDictionary = new Dictionary<string, List<ObjAssetPolygonFaceFormat>>();
        this.gDictionary = new Dictionary<string, List<ObjAssetGroupFormat>>();
        this.usemtlDictionary = new Dictionary<string, ObjAssetUseMaterialFormat>();
        this.mtllibList = new List<ObjAssetMaterialFormat>();
        this.oList = new List<ObjAssetObjectFormat>();
        this.vList = new List<ObjAssetVertexFormat>();
        this.vtList = new List<ObjAssetTextureFormat>();
        this.vnList = new List<ObjAssetNormalVectorFormat>();
    }
    public void Create() {
        ObjAssetObjectFormat oformat = new ObjAssetObjectFormat();
        oformat.header = "o";
        oformat.name = "default";
        this.AddObject(oformat);
        return;
    }
    public void AddObject(ObjAssetObjectFormat oformat) {
        this.oList.Add(oformat);
        ObjAssetGroupFormat gformat = new ObjAssetGroupFormat();
        gformat.header = "g";
        gformat.name = "default";
        List<ObjAssetGroupFormat> gformatList = new List<ObjAssetGroupFormat>();
        gformatList.Add(gformat);
        this.gDictionary.Add(oformat.name, gformatList);
        return;
    }
    public void AddGroup(ObjAssetGroupFormat gformat) {
        int lastIndex = this.oList.Count - 1;
        ObjAssetObjectFormat oformat = this.oList[lastIndex];
        if (false == this.gDictionary.ContainsKey(oformat.name)) {
            List<ObjAssetGroupFormat> gformatList = new List<ObjAssetGroupFormat>();
            gformatList.Add(gformat);
            this.gDictionary.Add(oformat.name, gformatList);
        } else {
            List<ObjAssetGroupFormat> gformatList = this.gDictionary[oformat.name];
            gformatList.Add(gformat);
        }
        return;
    }
    public void AddPolygonFace(ObjAssetPolygonFaceFormat fformat) {
        string path = this.GetLastGroupPath();
        if (false == this.fDictionary.ContainsKey(path)) {
            List<ObjAssetPolygonFaceFormat> fformatList = new List<ObjAssetPolygonFaceFormat>();
            fformatList.Add(fformat);
            this.fDictionary.Add(path, fformatList);
        } else {
            List<ObjAssetPolygonFaceFormat> fformatList = this.fDictionary[path];
            fformatList.Add(fformat);
        }
        int lastIndex = this.oList.Count - 1;
        ObjAssetObjectFormat oformat = this.oList[lastIndex];
        List<ObjAssetGroupFormat> gformatList = this.gDictionary[oformat.name];
        lastIndex = gformatList.Count - 1;
        ObjAssetGroupFormat gformat = gformatList[lastIndex];
        gformat.polygonFaceCount += fformat.indexList.Count;
        return;
    }
    public void AddUseMaterial(ObjAssetUseMaterialFormat usemtlFormat) {
        string path = this.GetLastGroupPath();
        if (false == this.usemtlDictionary.ContainsKey(path)) {
            this.usemtlDictionary.Add(path, usemtlFormat);
        }
        return;
    }
    public int GetPolygonFaceCount(string path) {
        if (false == this.fDictionary.ContainsKey(path)) {
            return 0;
        }
        int findiciesCount = 0;
        List<ObjAssetPolygonFaceFormat> fList = fDictionary[path];
        foreach (ObjAssetPolygonFaceFormat f in fList) {
            findiciesCount += f.indexList.Count;
        }
        return findiciesCount;
    }
    public int GetAllPolygonFacesCount() {
        int findiciesCount = 0;
        foreach (ObjAssetObjectFormat oformat in this.oList) {
            if (false == this.gDictionary.ContainsKey(oformat.name)) {
                continue;
            }
            List<ObjAssetGroupFormat> glist = this.gDictionary[oformat.name];
            foreach (ObjAssetGroupFormat gformat in glist) {
                string path = Path.Combine(oformat.name, gformat.name);
                findiciesCount += this.GetPolygonFaceCount(path);
            }
        }
        return findiciesCount;
    }
    private string GetLastGroupPath() {
        int lastIndex = this.oList.Count - 1;
        ObjAssetObjectFormat oformat = this.oList[lastIndex];
        List<ObjAssetGroupFormat> gformatList = this.gDictionary[oformat.name];
        lastIndex = gformatList.Count - 1;
        ObjAssetGroupFormat gformat = gformatList[lastIndex];
        string path = Path.Combine(oformat.name, gformat.name);
        return path;
    }
    public override void Dump() {
        Debug.Log(string.Format("f::{0}", this.fDictionary.Count));
        Debug.Log(string.Format("g::{0}", this.gDictionary.Count));
        Debug.Log(string.Format("mtllib::{0}", this.mtllibList.Count));
        Debug.Log(string.Format("o::{0}", this.oList.Count));
        Debug.Log(string.Format("usemtl::{0}", this.usemtlDictionary.Count));
        Debug.Log(string.Format("v::{0}", this.vList.Count));
        Debug.Log(string.Format("vt::{0}", this.vtList.Count));
        Debug.Log(string.Format("vn::{0}", this.vnList.Count));
        Debug.Log(string.Format("allfcount::{0}", this.GetAllPolygonFacesCount()));
        foreach (string objectName in this.gDictionary.Keys) {
            List<ObjAssetGroupFormat> glist = this.gDictionary[objectName];
            Debug.Log(string.Format("objectName::{0},in g count::{1}", objectName, glist.Count));
        }
        foreach (string key in this.fDictionary.Keys) {
            int count = 0;
            List<ObjAssetPolygonFaceFormat> flist = this.fDictionary[key];
            foreach (ObjAssetPolygonFaceFormat f in flist) {
                count += f.indexList.Count;
            }
            Debug.Log(string.Format("groupName::{0},in f count::{1}", key, count));
        }
        foreach (string key in this.usemtlDictionary.Keys) {
            ObjAssetUseMaterialFormat usemtlFormat = this.usemtlDictionary[key];
            Debug.Log(string.Format("groupName::{0},usemtlName::{1}", key, usemtlFormat.name));
        }
        return;
    }
}
}
