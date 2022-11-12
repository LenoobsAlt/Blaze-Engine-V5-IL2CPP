using System;
using System.Collections.Generic;
using IL2CPP_Core.Objects;

namespace VRC.Core
{
    public static class API
    {
        unsafe public static T FromCacheOrNew<T>(string id, float maxCacheAge = -1f) where T : ApiModel, new()
        {
            IL2Method method = Instance_Class.GetMethod(nameof(FromCacheOrNew));
            return method.Invoke(new IntPtr[] { id == null ? IntPtr.Zero : new IL2String_utf8(id).Pointer, new IntPtr(&maxCacheAge), method.Pointer }).GetValue<T>();
        }

        public class CredentialsBundle : IL2Object
        {
            public CredentialsBundle(IntPtr ptr) : base(ptr) { }

            public string username
            {
                get => Instance_Class.GetField(nameof(username)).GetValue(this)?.GetValue<IL2String>().ToString();
                set => Instance_Class.GetField(nameof(username)).SetValue(this, new IL2String_utf16(value).Pointer);
            }

            public string password
            {
                get => Instance_Class.GetField(nameof(password)).GetValue(this)?.GetValue<IL2String>().ToString();
                set => Instance_Class.GetField(nameof(password)).SetValue(this, new IL2String_utf16(value).Pointer);
            }

            public static IL2Class Instance_Class = API.Instance_Class.GetNestedType("CredentialsBundle");
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["VRCCore-Standalone"].GetClass("API", "VRC.Core");
    }
}
