using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class PortalInternal : MonoBehaviour
{
    public PortalInternal(IntPtr ptr) : base(ptr) { }

    unsafe public void SetTimerRPC(float timer, VRC.Player player)
    {
        Instance_Class.GetMethod(nameof(SetTimerRPC)).Invoke(this, new IntPtr[] { new IntPtr(&timer), player == null ? IntPtr.Zero : player.Pointer });
    }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("SetTimerRPC") != null);
}
