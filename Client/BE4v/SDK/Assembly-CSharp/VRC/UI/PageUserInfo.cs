using System;
using System.Linq;
using UnityEngine;
using IL2CPP_Core.Objects;
using VRC.Core;

namespace VRC.UI
{
    public class PageUserInfo : VRCUiPage
    {
        public PageUserInfo(IntPtr ptr) : base(ptr) { }

        public PageUserInfo() : base(IntPtr.Zero)
        {
            Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
            Instance_Class.GetMethod(".ctor").Invoke(Pointer);
        }

        public APIUser user
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(user));
                if (field == null)
                    (field = Instance_Class.GetField(APIUser.Instance_Class)).Name = nameof(user);
                return field.GetValue(Pointer)?.GetValue<APIUser>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(user));
                if (field == null)
                {
                    (field = Instance_Class.GetField(APIUser.Instance_Class)).Name = nameof(user);
                    if (field == null)
                        return;
                }
                field.SetValue(this, value == null ? IntPtr.Zero : value.Pointer);
            }
        }

        public static PageUserInfo Instance
        {
            get => VRCUiManager.GetPage<PageUserInfo>(userInfoScreenPath);
        }

        private static string szUserInfoScreenPath = null;
        public static string userInfoScreenPath
        {
            get
            {
                if (szUserInfoScreenPath == null)
                {
                    PageUserInfo[] components = Resources.FindObjectsOfTypeAll<PageUserInfo>();
                    PageUserInfo component = components.FirstOrDefault();
                    if (component != null)
                    {
                        Transform parent = component.transform;
                        szUserInfoScreenPath = parent.gameObject.name;
                        while (parent.parent != null)
                        {
                            parent = parent.parent;
                            szUserInfoScreenPath = parent.gameObject.name + "/" + szUserInfoScreenPath;
                        }
                    }
                }
                return szUserInfoScreenPath;
            }
        }

        public void InitiateVoteToKick()
        {
            Instance_Class.GetMethod(nameof(InitiateVoteToKick)).Invoke(this);
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("RequestInvitation") != null);
    }
}
