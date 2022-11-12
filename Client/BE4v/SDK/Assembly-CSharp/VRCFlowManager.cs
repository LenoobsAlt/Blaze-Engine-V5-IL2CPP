using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.Core;

public class VRCFlowManager : MonoBehaviour
{
    public VRCFlowManager(IntPtr ptr) : base(ptr) { }

    public static VRCFlowManager Instance
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(Instance));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
            return property?.GetGetMethod().Invoke()?.GetValue<VRCFlowManager>();
        }
    }
    
    public static ApiWorld DestinationWorld
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(DestinationWorld));
            if (property == null)
                (property = Instance_Class.GetProperty(ApiWorld.Instance_Class)).Name = nameof(DestinationWorld);
            return property?.GetGetMethod().Invoke()?.GetValue<ApiWorld>();
        }
    }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("OnApplicationPause") != null && x.GetProperty(ApiWorld.Instance_Class) != null);
}