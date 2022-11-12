using System;
using IL2CPP_Core.Objects;

namespace VRC.Core
{
    public class ApiAvatar : ApiModel
    {
        public ApiAvatar(IntPtr ptr) : base(ptr) { }

        public ApiAvatar() : base(IntPtr.Zero)
        {
            Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
            Instance_Class.GetMethod(".ctor").Invoke(Pointer);
        }

        public string releaseStatus
		{
            get => Instance_Class.GetProperty(nameof(releaseStatus)).GetGetMethod().Invoke(this)?.GetValue<IL2String>().ToString();
            set => Instance_Class.GetProperty(nameof(releaseStatus)).GetSetMethod().Invoke(this, new IntPtr[] { new IL2String_utf8(value).Pointer });
		}

        public string authorId
        {
            get => Instance_Class.GetProperty(nameof(authorId)).GetGetMethod().Invoke(this)?.GetValue<IL2String>().ToString();
            set => Instance_Class.GetProperty(nameof(authorId)).GetSetMethod().Invoke(this, new IntPtr[] { new IL2String_utf8(value).Pointer});
        }

        public string assetUrl
        {
            get => Instance_Class.GetProperty(nameof(assetUrl)).GetGetMethod().Invoke(this)?.GetValue<IL2String>().ToString();
            set => Instance_Class.GetProperty(nameof(assetUrl)).GetSetMethod().Invoke(this, new IntPtr[] { new IL2String_utf8(value).Pointer });
        }

        public string name
        {
            get => Instance_Class.GetProperty(nameof(name)).GetGetMethod().Invoke(this)?.GetValue<IL2String>().ToString();
            set => Instance_Class.GetProperty(nameof(name)).GetSetMethod().Invoke(this, new IntPtr[] { new IL2String_utf16(value).Pointer });
        }

        public void SaveReleaseStatus(Action<ApiContainer> onSuccess = null, Action<ApiContainer> onFailure = null)
        {
            IntPtr ptrSucc = IntPtr.Zero;
            /*
            if (onSuccess != null)
                ptrSucc = UnityEngine.Events._UnityAction.CreateDelegate(onSuccess, IntPtr.Zero, BlazeTools.IL2SystemClass.action_1);
            */
            IntPtr ptrFail = IntPtr.Zero;
            /*
            if (onFailure != null)
                ptrFail = UnityEngine.Events._UnityAction.CreateDelegate(onFailure, IntPtr.Zero, BlazeTools.IL2SystemClass.action_1);
            */
            Instance_Class.GetMethod(nameof(SaveReleaseStatus)).Invoke(this, new IntPtr[] { ptrSucc, ptrFail });
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRCCore-Standalone"].GetClass("ApiAvatar", "VRC.Core");
    }
}
