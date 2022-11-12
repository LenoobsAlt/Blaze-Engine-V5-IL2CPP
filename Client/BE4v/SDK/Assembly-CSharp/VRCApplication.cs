using System;
using UnityEngine;
using IL2CPP_Core.Objects;
using System.Linq;

public class VRCApplication : MonoBehaviour
{
    public VRCApplication(IntPtr ptr) : base(ptr) { }

    public static VRCApplication Instance
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(Instance));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
            return property?.GetGetMethod().Invoke()?.GetValue<VRCApplication>();
        }
    }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().Where(x => x.GetMethod("OnApplicationQuit", y => y.IsPrivate) != null && x.GetMethod("OnApplicationPause", y => y.IsPrivate) != null).FirstOrDefault(x => x.GetProperties(y => y.Instance).Length == 1);
}
