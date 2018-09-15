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
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using Core.IO.Parser.Asset;
using Core.IO.Format.Asset;
namespace Core.IO.Stream.Asset {
public class MtlAssetStream : AssetBaseStream<MtlAssetFormat> {
    public override MtlAssetFormat Read(string assetPath) {
        MtlAssetFormat mtlAssetFormat = new MtlAssetFormat();
        string mtlAllData = System.IO.File.ReadAllText(assetPath);
        string[] mtlDatas = mtlAllData.Split('\n');
        foreach (string mtlData in mtlDatas) {
            if (0 == mtlData.Length) {
                continue;
            }
            string trimedMtlData = mtlData.Trim();
            int firstWhiteSpaceIndex = trimedMtlData.IndexOf(" ", 0);
            if (-1 == firstWhiteSpaceIndex) {
                continue;
            }
            string header = trimedMtlData.Substring(0, firstWhiteSpaceIndex).Trim();
            string body = trimedMtlData.Substring(firstWhiteSpaceIndex, trimedMtlData.Length - firstWhiteSpaceIndex).Trim();
            switch (header) {
            case ObjAssetBaseFormat.COMMENT:
                break;
            case MtlAssetBaseFormat.NEWMTL:
                MtlAssetBaseParser<MtlAssetNewmtlFormat> newmtlStream = new MtlAssetNewmtlParser();
                MtlAssetNewmtlFormat newmtl = newmtlStream.Read(header, body);
                mtlAssetFormat.newmtlList.Add(newmtl);
                break;
            case MtlAssetBaseFormat.NI:
                MtlAssetBaseParser<MtlAssetShininessFormat> shininessStream = new MtlAssetShininessParser();
                MtlAssetShininessFormat ni = shininessStream.Read(header, body);
                mtlAssetFormat.Add<MtlAssetShininessFormat>(ni);
                break;
            case MtlAssetBaseFormat.NS:
                MtlAssetBaseParser<MtlAssetSpecularIndexFormat> specularIndexStream = new MtlAssetSpecularIndexParser();
                MtlAssetSpecularIndexFormat ns = specularIndexStream.Read(header, body);
                mtlAssetFormat.Add<MtlAssetSpecularIndexFormat>(ns);
                break;
            case MtlAssetBaseFormat.KA:
                MtlAssetBaseParser<MtlAssetAmbientFormat> ambientStream = new MtlAssetAmbientParser();
                MtlAssetAmbientFormat ka = ambientStream.Read(header, body);
                mtlAssetFormat.Add<MtlAssetAmbientFormat>(ka);
                break;
            case MtlAssetBaseFormat.KD:
                MtlAssetBaseParser<MtlAssetDiffuseFormat> diffuseStream = new MtlAssetDiffuseParser();
                MtlAssetDiffuseFormat kd = diffuseStream.Read(header, body);
                mtlAssetFormat.Add<MtlAssetDiffuseFormat>(kd);
                break;
            case MtlAssetBaseFormat.KS:
                MtlAssetBaseParser<MtlAssetSpecularFormat> specularStream = new MtlAssetSpecularParser();
                MtlAssetSpecularFormat ks = specularStream.Read(header, body);
                mtlAssetFormat.Add<MtlAssetSpecularFormat>(ks);
                break;
            case MtlAssetBaseFormat.D:
                MtlAssetBaseParser<MtlAssetDissolveFormat> dissolveStream = new MtlAssetDissolveParser();
                MtlAssetDissolveFormat d = dissolveStream.Read(header, body);
                mtlAssetFormat.Add<MtlAssetDissolveFormat>(d);
                break;
            case MtlAssetBaseFormat.TF:
                MtlAssetBaseParser<MtlAssetSpectralFormat> spectralStream = new MtlAssetSpectralParser();
                MtlAssetSpectralFormat tf = spectralStream.Read(header, body);
                mtlAssetFormat.Add<MtlAssetSpectralFormat>(tf);
                break;
            case MtlAssetBaseFormat.TR:
                dissolveStream = new MtlAssetDissolveParser();
                MtlAssetDissolveFormat tr = dissolveStream.Read(header, body);
                mtlAssetFormat.Add<MtlAssetDissolveFormat>(tr);
                break;
            case MtlAssetBaseFormat.ILLUM:
                MtlAssetBaseParser<MtlAssetIlluminationFormat> illuminationStream = new MtlAssetIlluminationParser();
                MtlAssetIlluminationFormat illum = illuminationStream.Read(header, body);
                mtlAssetFormat.Add<MtlAssetIlluminationFormat>(illum);
                break;
            case MtlAssetBaseFormat.MAP_KA:
                MtlAssetBaseParser<MtlAssetAmbientTextureMapFormat> ambientTextureStream = new MtlAssetAmbientTextureMapParser();
                MtlAssetAmbientTextureMapFormat mapka = ambientTextureStream.Read(header, body);
                mtlAssetFormat.Add<MtlAssetAmbientTextureMapFormat>(mapka);
                break;
            case MtlAssetBaseFormat.MAP_KD:
                MtlAssetBaseParser<MtlAssetDiffuseTextureMapFormat> diffuseTextureStream = new MtlAssetDiffuseTextureMapParser();
                MtlAssetDiffuseTextureMapFormat mapkd = diffuseTextureStream.Read(header, body);
                mtlAssetFormat.Add<MtlAssetDiffuseTextureMapFormat>(mapkd);
                break;
            case MtlAssetBaseFormat.MAP_KS:
                MtlAssetBaseParser<MtlAssetSpecularTextureMapFormat> specularTextureMapStream = new MtlAssetSpecularTextureMapParser();
                MtlAssetSpecularTextureMapFormat mapks = specularTextureMapStream.Read(header, body);
                mtlAssetFormat.Add<MtlAssetSpecularTextureMapFormat>(mapks);
                break;
            case MtlAssetBaseFormat.MAP_NS:
                MtlAssetBaseParser<MtlAssetSpecularIndexTextureMapFormat> specularIndexTextureStream = new MtlAssetSpecularIndexTextureMapParser();
                MtlAssetSpecularIndexTextureMapFormat mapns = specularIndexTextureStream.Read(header, body);
                mtlAssetFormat.Add<MtlAssetSpecularIndexTextureMapFormat>(mapns);
                break;
            case MtlAssetBaseFormat.MAP_BUMP:
                MtlAssetBaseParser<MtlAssetBumpTextureMapFormat> bumpTextureMapStream = new MtlAssetBumpTextureMapParser();
                MtlAssetBumpTextureMapFormat mapbump = bumpTextureMapStream.Read(header, body);
                mtlAssetFormat.Add<MtlAssetBumpTextureMapFormat>(mapbump);
                break;
            case MtlAssetBaseFormat.BUMP:
                break;
            default:
                string log = string.Format("unknown format.header::{0},body{1}", header, body);
                Debug.LogWarning(log);
                break;
            }
        }
        return mtlAssetFormat;
    }
}
}
