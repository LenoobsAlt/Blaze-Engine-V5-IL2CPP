using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class UiSettingConfig : MonoBehaviour
{
    public UiSettingConfig(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("SetEnable")?.GetParameters()[0].Name == "on" && x.GetMethod("SetValue") != null);
}