using System;
using IL2CPP_Core.Objects;

namespace UnityEngine.SceneManagement
{
    public static class SceneManagerAPIInternal
    {
        unsafe public static string GetScenePathByBuildIndex(int buildIndex)
        {
            return Instance_Class.GetMethod(nameof(GetScenePathByBuildIndex)).Invoke(new IntPtr[] { new IntPtr(&buildIndex) })?.GetValue<IL2String>().ToString();
        }

        unsafe public static AsyncOperation LoadSceneAsyncNameIndexInternal(string sceneName, int sceneBuildIndex, LoadSceneParameters parameters, bool mustCompleteNextFrame)
        {
            return Instance_Class.GetMethod(nameof(LoadSceneAsyncNameIndexInternal)).Invoke(new IntPtr[] { sceneName == null ? IntPtr.Zero : new IL2String_utf16(sceneName).Pointer, new IntPtr(&sceneBuildIndex), new IntPtr(&parameters), new IntPtr(&mustCompleteNextFrame) })?.GetValue<AsyncOperation>();
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("SceneManagerAPIInternal", "UnityEngine.SceneManagement");
    }
}
