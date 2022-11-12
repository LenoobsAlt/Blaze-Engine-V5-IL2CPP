using System;
using System.Linq;
using IL2CPP_Core.Objects;
using VRC.Core;
using VRC.DataModel.Interfaces;

namespace VRC
{

    public static class UserAPI
    {
        static UserAPI()
        {
            try
            {
                Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x =>
                    x.GetFields().Length == 1
                    && x.GetFields()[0].ReturnType.Name == typeof(string).FullName
                    && x.GetFields()[0].GetValue().GetValue<IL2String>()?.ToString() == "VRChat User"
                );
                if (Instance_Class == null)
                    "UserAPI::Instance_Class not found!".RedPrefix("Warning");
            }
            catch
            {
                "Catch UserAPI".RedPrefix("Exception");
            }
        }
        public static void ChangeAvatar(ApiAvatar apiAvatar, string typeChange = "CloneAvatar", ApiAvatar api = null)
        {
            IL2Method method = null;
            try
            {
                method = Instance_Class.GetMethod(nameof(ChangeAvatar));
            }
            catch { "ChangeAvatar::FirstTest".RedPrefix("Exception"); }
            try
            {
                if (method == null)
                    (method = Instance_Class.GetMethod(x => x.GetParameters().Length == 3
                    && x.GetParameters()[0].ReturnType.Name == x.GetParameters()[2].ReturnType.Name
                    && x.GetParameters()[0].ReturnType.Name == ApiAvatar.Instance_Class.FullName
                    )).Name = nameof(ChangeAvatar);
            }
            catch { "ChangeAvatar::Find".RedPrefix("Exception"); }
            try
            {
                method.Invoke(new IntPtr[] { apiAvatar == null ? IntPtr.Zero : apiAvatar.Pointer, typeChange == null ? IntPtr.Zero : new IL2String_utf8(typeChange).Pointer, api == null ? IntPtr.Zero : api.Pointer });
            }
            catch { "ChangeAvatar::Method".RedPrefix("Exception"); }
        }


        public static IL2Class Instance_Class;
    }
}
