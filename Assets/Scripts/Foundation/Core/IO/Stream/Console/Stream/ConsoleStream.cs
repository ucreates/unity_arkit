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
using System.Reflection;
using System.Diagnostics;
namespace Core.IO.Stream.Console {
public class ConsoleStream {
    public static void Write(string format, params object[] values) {
        string body = string.Format(format, values);
        StackFrame frame = new StackFrame(1, true);
        int lineNumber = frame.GetFileLineNumber();
        MethodBase methodBase = frame.GetMethod();
        string className = methodBase.ReflectedType.FullName;
        string methodName = methodBase.Name;
        string log = string.Format("[TRACE]methodName::{0}.{1} at {2},summary::{3}", className, methodName, lineNumber, body);
        UnityEngine.Debug.Log(log);
        return;
    }
}
}
