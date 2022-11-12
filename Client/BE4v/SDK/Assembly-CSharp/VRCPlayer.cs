using System;
using System.Linq;
using System.Collections.Generic;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC;
using VRC.Core;

public class VRCPlayer : VRCNetworkBehaviour
{
    public VRCPlayer(IntPtr ptr) : base(ptr) { }

    static VRCPlayer()
    {
        Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass(VRC.Player.Instance_Class.GetField("_vrcplayer").ReturnType.Name);

        try
        {
            // void LoadAvatar(ApiAvatar a)
            Instance_Class.GetMethod(x => x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == ApiAvatar.Instance_Class.FullName).Name = nameof(LoadAvatar);
        }
        catch { "LoadAvatar(ApiAvatar a) not found!".RedPrefix("VRCPlayer"); }

        try
        {
            // void LoadAvatar(bool forceLoad = false)
            Instance_Class.GetMethod(x => x.Name == Instance_Class.GetMethod(nameof(LoadAvatar)).OriginalName).Name = nameof(LoadAvatar);
        }
        catch { "LoadAvatar(bool forceLoad = false) not found!".RedPrefix("VRCPlayer"); }
    }

    // <!---------- ---------- ---------->
    // <!---------- PROPERTY'S ---------->
    // <!---------- ---------- ---------->
    public Player player
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(player));
            if (property == null)
                (property = Instance_Class.GetProperty(Player.Instance_Class)).Name = nameof(player);
            return property?.GetGetMethod().Invoke(this)?.GetValue<Player>();
        }
    }
    public int actor_id
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(actor_id));
            if (property == null)
            {
                (property = Instance_Class.GetProperties(x => x.GetGetMethod().ReturnType.Name == typeof(int).FullName).Skip(1).FirstOrDefault()).Name = nameof(actor_id);
                if (property == null)
                    return default;
            }
            return property.GetGetMethod().Invoke<int>(this).GetValue();
        }
    }

    public ApiAvatar AvatarModel
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(AvatarModel));
            if (property == null)
                (property = Instance_Class.GetProperty(ApiAvatar.Instance_Class)).Name = nameof(AvatarModel);
            return property?.GetGetMethod().Invoke(this)?.GetValue<ApiAvatar>();
        }
    }

    public PlayerNet playerNet
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(playerNet));
            if (property == null)
                (property = Instance_Class.GetProperty(PlayerNet.Instance_Class)).Name = nameof(playerNet);
            return property.GetGetMethod().Invoke(this)?.GetValue<PlayerNet>();
        }
    }
    
    public VRCAvatarManager AvatarManager
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(AvatarManager));
            if (property == null)
                (property = Instance_Class.GetProperty(VRCAvatarManager.Instance_Class)).Name = nameof(AvatarManager);
            return property.GetGetMethod().Invoke(this)?.GetValue<VRCAvatarManager>();
        }
    }

    public USpeaker uSpeaker
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(uSpeaker));
            if (property == null)
                (property = Instance_Class.GetProperty(USpeaker.Instance_Class)).Name = nameof(uSpeaker);
            return property?.GetGetMethod().Invoke(this)?.GetValue<USpeaker>();
        }
    }
    /*

    // * ulong (naverno steamid)
    // * PlayerAudioManager


    public VRCPlayerApi apiPlayer
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(apiPlayer));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == VRCPlayerApi.Instance_Class.FullName)).Name = nameof(apiPlayer);
            return property?.GetGetMethod().Invoke(ptr)?.unbox<VRCPlayerApi>();
        }
    }

    */
    // <!---------- ------- ---------->
    // <!---------- FIELD'S ---------->
    // <!---------- ------- ---------->
    public static VRCPlayer Instance
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(Instance));
            if (field == null)
                (field = Instance_Class.GetField(x => x.Instance)).Name = nameof(Instance);
            return field.GetValue()?.GetValue<VRCPlayer>();
        }
    }

    public void LoadAvatar(ApiAvatar a)
    {
        Instance_Class.GetMethod(nameof(LoadAvatar), x => x.GetParameters()[0].ReturnType.Name != typeof(bool).FullName).Invoke(this, new IntPtr[] { a == null ? IntPtr.Zero : a.Pointer });
    }

    unsafe public void LoadAvatar(bool forceLoad = false)
    {
        Instance_Class.GetMethod(nameof(LoadAvatar), x => x.GetParameters()[0].ReturnType.Name == typeof(bool).FullName).Invoke(this, new IntPtr[] { new IntPtr(&forceLoad) });
    }

    /*
    public bool HasTag(string tag)
    {
        return !string.IsNullOrEmpty(tag) && this.tags != null && this.tags.Contains(tag);
    }
    */

    public void RefreshState()
    {
        Instance_Class.GetMethod(nameof(RefreshState))?.Invoke(this);
    }

    public void ReloadAvatarNetworkedRPC(VRC.Player player)
    {
        Instance_Class.GetMethod(nameof(ReloadAvatarNetworkedRPC))?.Invoke(this, new IntPtr[] { player.Pointer });
    }
    /*
    private static IL2Method methodRefresh_Properties = null;
    public static void Refresh_Properties()
    {
        if (methodRefresh_Properties == null)
        {
            unsafe
            {
                IL2Method[] iL2Methods = Instance_Class.GetMethods(x => x.ReturnType.Name == "System.Void" && x.HasFlag(IL2BindingFlags.METHOD_STATIC) && x.HasFlag(IL2BindingFlags.METHOD_PRIVATE));
                foreach (var method in iL2Methods)
                {
                    var disasm = new Disassembler(*(IntPtr*)method.ptr, 0x1000, ArchitectureMode.x86_64, unchecked((ulong)(*(IntPtr*)method.ptr).ToInt64()), true, Vendor.Intel);
                    var instructions = disasm.Disassemble().TakeWhile(x => x.Mnemonic != ud_mnemonic_code.UD_Iint3);
                    if (instructions.Count() > 400)
                    {
                        methodRefresh_Properties = method;
                        break;
                    }
                }

            }
            if (methodRefresh_Properties == null)
                return;
        }
        methodRefresh_Properties.Invoke();
    }

    public ulong SteamUserIDULong
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(SteamUserIDULong));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == typeof(ulong).FullName)).Name = nameof(SteamUserIDULong);

            IL2Object result = property?.GetGetMethod().Invoke(ptr);
            if (result == null)
                return default;

            return result.unbox_Unmanaged<ulong>();
        }
    }

    public VRCInput inPanic
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(inPanic));
            if (field == null)
                (field = Instance_Class.GetFields().First(x => x.ReturnType.Name == VRCInput.Instance_Class.FullName)).Name = nameof(inPanic);

            return field?.GetValue(ptr)?.unbox<VRCInput>();
        }
    }
    
    private static IL2Property propertyShouldUpdate = null;
    public bool ShouldUpdate
    {
        get
        {
            if (propertyShouldUpdate == null)
            {
                propertyShouldUpdate = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == typeof(bool).FullName);
                if (propertyShouldUpdate == null)
                    return false;
            }

            return propertyShouldUpdate.GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
        }
    }

    */
    public PlayerSelector playerSelector
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(playerSelector));
            if (field == null)
                (field = Instance_Class.GetField(PlayerSelector.Instance_Class)).Name = nameof(playerSelector);

            return field?.GetValue(this)?.GetValue<PlayerSelector>();
        }
    }

    public GameObject avatarGameObject
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(avatarGameObject));
            if (field == null)
                (field = Instance_Class.GetField(GameObject.Instance_Class)).Name = nameof(avatarGameObject);

            return field?.GetValue(this)?.GetValue<GameObject>();
        }
    }
    public Animator avatarAnimator
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(avatarAnimator));
            if (field == null)
                (field = Instance_Class.GetField(Animator.Instance_Class)).Name = nameof(avatarAnimator);

            return field.GetValue(this)?.GetValue<Animator>();
        }
    }

    public PlayerNameplate nameplate
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(nameplate));
            if (field == null)
                (field = Instance_Class.GetField(PlayerNameplate.Instance_Class)).Name = nameof(nameplate);

            return field.GetValue(this)?.GetValue<PlayerNameplate>();
        }
    }

    /*


    /*
     * [~] Property:
     * VRC.Player [+]
     * VRC.Core.ApiAvatar [+]
     * ulong (naverno steamid)
     * PlayerAudioManager
     * PlayerNet
     * USpeaker
     * VRC.SDKBase.VRCPlayerApi
     */

    /*
    public void TeleportRPC(Vector3 vector, Quaternion quaternion, VRC_SceneDescriptor.SpawnOrientation spawnOrientation)
    {
        Network.RPC(VRC_EventHandler.VrcTargetType.TargetPlayer, gameObject, "TeleportRPC", new IntPtr[] {
            IL2Import.CreateNewObject(vector, BlazeTools.IL2SystemClass.vector3),
            IL2Import.CreateNewObject(quaternion, BlazeTools.IL2SystemClass.vector3),
            IL2Import.CreateNewObject(spawnOrientation, BlazeTools.IL2SystemClass.spawnOrientation)
        });
    }
    */
    public enum NetworkChange
    {
        Visible = 1,
        ModTag = 2,
        VRMode = 4,
        Status = 8,
        StatusDesc = 16,
        SteamId = 32,
        ShowRank = 64,
        Avatar = 128,
        User = 256
    }

    public static new IL2Class Instance_Class;
}