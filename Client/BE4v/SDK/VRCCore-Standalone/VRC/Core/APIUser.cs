using System;
using System.Linq;
using System.Collections.Generic;
using IL2CPP_Core.Objects;


namespace VRC.Core
{
    public class APIUser : ApiModel
    {
        public APIUser(IntPtr ptr) : base(ptr) { }

        public static APIUser CurrentUser
        {
            get => Instance_Class.GetProperty(nameof(CurrentUser)).GetGetMethod().Invoke()?.GetValue<APIUser>();
        }

        public static bool IsFriendsWith(string userId) => IsFriendsWith(new IL2String_utf8(userId));
        public static bool IsFriendsWith(IL2String userId)
        {
            return Instance_Class.GetMethod(nameof(IsFriendsWith)).Invoke<bool>(new IntPtr[] { userId.Pointer }).GetValue();
        }

        public bool HasTag(string tag) => HasTag(new IL2String_utf8(tag));
        public bool HasTag(IL2String tag)
        {
            return Instance_Class.GetMethod(nameof(HasTag)).Invoke<bool>(this, new IntPtr[] { tag.Pointer }).GetValue();
        }

        public string username
        {
            get => Instance_Class.GetProperty(nameof(username)).GetGetMethod().Invoke(this)?.GetValue<IL2String>().ToString();
        }

        public string displayName
        {
            get => Instance_Class.GetProperty(nameof(displayName)).GetGetMethod().Invoke(this)?.GetValue<IL2String>().ToString();
        }

        public string[] tags
        {
            get
            {
                IL2Object result = Instance_Class.GetProperty(nameof(tags)).GetGetMethod().Invoke(this);
                if (result == null)
                    return null;
                return new IL2ListObject<IL2String>(result.Pointer).ToArray().Select(x => x.ToString()).ToArray();
            }
        }
        
        public bool hasVIPAccess
        {
            get => Instance_Class.GetProperty(nameof(hasVIPAccess)).GetGetMethod().Invoke<bool>(this).GetValue();
        }

        unsafe public bool allowAvatarCopying
        {
            get => Instance_Class.GetProperty(nameof(allowAvatarCopying)).GetGetMethod().Invoke<bool>(this).GetValue();
            set => Instance_Class.GetProperty(nameof(allowAvatarCopying)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
        }

        public bool hasModerationPowers
        {
            get => Instance_Class.GetProperty(nameof(hasModerationPowers)).GetGetMethod().Invoke<bool>(this).GetValue();
        }
        
        public bool hasScriptingAccess
        {
            get => Instance_Class.GetProperty(nameof(hasScriptingAccess)).GetGetMethod().Invoke<bool>(this).GetValue();
        }

        public bool hasKnownTrustLevel
        {
            get => Instance_Class.GetProperty(nameof(hasKnownTrustLevel)).GetGetMethod().Invoke<bool>(this).GetValue();
        }

        public bool hasVeteranTrustLevel
        {
            get => Instance_Class.GetProperty(nameof(hasVeteranTrustLevel)).GetGetMethod().Invoke<bool>(this).GetValue();
        }

        public bool hasTrustedTrustLevel
        {
            get => Instance_Class.GetProperty(nameof(hasTrustedTrustLevel)).GetGetMethod().Invoke<bool>(this).GetValue();
        }

        public bool hasBasicTrustLevel
        {
            get => Instance_Class.GetProperty(nameof(hasBasicTrustLevel)).GetGetMethod().Invoke<bool>(this).GetValue();
        }

        public bool hasNegativeTrustLevel
        {
            get => Instance_Class.GetProperty(nameof(hasNegativeTrustLevel)).GetGetMethod().Invoke<bool>(this).GetValue();
        }

        public string location
        {
            get => Instance_Class.GetProperty(nameof(location)).GetGetMethod().Invoke(this)?.GetValue<IL2String>().ToString();
        }

        public string avatarId
        {
            get => Instance_Class.GetProperty(nameof(avatarId)).GetGetMethod().Invoke(this)?.GetValue<IL2String>().ToString();
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRCCore-Standalone"].GetClass("APIUser", "VRC.Core");
    }
}