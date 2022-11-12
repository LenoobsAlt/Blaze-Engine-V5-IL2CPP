using System;
using IL2CPP_Core.Objects;

namespace System.Net
{
    public class IL2WebRequest : IL2Object
    {
        public IL2WebRequest(IntPtr ptr) : base(ptr) { }

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["System"].GetClass("WebRequest", "System.Net");
    }
}
