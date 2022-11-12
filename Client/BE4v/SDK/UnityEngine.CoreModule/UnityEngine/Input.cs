using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public static class Input
    {
        public static float GetAxis(string axisName) => Instance_Class.GetMethod(nameof(GetAxis)).Invoke<float>(new IntPtr[] { new IL2String_utf8(axisName).Pointer }).GetValue();
        unsafe public static bool GetKey(KeyCode key) => Instance_Class.GetMethod("GetKeyInt").Invoke<bool>(new IntPtr[] { new IntPtr(&key) }).GetValue();
        unsafe public static bool GetKeyDown(KeyCode key) => Instance_Class.GetMethod("GetKeyDownInt").Invoke<bool>(new IntPtr[] { new IntPtr(&key) }).GetValue();
        unsafe public static bool GetKeyUp(KeyCode key) => Instance_Class.GetMethod("GetKeyUpInt").Invoke<bool>(new IntPtr[] { new IntPtr(&key) }).GetValue();
        public static bool GetButtonDown(string buttonName) => Instance_Class.GetMethod(nameof(GetButtonDown)).Invoke<bool>(new IntPtr[] { new IL2String_utf8(buttonName).Pointer }).GetValue();

        public static Vector3 mousePosition
        {
            get => Instance_Class.GetProperty(nameof(mousePosition)).GetGetMethod().Invoke<Vector3>().GetValue();
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.InputLegacyModule"].GetClass("Input", "UnityEngine");
    }
}
