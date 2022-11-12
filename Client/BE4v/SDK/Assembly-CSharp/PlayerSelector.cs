using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public PlayerSelector(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().First(
        x => 
        x.BaseType?.FullName == MonoBehaviour.Instance_Class.FullName &&
        x.GetMethod("Start")?.IsPrivate == true &&
        x.GetMethod("Update")?.IsPrivate == true &&
        x.GetField(Transform.Instance_Class)?.IsPrivate == true &&
        x.GetField(Renderer.Instance_Class)?.IsPrivate == true &&
        VRCPlayer.Instance_Class.GetFields().FirstOrDefault(y => y.ReturnType.Name == x.FullName) != null
        );
}
