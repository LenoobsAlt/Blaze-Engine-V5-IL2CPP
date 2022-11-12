using System;
using System.Collections.Generic;
using IL2CPP_Core.Objects;

namespace Transmtn.DTO.Notifications
{
	public sealed class NotificationDetails : IL2Dictionary<IL2String, IL2String>
	{
		public NotificationDetails() : base(IntPtr.Zero)
		{
			Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
			Instance_Class.GetMethod(".ctor").Invoke(Pointer);
		}

		public NotificationDetails(IntPtr ptr) : base(ptr) { }

		public override string ToString()
		{
			return Instance_Class.GetMethod(nameof(ToString)).Invoke(this)?.GetValue<IL2String>().ToString();
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Transmtn"].GetClass("NotificationDetails", "Transmtn.DTO.Notifications");
	}
}
