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
using System;
using System.Text.RegularExpressions;
using System.Collections;
namespace Core.IO {
public sealed class File {
    public static string META = @"(\.meta$)";
    private const string PIX = @"(\.jpg$|\.jpeg$|\.png$)";
    public static string MODEL = @"(\.obj$|\.mtl$)";
    public static bool Copy(string originFilePath, string destDirectoryPath) {
        if (Regex.IsMatch(originFilePath, File.META)) {
            return false;
        }
        string fileName = System.IO.Path.GetFileName(originFilePath);
        string writePath = System.IO.Path.Combine(destDirectoryPath, fileName);
        WWW client = new WWW(originFilePath);
        while (false == client.isDone) {}
        if (false != System.IO.File.Exists(writePath)) {
            System.IO.File.Delete(writePath);
        }
        if (false != Regex.IsMatch(writePath, File.PIX)) {
            byte[] data = client.bytes;
            System.IO.File.WriteAllBytes(writePath, data);
        } else if (false != Regex.IsMatch(writePath, File.MODEL)) {
            string data = client.text;
            System.IO.File.WriteAllText(writePath, data);
        }
        return true;
    }
    public static bool Move(string originFilePath, string destDirectoryPath) {
        bool ret = Core.IO.File.Copy(originFilePath, destDirectoryPath);
        if (false == ret) {
            return false;
        }
        System.IO.File.Delete(originFilePath);
        return true;
    }
}
}
