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
using System.Collections.Generic;
using Core.IO.Stream.Asset;
using Core.IO.Format.Asset;
namespace Frontend.Component.Asset.Render {
public class MtlAsset : BaseRenderAsset {
    public Dictionary<string, Material> mtlList {
        get;
        private set;
    }
    public Dictionary<string, Material> Build(string path) {
        MtlAssetStream stream = new MtlAssetStream();
        MtlAssetFormat format = stream.Read(path);
        Dictionary<string, Material> materialList = new Dictionary<string, Material>();
        string rootDirectoryPath = Path.GetDirectoryName(path);
        foreach (MtlAssetNewmtlFormat newmtlFormat in format.newmtlList) {
            MtlAssetIlluminationFormat illumFormat = format.illumDictionary[newmtlFormat.name];
            string shaderName = string.Empty;
            if (2 == illumFormat.illuminationType) {
                shaderName = "Mobile/Bumped Specular";
            } else {
                if (false != format.mapkdDictionary.ContainsKey(newmtlFormat.name)) {
                    shaderName = "Mobile/Bumped Diffuse";
                } else {
                    shaderName = "Mobile/Diffuse";
                }
            }
            Shader shader = Shader.Find(shaderName);
            Material material = new Material(shader);
            material.name = newmtlFormat.name;
            if (false != format.niDictionary.ContainsKey(newmtlFormat.name)) {
                MtlAssetShininessFormat shininess = format.niDictionary[newmtlFormat.name];
                material.SetFloat("_Shininess", shininess.shininess);
            }
            if (false != format.nsDictionary.ContainsKey(newmtlFormat.name)) {
                MtlAssetSpecularIndexFormat specularIndex = format.nsDictionary[newmtlFormat.name];
                material.SetFloat("_Shininess", specularIndex.shininess);
            }
            if (false != format.dDictionary.ContainsKey(newmtlFormat.name)) {
                MtlAssetDissolveFormat dissolve = format.dDictionary[newmtlFormat.name];
                material.SetFloat("_Dissolve", dissolve.dissolve);
            }
            if (false != format.kaDictionary.ContainsKey(newmtlFormat.name)) {
                MtlAssetAmbientFormat ambient = format.kaDictionary[newmtlFormat.name];
                material.SetColor("_Color", ambient.color);
            }
            if (false != format.kdDictionary.ContainsKey(newmtlFormat.name)) {
                MtlAssetDiffuseFormat diffuse = format.kdDictionary[newmtlFormat.name];
                material.SetColor("_Color", diffuse.color);
            }
            if (false != format.ksDictionary.ContainsKey(newmtlFormat.name)) {
                MtlAssetSpecularFormat specular = format.ksDictionary[newmtlFormat.name];
                material.SetColor("_SpecColor", specular.color);
            }
            if (false != format.mapkdDictionary.ContainsKey(newmtlFormat.name)) {
                MtlAssetDiffuseTextureMapFormat diffuseTexture = format.mapkdDictionary[newmtlFormat.name];
                string texturePath = Path.Combine(rootDirectoryPath, diffuseTexture.name);
                byte[] textureData = File.ReadAllBytes(texturePath);
                Texture2D texture = new Texture2D(0, 0);
                texture.LoadImage(textureData);
                material.SetTexture("_MainTex", texture);
                material.SetColor("_Color", Color.white);
            }
            if (false != format.mapbumpDictionary.ContainsKey(newmtlFormat.name)) {
                MtlAssetBumpTextureMapFormat bumpmapTexture = format.mapbumpDictionary[newmtlFormat.name];
                string texturePath = Path.Combine(rootDirectoryPath, bumpmapTexture.name);
                byte[] textureData = File.ReadAllBytes(texturePath);
                Texture2D texture = new Texture2D(0, 0);
                texture.LoadImage(textureData);
                material.SetTexture("_BumpMap", texture);
                material.SetColor("_Color", Color.white);
            }
            materialList.Add(newmtlFormat.name, material);
        }
        return materialList;
    }
    public override IEnumerator AsyncBuild(string path) {
        MtlAssetStream stream = new MtlAssetStream();
        stream.AsyncRead(path);
        while (false == stream.asyncReadComplete) {
            yield return null;
        }
        MtlAssetFormat format = stream.data;
        Dictionary<string, Material> materialList = new Dictionary<string, Material>();
        string rootDirectoryPath = Path.GetDirectoryName(path);
        foreach (MtlAssetNewmtlFormat newmtlFormat in format.newmtlList) {
            MtlAssetIlluminationFormat illumFormat = format.illumDictionary[newmtlFormat.name];
            string shaderName = string.Empty;
            if (2 == illumFormat.illuminationType) {
                shaderName = "Mobile/Bumped Specular";
            } else {
                if (false != format.mapkdDictionary.ContainsKey(newmtlFormat.name)) {
                    shaderName = "Mobile/Bumped Diffuse";
                } else {
                    shaderName = "Mobile/Diffuse";
                }
            }
            Shader shader = Shader.Find(shaderName);
            Material material = new Material(shader);
            material.name = newmtlFormat.name;
            if (false != format.niDictionary.ContainsKey(newmtlFormat.name)) {
                MtlAssetShininessFormat shininess = format.niDictionary[newmtlFormat.name];
                material.SetFloat("_Shininess", shininess.shininess);
            }
            if (false != format.nsDictionary.ContainsKey(newmtlFormat.name)) {
                MtlAssetSpecularIndexFormat specularIndex = format.nsDictionary[newmtlFormat.name];
                material.SetFloat("_Shininess", specularIndex.shininess);
            }
            if (false != format.dDictionary.ContainsKey(newmtlFormat.name)) {
                MtlAssetDissolveFormat dissolve = format.dDictionary[newmtlFormat.name];
                material.SetFloat("_Dissolve", dissolve.dissolve);
            }
            if (false != format.kaDictionary.ContainsKey(newmtlFormat.name)) {
                MtlAssetAmbientFormat ambient = format.kaDictionary[newmtlFormat.name];
                material.SetColor("_Color", ambient.color);
            }
            if (false != format.kdDictionary.ContainsKey(newmtlFormat.name)) {
                MtlAssetDiffuseFormat diffuse = format.kdDictionary[newmtlFormat.name];
                material.SetColor("_Color", diffuse.color);
            }
            if (false != format.ksDictionary.ContainsKey(newmtlFormat.name)) {
                MtlAssetSpecularFormat specular = format.ksDictionary[newmtlFormat.name];
                material.SetColor("_SpecColor", specular.color);
            }
            if (false != format.mapkdDictionary.ContainsKey(newmtlFormat.name)) {
                MtlAssetDiffuseTextureMapFormat diffuseTexture = format.mapkdDictionary[newmtlFormat.name];
                string texturePath = Path.Combine(rootDirectoryPath, diffuseTexture.name);
                byte[] textureData = File.ReadAllBytes(texturePath);
                Texture2D texture = new Texture2D(0, 0);
                texture.LoadImage(textureData);
                material.SetTexture("_MainTex", texture);
                material.SetColor("_Color", Color.white);
            }
            if (false != format.mapbumpDictionary.ContainsKey(newmtlFormat.name)) {
                MtlAssetBumpTextureMapFormat bumpmapTexture = format.mapbumpDictionary[newmtlFormat.name];
                string texturePath = Path.Combine(rootDirectoryPath, bumpmapTexture.name);
                byte[] textureData = File.ReadAllBytes(texturePath);
                Texture2D texture = new Texture2D(0, 0);
                texture.LoadImage(textureData);
                material.SetTexture("_BumpMap", texture);
                material.SetColor("_Color", Color.white);
            }
            materialList.Add(newmtlFormat.name, material);
            yield return null;
        }
        this.mtlList = materialList;
        yield return null;
    }
}
}
