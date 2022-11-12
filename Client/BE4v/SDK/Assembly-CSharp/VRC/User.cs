using System;
using System.Linq;
using IL2CPP_Core.Objects;
using VRC.Core;
using VRC.DataModel.Interfaces;

namespace VRC
{
    public class User : APIUser, IUser
    {
        public User(IntPtr ptr) : base(ptr) { }


        public string UserId
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(UserId));
                if (property == null)
                    (property = Instance_Class.GetProperty(ClassIUser.UserId.OriginalName)).Name = nameof(UserId);
                if (property == null)
                    "User::UserId{ get; set} not found!".RedPrefix("Warning");
                return property.GetGetMethod().Invoke(this)?.GetValue<IL2String>().ToString();
            }
            set
            {
                IL2Property property = Instance_Class.GetProperty(nameof(UserId));
                if (property == null)
                    (property = Instance_Class.GetProperty(ClassIUser.UserId.OriginalName)).Name = nameof(UserId);
                if (property == null)
                    "User::UserId{ get; set} not found!".RedPrefix("Warning");
                property.GetSetMethod().Invoke(this, new IntPtr[] { value == null ? IntPtr.Zero : new IL2String_utf8(value).Pointer });
            }
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetInterfaceType(ClassIUser.Instance_Class.FullName) != null);
    }
}
