using System;
using System.Linq;
using IL2CPP_Core.Objects;

public class SyncPhysics : VRCNetworkBehaviour
{
    public SyncPhysics(IntPtr ptr) : base(ptr) { }

    static SyncPhysics()
    {
        Instance_Class.GetMethod(x => x.GetParameters().Length == 3 && x.GetParameters()[1].ReturnType.Name == typeof(float).FullName).Name = "ApplyEvent";
    }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("EnableKinematic") != null);
}