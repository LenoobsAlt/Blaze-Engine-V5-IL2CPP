using System;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.SDKBase;
using BE4v.SDK;
using BE4v.MenuEdit.Construct;
using CustomQuickMenu.Menus;
using SharpDisasm;
public static class UserUtils
{
    unsafe public static Disassembler GetDisassembler(this IL2Method method, int @size = 0x1000)
    {
        return new Disassembler(*(IntPtr*)method.Pointer, @size, ArchitectureMode.x86_64, unchecked((ulong)(*(IntPtr*)method.Pointer).ToInt64()), true, Vendor.Intel);
    }

    #region SpawnPortal
    public static GameObject SpawnPortal(Transform transform, string worldId = "wrld_a61806c2-4f5c-4c00-8aae-c5f6d5c3bfde")
    {
        return SpawnPortal(transform.position + (transform.forward * 2), transform.rotation, worldId);
    }
    public static GameObject SpawnPortal(Vector3 position, Quaternion rotation, string worldId = "wrld_a61806c2-4f5c-4c00-8aae-c5f6d5c3bfde")
    {
        GameObject gameObject = VRC.Network.Instantiate(VRC_EventHandler.VrcBroadcastType.Always, "Portals/PortalInternalDynamic", position, rotation);
        if (gameObject == null)
            return null;

        VRC.Network.RPC(VRC_EventHandler.VrcTargetType.AllBufferOne, gameObject, "ConfigurePortal", new IntPtr[]
        {
            new IL2String_utf16(worldId).Pointer,
            new IL2Object<int>(0, IL2Int32.Instance_Class).Pointer
        });
        // gameObject.GetComponent<PortalInternal>().enabled = false;

        return gameObject;
    }
    #endregion CreatePortal
    /*
    public static void SetPedestals(string string_0)
    {
        if (string_0.StartsWith("avtr_"))
        {
            foreach (VRC.SDKBase.VRC_AvatarPedestal vrc_AvatarPedestal in UnityEngine.Object.FindObjectsOfType<VRC.SDKBase.VRC_AvatarPedestal>())
            {
                Networking.SetOwner(Networking.LocalPlayer, vrc_AvatarPedestal.gameObject);
                VRC.Network.RPC(VRC_EventHandler.VrcTargetType.All, vrc_AvatarPedestal.gameObject, "SwitchAvatar", new Il2CppSystem.Object[]
                {
                        string_0
                });
            }
        }
    }
    */

    public static GameObject SpawnDynLight(Transform transform)
    {
        string[] arrayString = ObjectInstantiator.adminOnlyPrefabs;
        ObjectInstantiator.adminOnlyPrefabs = new string[0];
        GameObject gameObject = VRC.Network.Instantiate(VRC_EventHandler.VrcBroadcastType.Local, "DevProp_DynLight", transform.position + (transform.forward * 2), new Quaternion(0, 0, 0, 0));
        ObjectInstantiator.adminOnlyPrefabs = arrayString;
        return gameObject;
    }

    public static void RemoveInstiatorObjects()
    {
        foreach(var obj in UnityEngine.Object.FindObjectsOfType<ObjectInstantiatorHandle>())
            obj.gameObject.Destroy();
        // RoomManager.userPortals.Clear();
    }

    public static string QM_GetSelectedUserName()
    {
        string userName = null;
        if (SelectedMenu.registerMenu != null)
        {
            if (SelectedMenu.registerMenu.gameObject.active)
            {
                Transform transform = SelectedMenu.registerMenu.verticalLayoutGroup.transform.Find("UserProfile_Compact/PanelBG/Info/Text_Username_NonFriend");
                if (transform != null)
                {
                    userName = transform.GetComponent<TMPro.TextMeshProUGUI>()?.text;
                }
            }
        }
        return userName;
    }

    public static VRC.Player GetPlayerByName(string userName)
    {
        if (string.IsNullOrEmpty(userName)) return null;
        VRC.Player[] players = NetworkSanity.NetworkSanity.players;
        foreach(VRC.Player player in players)
        {
            if (player.user.displayName == userName)
                return player;
        }
        return null;
    }
    /*
    internal static APIUser current_User_UserInfo
    {
        get
        {
            // return GameObject.Find("UserInterface/MenuContent/Screens/UserInfo")?.GetComponent<VRCUiPage>()?.user;
            return GameObject.Find("UserInterface/MenuContent/Screens/UserInfo")?.GetComponent<PageUserInfo>()?.user;
        }
    }
    */
}