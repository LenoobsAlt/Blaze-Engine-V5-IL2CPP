using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public static class EAC_StaticClass
{
	static EAC_StaticClass()
    {
        Instance_Class = IL2CPP.AssemblyList["Epic.OnlineServices"].GetClasses().FirstOrDefault(x => x.GetMethods().Length < 6 && x.GetMethod(y => y.GetParameters().Length == 2 && y.GetParameters()[0].ReturnType.Name == EAC_TypeD.Instance_Class.FullName) != null);
        if (Instance_Class == null)
            "EAC Static not found!".RedPrefix("Debug");
    }

	public static IL2Class Instance_Class;
}