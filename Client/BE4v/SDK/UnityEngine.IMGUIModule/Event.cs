using System;
using IL2CPP_Core.Objects;

namespace UnityEngine
{
	public sealed class Event : IL2Object
	{
		public Event(IntPtr ptr) : base(ptr) { }
		public static Event current
		{
			get => Instance_Class.GetProperty(nameof(current)).GetGetMethod().Invoke()?.GetValue<Event>();
			set => Instance_Class.GetProperty(nameof(current)).GetSetMethod().Invoke(new IntPtr[] { value == null ? IntPtr.Zero : value.Pointer });
		}

		unsafe public EventType type
		{
			get => Instance_Class.GetProperty(nameof(type)).GetGetMethod().Invoke<EventType>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(type)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["UnityEngine.IMGUIModule"].GetClass("Event", "UnityEngine");
	}
}
