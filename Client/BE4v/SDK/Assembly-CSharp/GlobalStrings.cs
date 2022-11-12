using System;
using IL2CPP_Core.Objects;

public class GlobalStrings : IL2Object
{
	public GlobalStrings(IntPtr ptr) : base(ptr) { }

	public static IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass("GlobalStrings");
}
