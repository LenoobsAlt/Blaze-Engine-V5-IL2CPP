using System;
using System.Linq;
using IL2CPP_Core.Objects;
using VRC.SDKBase;

public class VRC_EventDispatcherRFC : VRC_EventDispatcher
{
    public VRC_EventDispatcherRFC(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.BaseType == VRC_EventDispatcher.Instance_Class);
}