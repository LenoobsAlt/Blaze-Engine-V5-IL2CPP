using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
    public static class Application
    {
        unsafe public static int targetFrameRate
        {
            get => Instance_Class.GetProperty(nameof(targetFrameRate)).GetGetMethod().Invoke<int>().GetValue();
            set => Instance_Class.GetProperty(nameof(targetFrameRate)).GetSetMethod().Invoke(new IntPtr[] { new IntPtr(&value) });
        }

        public static string unityVersion
        {
            get => Instance_Class.GetProperty(nameof(unityVersion)).GetGetMethod().Invoke()?.GetValue<IL2String>().ToString();
        }

        public static string streamingAssetsPath
        {
            get => Instance_Class.GetProperty(nameof(streamingAssetsPath)).GetGetMethod().Invoke()?.GetValue<IL2String>().ToString();
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("Application", "UnityEngine");
    }
}
