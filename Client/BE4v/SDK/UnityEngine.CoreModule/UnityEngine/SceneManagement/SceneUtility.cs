using System;
using IL2CPP_Core.Objects;

namespace UnityEngine.SceneManagement
{
    public static class SceneUtility
    {
        unsafe public static string GetScenePathByBuildIndex(int buildIndex)
        {
            return Instance_Class.GetMethod(nameof(GetScenePathByBuildIndex)).Invoke(new IntPtr[] { new IntPtr(&buildIndex) })?.GetValue<IL2String>().ToString();
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("SceneUtility", "UnityEngine.SceneManagement");
    }
}
