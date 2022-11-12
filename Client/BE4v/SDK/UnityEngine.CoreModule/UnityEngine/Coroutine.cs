using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public sealed class Coroutine : YieldInstruction
	{
		public Coroutine(IntPtr ptr) : base(ptr) { }

		unsafe public Coroutine() : base(IntPtr.Zero)
		{
			Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
			Instance_Class.GetMethod(".ctor").Invoke(Pointer);
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("Coroutine", "UnityEngine");
	}
}
