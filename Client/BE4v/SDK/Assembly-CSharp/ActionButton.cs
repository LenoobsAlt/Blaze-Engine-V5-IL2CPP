using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class ActionButton : MonoBehaviour
{
    public ActionButton(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("ActionButton") != null && x.GetMethod("OnEnable") != null);
}