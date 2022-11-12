using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class InteractivePlayer : MonoBehaviour
{
    public InteractivePlayer(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetFields().Length == 2 && x.GetFields()[0].ReturnType.Name == x.GetFields()[1].ReturnType.Name && x.GetMethod("Awake") != null && x.GetMethod("Update") != null);
}
