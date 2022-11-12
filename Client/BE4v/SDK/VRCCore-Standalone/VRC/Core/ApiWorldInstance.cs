using System;
using IL2CPP_Core.Objects;

namespace VRC.Core
{
    public class ApiWorldInstance : IL2Object
    {
        public ApiWorldInstance(IntPtr ptr) : base(ptr) { }

        unsafe public ApiWorldInstance(ApiWorld world, string _idWithTags, int _count) : base(IntPtr.Zero)
        {
            Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
            Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 3 && x.GetParameters()[2].Name == "_count").Invoke(Pointer, new IntPtr[] { world.Pointer, new IL2String_utf16(_idWithTags).Pointer, new IntPtr(&_count) });
        }

        public string GetInstanceCreator()
        {
            return Instance_Class.GetMethod(nameof(GetInstanceCreator)).Invoke(this)?.GetValue<IL2String>().ToString();
        }

        public ApiWorld instanceWorld
        {
            get => Instance_Class.GetField(nameof(instanceWorld)).GetValue(this)?.GetValue<ApiWorld>();
        }

        public string idWithTags
        {
            get => Instance_Class.GetField(nameof(idWithTags)).GetValue(this)?.GetValue<IL2String>().ToString();
        }

        public string ownerId
        {
            get => Instance_Class.GetProperty(nameof(ownerId)).GetGetMethod().Invoke(this)?.GetValue<IL2String>().ToString();
            set => Instance_Class.GetProperty(nameof(ownerId)).GetSetMethod().Invoke(this, new IntPtr[] { new IL2String_utf8(value).Pointer });
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["VRCCore-Standalone"].GetClass("ApiWorldInstance", "VRC.Core");

        public enum AccessType
        {
            Public,
            FriendsOfGuests,
            FriendsOnly,
            InviteOnly,
            InvitePlus,
            Counter
        }
    }
}