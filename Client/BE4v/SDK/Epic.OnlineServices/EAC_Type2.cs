using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class EAC_Type2D
{
	public static IL2Class Instance_Class = IL2CPP.AssemblyList["Epic.OnlineServices"].GetClasses().FirstOrDefault(x => x.GetField(y => y.Name == "VeryVerbose") != null);
}

public enum EAC_Type2
{
	Off,
	Fatal = 100,
	Error = 200,
	Warning = 300,
	Info = 400,
	Verbose = 500,
	VeryVerbose = 600
}
