using System;
using System.Runtime.InteropServices;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public class YieldInstruction : IL2Object
	{
		public YieldInstruction(IntPtr ptr) : base(ptr) { }

		unsafe public YieldInstruction() : base(IntPtr.Zero)
		{
			Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
			Instance_Class.GetMethod(".ctor").Invoke(Pointer);
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("YieldInstruction", "UnityEngine");
	}
}
