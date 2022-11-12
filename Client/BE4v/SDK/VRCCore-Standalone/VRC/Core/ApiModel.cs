using System;
using System.Collections.Generic;
using IL2CPP_Core.Objects;

namespace VRC.Core
{
    public class ApiModel : IL2Object
    {
        public ApiModel(IntPtr ptr) : base(ptr) { }

        public string id
        {
            get => Instance_Class.GetProperty(nameof(id)).GetGetMethod().Invoke(this)?.GetValue<IL2String>().ToString();
            set => Instance_Class.GetProperty(nameof(id)).GetSetMethod().Invoke(this, new IntPtr[] { new IL2String_utf8(value).Pointer });
        }    
    
        public bool Populated
        {
            get => Instance_Class.GetProperty(nameof(Populated)).GetGetMethod().Invoke<bool>(this).GetValue();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="onSuccess">Action "ApiContainer"</param>
        /// <param name="onFailure">Action "ApiContainer"</param>
        /// <param name="parameters"></param>
        /// <param name="disableCache"></param>
        unsafe public void Fetch(Action<IntPtr> onSuccess = null, Action<IntPtr> onFailure = null, Dictionary<string, object> parameters = null, bool disableCache = false)
        {
            IntPtr ptrSuccess = IntPtr.Zero;
            //if (onSuccess != null)
            //    ptrSuccess = _UnityAction.CreateDelegate(onSuccess, IntPtr.Zero, .action_1);
            IntPtr ptrFailure = IntPtr.Zero;
            //if (onFailure != null)
            //    ptrFailure = _UnityAction.CreateDelegate(onFailure, IntPtr.Zero, BlazeTools.IL2SystemClass.action_1);

            Instance_Class.GetMethod(nameof(Fetch)).Invoke(this, new IntPtr[] { ptrSuccess, ptrFailure, IntPtr.Zero, new IntPtr(&disableCache) });
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["VRCCore-Standalone"].GetClass("ApiModel", "VRC.Core");
    }
}