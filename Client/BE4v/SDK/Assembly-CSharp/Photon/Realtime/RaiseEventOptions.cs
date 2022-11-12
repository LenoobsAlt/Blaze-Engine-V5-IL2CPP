using System;
using IL2CPP_Core.Objects;

namespace IL2Photon.Realtime
{
    public class RaiseEventOptions : IL2Object
    {
        public RaiseEventOptions(IntPtr ptr) : base(ptr) { }

        public RaiseEventOptions() : base(IntPtr.Zero)
        {
            Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
            Instance_Class.GetMethod(".ctor").Invoke(Pointer);
        }

        unsafe public EventCaching CachingOption
        {
            get => Instance_Class.GetField(x => x.Token == 0x10).GetValue<EventCaching>(this).GetValue();
            set => Instance_Class.GetField(x => x.Token == 0x10).SetValue(this, new IntPtr(&value));
        }
        
        unsafe public byte InterestGroup
        {
            get => Instance_Class.GetField(x => x.Token == 0x11).GetValue<byte>(this).GetValue();
            set => Instance_Class.GetField(x => x.Token == 0x11).SetValue(this, new IntPtr(&value));
        }

        public int[] TargetActors
        {
            get
            {
                IL2Object result = Instance_Class.GetField(x => x.Token == 0x18).GetValue(this);
                if (result == null)
                    return null;

                return new IL2Array<int>(result.Pointer).ToArray();
            }
            set
            {
                IL2Array<int> array = null;
                if (value != null)
                {
                    int len = value.Length;
                    array = new IL2Array<int>(len, IL2Int32.Instance_Class);
                    for (int i = 0; i < len; i++)
                    {
                        array[i] = value[i];
                    }
                }
                Instance_Class.GetField(x => x.Token == 0x18).SetValue(this, array == null ? IntPtr.Zero : array.Pointer);
            }
        }
        
        unsafe public ReceiverGroup Receivers
        {
            get => Instance_Class.GetField(x => x.Token == 0x20).GetValue<ReceiverGroup>(this).GetValue();
            set => Instance_Class.GetField(x => x.Token == 0x20).SetValue(this, new IntPtr(&value));
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass(LoadBalancingClient.Instance_Class?.GetMethod("OpRaiseEvent").GetParameters()[2].ReturnType.Name);
    }
}
