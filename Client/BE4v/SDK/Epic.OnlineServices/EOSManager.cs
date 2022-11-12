using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public static class EOSManager
{
	static EOSManager()
    {
        Instance_Class = IL2CPP.AssemblyList["Epic.OnlineServices"].GetClasses().FirstOrDefault(x => 1 == 1 /* ??? */);
        if (Instance_Class == null)
            "Instance_Class not found!".RedPrefix("EOSManager");
    }

	public static IL2Class Instance_Class;
}