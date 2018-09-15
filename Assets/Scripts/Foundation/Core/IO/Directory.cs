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
using System.Collections;
namespace Core.IO {
public sealed class Directory {
    public static void Create(string dirPath) {
        if (false != System.IO.Directory.Exists(dirPath)) {
            Core.IO.Directory.Delete(dirPath);
        }
        System.IO.Directory.CreateDirectory(dirPath);
        return;
    }
    public static void Delete(string path) {
        if (false == System.IO.Directory.Exists(path)) {
            return;
        }
        string[] filePaths = System.IO.Directory.GetFiles(path);
        foreach (string filePath in filePaths) {
            System.IO.File.SetAttributes(filePath, System.IO.FileAttributes.Normal);
            System.IO.File.Delete(filePath);
        }
        string[] directoryPaths = System.IO.Directory.GetDirectories(path);
        foreach (string directoryPath in directoryPaths) {
            Core.IO.Directory.Delete(directoryPath);
        }
        System.IO.Directory.Delete(path, false);
        return;
    }
}
}
