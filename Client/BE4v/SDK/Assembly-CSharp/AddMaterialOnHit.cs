using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class AddMaterialOnHit : MonoBehaviour
{
    public AddMaterialOnHit(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethods(y => y.Name == "UpdateMaterial").Length == 2);
}