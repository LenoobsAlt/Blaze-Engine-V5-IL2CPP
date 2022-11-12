using System;
using IL2CPP_Core.Objects;

namespace IL2ExitGames.Client.Photon
{
    public class EventData : IL2Object
    {
        public EventData(IntPtr ptr) : base(ptr) { }

        public int Sender
        {
            get => Instance_Class.GetProperty(nameof(Sender)).GetGetMethod().Invoke<int>(this).GetValue();
        }
        
        public IL2Object CustomData
        {
            get => Instance_Class.GetProperty(nameof(CustomData)).GetGetMethod().Invoke(this);
        }
        
        public byte Code
        {
            get => Instance_Class.GetField(nameof(Code)).GetValue<byte>(this).GetValue();
        }

        public override string ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(this)?.GetValue<IL2String>().ToString();
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["Photon-DotNet"].GetClass("EventData", "ExitGames.Client.Photon");
    }
}