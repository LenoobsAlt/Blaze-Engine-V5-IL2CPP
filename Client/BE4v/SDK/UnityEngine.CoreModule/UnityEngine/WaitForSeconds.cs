using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public class WaitForSeconds : YieldInstruction
	{
		public WaitForSeconds(IntPtr ptr) : base(ptr) { }

		unsafe public WaitForSeconds(float seconds) : base(IntPtr.Zero)
		{
			Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
			Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 1).Invoke(Pointer, new IntPtr[] { new IntPtr(&seconds) });
		}

		unsafe public float m_Seconds
        {
			get => Instance_Class.GetField(nameof(m_Seconds)).GetValue<float>(this).GetValue();
			set => Instance_Class.GetField(nameof(m_Seconds)).SetValue(this, new IntPtr(&value));
        }

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.CoreModule"].GetClass("WaitForSeconds", "UnityEngine");
	}
}
