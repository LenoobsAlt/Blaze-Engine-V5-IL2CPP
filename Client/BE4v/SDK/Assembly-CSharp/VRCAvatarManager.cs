using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.Core;
using VRC.SDK3.Avatars.Components;

public class VRCAvatarManager : MonoBehaviour
{
    public VRCAvatarManager(IntPtr ptr) : base(ptr) { }

    static VRCAvatarManager()
    {
        // void ShowImage(ApiAvatar apiAvatar)
        try
        {
            Instance_Class.GetMethod(x => x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == ApiAvatar.Instance_Class.FullName).Name = nameof(ShowImage);
        }
        catch { "Function not found".RedPrefix("VRCAvatarManager::ShowImage"); }
    }

    public VRCAvatarDescriptor currentAvatarDescriptorSDK3
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(currentAvatarDescriptorSDK3));
            if (property == null)
                (property = Instance_Class.GetProperty(VRCAvatarDescriptor.Instance_Class)).Name = nameof(currentAvatarDescriptorSDK3);
            return property?.GetGetMethod().Invoke(this)?.GetValue<VRCAvatarDescriptor>();
        }
    }

    public void ShowImage(ApiAvatar apiAvatar)
    {
        Instance_Class.GetMethod(nameof(ShowImage)).Invoke(this, new IntPtr[] { apiAvatar == null ? IntPtr.Zero : apiAvatar.Pointer });
    }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().First(x => x.GetProperty(VRCAvatarDescriptor.Instance_Class) != null);
}
