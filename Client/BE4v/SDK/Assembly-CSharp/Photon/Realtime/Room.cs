using System;
using System.Linq;
using System.Collections.Generic;
using IL2CPP_Core.Objects;

namespace IL2Photon.Realtime
{
    public class Room : RoomInfo
    {
        public Room(IntPtr ptr) : base(ptr) { }
        static Room()
        {
            string sString = ConnectionHandler.Instance_Class.GetProperty("Client").OriginalName;
            Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetProperty(LoadBalancingClient.Instance_Class) != null && x.GetProperty(LoadBalancingClient.Instance_Class).OriginalName == sString);
        }

        public LoadBalancingClient LoadBalancingClient
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(LoadBalancingClient));
                if (property == null)
                    (property = Instance_Class.GetProperty(LoadBalancingClient.Instance_Class)).Name = nameof(LoadBalancingClient);
                return property?.GetGetMethod().Invoke(this)?.GetValue<LoadBalancingClient>();
            }
        }
        
        public IL2Dictionary<IL2Int32, Player> Players
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(Players));
                if (property == null)
                    (property = Instance_Class.GetProperty(IL2Dictionary<IL2Int32, Player>.Instance_Class)).Name = nameof(Players);
                return property?.GetGetMethod().Invoke(this)?.GetValue<IL2Dictionary<IL2Int32, Player>>();
            }
        }

        /*
        private static IL2Method methodSetMasterClient = null;
        public bool SetMasterClient(Player masterClientPlayer)
        {
            if (methodSetMasterClient == null)
            {
                methodSetMasterClient = Instance_Class.GetMethods().First(x => !x.IsStatic && x.IsPublic && x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == Player.Instance_Class.FullName && x.ReturnType.Name == typeof(bool).FullName);
                if (methodSetMasterClient == null)
                    return default;
            }
            return methodSetMasterClient.Invoke<bool>(this, new IntPtr[]{ masterClientPlayer.Pointer }).GetValue();
        }
        */

        public override string ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(this)?.GetValue<IL2String>().ToString();
        }

        public static new IL2Class Instance_Class;
    }
}