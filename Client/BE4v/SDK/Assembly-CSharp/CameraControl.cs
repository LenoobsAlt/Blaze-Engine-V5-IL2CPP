using System;
using System.Linq;
using UnityEngine;
using IL2CPP_Core.Objects;

public class CameraControl : MonoBehaviour
{
    public CameraControl(IntPtr ptr) : base(ptr) { }

	public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetField("defaultCamera") != null);
}