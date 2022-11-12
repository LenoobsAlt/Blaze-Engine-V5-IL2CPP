using System;
using IL2CPP_Core.Objects;
using VRC.Core;
using IL2ExitGames.Client.Photon;


namespace IL2Photon.Realtime
{
    public class LoadBalancingClient : IL2Object
    {
        public LoadBalancingClient(IntPtr ptr) : base(ptr) { }

        static LoadBalancingClient()
        {
            // Find: OpRaiseEvent
            (Instance_Class?.GetMethod(x => x.IsPublic && x.GetParameters().Length == 4 && x.GetParameters()[0].ReturnType.Name == typeof(byte).FullName)).Name = "OpRaiseEvent";
        }

        public LoadBalancingPeer LoadBalancingPeer
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(LoadBalancingPeer));
                if (property == null)
                    (property = Instance_Class.GetProperty(LoadBalancingPeer.Instance_Class)).Name = nameof(LoadBalancingPeer);
                return property?.GetGetMethod()?.Invoke(this)?.GetValue<LoadBalancingPeer>();
            }
        }

        unsafe public bool OpRaiseEvent(byte eventCode, byte[] customEventContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions)
        {
            IL2Array<byte> content = null;
            if (customEventContent != null)
            {
                int len = customEventContent.Length;
                content = new IL2Array<byte>(len, IL2Byte.Instance_Class);
                for(int i=0;i< len;i++)
                    content[i] = customEventContent[i];
            }

            return OpRaiseEvent(eventCode, content == null ? IntPtr.Zero : content.Pointer, raiseEventOptions, sendOptions);
        }
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

        public static IL2Class Instance_Class = VRCNetworkingClient.Instance_Class.BaseType;
    }
}