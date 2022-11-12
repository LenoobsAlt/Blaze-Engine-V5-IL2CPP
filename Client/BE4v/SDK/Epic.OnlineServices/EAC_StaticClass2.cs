using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public static class EAC_StaticClass2
{
	static EAC_StaticClass2()
    {
        Instance_Class = IL2CPP.AssemblyList["Epic.OnlineServices"].GetClasses().FirstOrDefault(x => x.Token == 0x20005E2);
        if (Instance_Class == null)
            "EAC Static 2 not found!".RedPrefix("Debug");
    }

	public static IL2Class Instance_Class;
}