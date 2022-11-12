using System;
using System.Collections.Generic;
using IL2CPP_Core.Objects;

namespace IL2ExitGames.Client.Photon
{
    public class SupportClass : IL2Object
    {
        public SupportClass(IntPtr ptr) : base(ptr) { }

        public static string DictionaryToString(IL2Dictionary dictionary)
        {
            return Instance_Class.GetMethod(nameof(DictionaryToString), x => x.GetParameters().Length == 1).Invoke(new IntPtr[] { dictionary == null ? IntPtr.Zero : dictionary.Pointer })?.GetValue<IL2String>().ToString();
        }


        public static IL2Class Instance_Class = IL2CPP.AssemblyList["Photon-DotNet"].GetClass("SupportClass", "ExitGames.Client.Photon");
    }
}