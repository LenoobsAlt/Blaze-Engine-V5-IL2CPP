using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class VRC_TriggerInternal : MonoBehaviour
{
    public VRC_TriggerInternal(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetField("hasColliderTriggers") != null);
}