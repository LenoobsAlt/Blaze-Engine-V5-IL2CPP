using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class VRCApplicationSetup : MonoBehaviour
{
    public VRCApplicationSetup(IntPtr ptr) : base(ptr) { }

    public static VRCApplicationSetup Instance
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(Instance));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
            return property?.GetGetMethod().Invoke()?.GetValue<VRCApplicationSetup>();
        }
    }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetField(y => y.ReturnType.Name == "VRC.Core.ApiServerEnvironment") != null);
}