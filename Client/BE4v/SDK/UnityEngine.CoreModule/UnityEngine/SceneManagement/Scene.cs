using System;
using System.Collections.Generic;
using IL2CPP_Core.Objects;

namespace UnityEngine.SceneManagement
{
	[Serializable]
	public struct Scene
	{
		unsafe private static bool IsValidInternal(int sceneHandle)
		{
			return Instance_Class.GetMethod(nameof(IsValidInternal)).Invoke<bool>(new IntPtr[] { new IntPtr(&sceneHandle) }).GetValue();
		}

		unsafe private static string GetNameInternal(int sceneHandle)
		{
			return Instance_Class.GetMethod(nameof(GetNameInternal)).Invoke(new IntPtr[] { new IntPtr(&sceneHandle) })?.GetValue<IL2String>().ToString();
		}

		unsafe private static bool GetIsLoadedInternal(int sceneHandle)
		{
			return Instance_Class.GetMethod(nameof(GetIsLoadedInternal)).Invoke<bool>(new IntPtr[] { new IntPtr(&sceneHandle) }).GetValue();
		}

		unsafe private static int GetBuildIndexInternal(int sceneHandle)
		{
			return Instance_Class.GetMethod(nameof(GetBuildIndexInternal)).Invoke<int>(new IntPtr[] { new IntPtr(&sceneHandle) }).GetValue();
		}

		unsafe private static int GetRootCountInternal(int sceneHandle)
		{
			return Instance_Class.GetMethod(nameof(GetRootCountInternal)).Invoke<int>(new IntPtr[] { new IntPtr(&sceneHandle) }).GetValue();
		}

		public int handle
		{
			get => m_Handle;
		}

		public bool IsValid()
		{
			return IsValidInternal(handle);
		}

		public string name
		{
			get => GetNameInternal(handle);
		}

		public bool isLoaded
		{
			get => GetIsLoadedInternal(handle);
		}

		public int buildIndex
		{
			get => GetBuildIndexInternal(handle);
		}

		public int rootCount
		{
			get => GetRootCountInternal(handle);
		}

		unsafe public GameObject[] GetRootGameObjects()
		{
			Scene _this = this;

			IL2Object result = Instance_Class.GetMethod(nameof(GetRootGameObjects)).Invoke(new IntPtr(&_this));
			if (result == null)
				return null;

			return new IL2Array<IntPtr>(result.Pointer).ToArray<GameObject>();
		}

		public static bool operator ==(Scene lhs, Scene rhs)
		{
			return lhs.handle == rhs.handle;
		}

		public static bool operator !=(Scene lhs, Scene rhs)
		{
			return lhs.handle != rhs.handle;
		}

		public override int GetHashCode()
		{
			return m_Handle;
		}

		public override bool Equals(object other)
		{
			bool result;
			if (!(other is Scene))
			{
				result = false;
			}
			else
			{
				Scene scene = (Scene)other;
				result = (handle == scene.handle);
			}
			return result;
		}

		// [SerializeField]
		private int m_Handle;

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("Scene", "UnityEngine.SceneManagement");
	}
}