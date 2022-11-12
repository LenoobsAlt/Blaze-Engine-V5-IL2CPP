using System;
using IL2CPP_Core.Objects;
using BE4v.SDK;

namespace UnityEngine
{
	/// <summary>
	///   <para>Behaviours are Components that can be enabled or disabled.</para>
	/// </summary>
	public class MonoBehaviour : Behaviour
	{
		public MonoBehaviour(IntPtr ptr) : base(ptr) { }

		public void StopAllCoroutines()
        {
			Instance_Class.GetMethod(nameof(StopAllCoroutines)).Invoke(this);
        }

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("MonoBehaviour", "UnityEngine");
	}
}
