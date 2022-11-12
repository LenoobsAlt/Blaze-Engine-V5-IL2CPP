using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class FadeCycleEffect : MonoBehaviour
{
	public FadeCycleEffect(IntPtr ptr) : base(ptr) { }

	unsafe public float speed
	{
		get => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(float).FullName)[0].GetValue<float>(this).GetValue();
		set => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(float).FullName)[0].SetValue(this, new IntPtr(&value));
	}

	unsafe public float minAlpha
	{
		get => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(float).FullName)[1].GetValue<float>(this).GetValue();
		set => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(float).FullName)[1].SetValue(this, new IntPtr(&value));
	}
	
	unsafe public float maxAlpha
	{
		get => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(float).FullName)[2].GetValue<float>(this).GetValue();
		set => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(float).FullName)[2].SetValue(this, new IntPtr(&value));
	}
	
	public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses()
		.FirstOrDefault(
			x =>
			x.GetMethod("Start") != null &&
			x.GetMethod("Update") != null &&
			x.GetFields().Length == 4 &&
			x.GetFields(y => y.ReturnType.Name == typeof(float).FullName).Length == 3 &&
			x.GetFields(y => y.ReturnType.Name == UnityEngine.UI.Image.Instance_Class.FullName).Length == 1
		);
}
