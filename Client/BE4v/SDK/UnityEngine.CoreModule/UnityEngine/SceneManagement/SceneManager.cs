using System;
using IL2CPP_Core.Objects;

namespace UnityEngine.SceneManagement
{
    public class SceneManager : IL2Object
	{
		public SceneManager(IntPtr ptr) : base(ptr) { }

		public static int sceneCount
		{
			get => Instance_Class.GetProperty(nameof(sceneCount)).GetGetMethod().Invoke<int>().GetValue();
		}

		public static int sceneCountInBuildSettings
		{
			get => Instance_Class.GetProperty(nameof(sceneCountInBuildSettings)).GetGetMethod().Invoke<int>().GetValue();
		}

		public static Scene GetActiveScene()
		{
			return Instance_Class.GetMethod(nameof(GetActiveScene)).Invoke<Scene>().GetValue();
		}

		unsafe public static bool SetActiveScene(Scene scene)
		{
			return Instance_Class.GetMethod(nameof(SetActiveScene)).Invoke<bool>(new IntPtr[] { new IntPtr(&scene) }).GetValue();
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("SceneManager", "UnityEngine.SceneManagement");
    }
}
