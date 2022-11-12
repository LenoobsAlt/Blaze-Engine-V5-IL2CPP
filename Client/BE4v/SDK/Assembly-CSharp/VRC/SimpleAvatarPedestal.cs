using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.Core;
using VRC.UI;

namespace VRC
{
    public class SimpleAvatarPedestal : MonoBehaviour
    {
        public SimpleAvatarPedestal(IntPtr ptr) : base(ptr) { }

        public SimpleAvatarPedestal() : base(IntPtr.Zero)
        {
            Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
            Instance_Class.GetMethod(".ctor").Invoke(Pointer);
        }
        public ApiAvatar apiAvatar
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(apiAvatar));
                if (field == null)
                    (field = Instance_Class.GetField(ApiAvatar.Instance_Class)).Name = nameof(apiAvatar);
                return field?.GetValue(this)?.GetValue<ApiAvatar>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(apiAvatar));
                if (field == null)
                    (field = Instance_Class.GetField(ApiAvatar.Instance_Class)).Name = nameof(apiAvatar);
                field?.SetValue(this, (value == null) ? IntPtr.Zero : value.Pointer);
            }
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass(PageAvatar.Instance_Class.GetFields().First().ReturnType.Name);
    }
}