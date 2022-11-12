using System;
using System.Linq;
using IL2CPP_Core.Objects;

public static class Vector3Extensions
{
    public static IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethods().Length == 2 && x.GetMethod(y => y.IsStatic && y.GetParameters().Length == 1 && y.GetParameters()[0].ReturnType.Name == "UnityEngine.Vector3") != null  && x.GetMethod(y => y.IsStatic && y.GetParameters().Length == 4 && y.GetParameters()[0].ReturnType.Name == "UnityEngine.Vector3") != null);
}