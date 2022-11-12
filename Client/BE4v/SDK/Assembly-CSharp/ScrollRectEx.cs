using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine.UI;

public class ScrollRectEx : ScrollRect
{
    public ScrollRectEx(IntPtr ptr) : base(ptr) { }

	public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetField("minimumSpeed")?.IsPrivate == true);
}