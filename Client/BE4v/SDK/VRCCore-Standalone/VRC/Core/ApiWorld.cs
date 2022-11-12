using System;
using IL2CPP_Core.Objects;

namespace VRC.Core
{
    public class ApiWorld : ApiModel
    {
        public ApiWorld(IntPtr ptr) : base(ptr) { }

        public string currentInstanceIdWithTags
        {
            get => Instance_Class.GetField(nameof(currentInstanceIdWithTags)).GetValue(this)?.GetValue<IL2String>().ToString();
        }

        public string authorId
        {
            get => Instance_Class.GetProperty(nameof(authorId)).GetGetMethod().Invoke(this)?.GetValue<IL2String>().ToString();
            set => Instance_Class.GetProperty(nameof(authorId)).GetSetMethod().Invoke(this, new IntPtr[] { new IL2String_utf8(value).Pointer });
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRCCore-Standalone"].GetClass("ApiWorld", "VRC.Core");
    }
}