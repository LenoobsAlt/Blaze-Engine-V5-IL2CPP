using System;
using IL2CPP_Core.Objects;
// using IL2ExitGames.Client.Photon;

namespace IL2Photon.Realtime
{

    public class RoomInfo : IL2Object
    {
        public RoomInfo(IntPtr ptr) : base(ptr) { }

        /*
        public Hashtable CustomProperties
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(CustomProperties));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == Hashtable.Instance_Class.FullName)).Name = nameof(CustomProperties);
                return property?.GetGetMethod().Invoke(ptr)?.GetValuå<Hashtable>();
            }
        }
        */
        public override string ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(this)?.GetValue<IL2String>().ToString();
        }

        public static IL2Class Instance_Class = Room.Instance_Class.BaseType;
    }
}