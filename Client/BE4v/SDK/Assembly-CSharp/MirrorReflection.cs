using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class MirrorReflection : MonoBehaviour
{
	public MirrorReflection(IntPtr ptr) : base(ptr) { }

	unsafe public LayerMask m_ReflectLayers
	{
		get
		{
			IL2Field field = Instance_Class.GetField(nameof(m_ReflectLayers));
			if (field == null)
				(field = Instance_Class.GetField(x => x.ReturnType.Name == "UnityEngine.LayerMask")).Name = nameof(m_ReflectLayers);
			return field.GetValue<LayerMask>(this).GetValue();
		}
		set
		{
			IL2Field field = Instance_Class.GetField(nameof(m_ReflectLayers));
			if (field == null)
				(field = Instance_Class.GetField(x => x.ReturnType.Name == "UnityEngine.LayerMask")).Name = nameof(m_ReflectLayers);
			field.SetValue(this, new IntPtr(&value));
		}
	}
	
	public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("OnWillRenderObject") != null);
}