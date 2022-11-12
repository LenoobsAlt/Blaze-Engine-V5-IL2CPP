using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class ObjectInstantiatorHandle : MonoBehaviour
{
	public ObjectInstantiatorHandle(IntPtr ptr) : base(ptr) { }
	/*
	public ObjectInstantiator Instantiator
	{
		get
		{
			IL2Field field = Instance_Class.GetField(nameof(Instantiator));
			if (field == null)
				(field = Instance_Class.GetField(x => x.ReturnType.Name == ObjectInstantiator.Instance_Class.FullName)).Name = nameof(Instantiator); ;
			return field?.GetValue(ptr)?.GetValue<ObjectInstantiator>();
		}
		set
		{
			IL2Field field = Instance_Class.GetField(nameof(Instantiator));
			if (field == null)
				(field = Instance_Class.GetField(x => x.ReturnType.Name == ObjectInstantiator.Instance_Class.FullName)).Name = nameof(Instantiator);
			field?.SetValue(ptr, value.ptr);
		}
	}
	*/
	unsafe public int? LocalID
	{
		get
		{
			IL2Field field = Instance_Class.GetField(nameof(LocalID));
			if (field == null)
				(field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(int?).FullName)).Name = nameof(LocalID);

			return field.GetValue<int>(this)?.GetValue();
		}
		set
		{
			IL2Field field = Instance_Class.GetField(nameof(LocalID));
			if (field == null)
				(field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(int?).FullName)).Name = nameof(LocalID);
			IntPtr val = IntPtr.Zero;
			if (value != null)
            {
				int iValue = (int)value;
				val = new IntPtr(&iValue);
            }
			field.SetValue(this, val);
		}
	}

	public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("ReapObject") != null);
}
