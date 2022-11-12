using System;
using System.Linq;
using IL2CPP_Core.Objects;
using IL2ExitGames.Client.Photon;


namespace IL2Photon.Realtime
{
    public class LoadBalancingPeer : PhotonPeer
    {
        public LoadBalancingPeer(IntPtr ptr) : base(ptr) { }

        unsafe public bool OpRaiseEvent(byte eventCode, IntPtr customEventContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(OpRaiseEvent));
            if (method == null)
            {
                (method = Instance_Class.GetMethod(x => x.GetParameters().Length == 4
                && x.GetParameters()[0].ReturnType.Name == typeof(byte).FullName
                )).Name = nameof(OpRaiseEvent);
                if (method == null)
                {
                    "OpRaiseEvent: Not found".RedPrefix("WARN");
                    return default;
                }
            }
            return method.Invoke<bool>(this, new IntPtr[] { new IntPtr(&eventCode), customEventContent, raiseEventOptions.Pointer, new IntPtr(&sendOptions) }).GetValue();
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.BaseType == PhotonPeer.Instance_Class);
    }
}