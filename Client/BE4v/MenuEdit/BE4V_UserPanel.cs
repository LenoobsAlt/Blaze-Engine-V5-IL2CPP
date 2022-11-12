using BE4v.MenuEdit.Construct;
using BE4v.SDK;
using Microsoft.Win32;
using System;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;
using VRC.UI;

namespace BE4v.MenuEdit
{
    public static class BE4V_UserPanel
    {
        public static GameObject buttonTeleport;
        public static void Start()
        {
            /*
            try
            {
                string path = PageUserInfo.userInfoScreenPath;
                GameObject original = GameObject.Find(path + "/OnlineFriendButtons/JoinButton");
                GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(original, GameObject.Find(path).transform, true);
                buttonTeleport = gameObject;
                buttonTeleport.MoveLocation(0, -80f);
                buttonTeleport.setButtonText("Drop Portal to Instance");
                buttonTeleport.setAction(ClickClass_DropPortalToUser.PortalDrop, true);
                "Portals to friend's".GreenPrefix("UI");
            }
            catch (Exception ex)
            {
                "Teleport to user".RedPrefix("UI");
                ex.ToString().WriteMessage("EX:");
            }
            /*
            try
            {
                string path = PageUserInfo.userInfoScreenPath;
                GameObject original = GameObject.Find(path + "/OnlineFriendButtons/JoinButton");
                GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(original, GameObject.Find(path).transform, true);
                UserDropPortal = new UIButton(gameObject);
                UserDropPortal.MoveLocation(0, -80f);
                UserDropPortal.setButtonText("Drop Portal to Instance");
                UserDropPortal.setAction(ClickClass_DropPortalToUser.PortalDrop, true);
                "[UI] Portals to friend's".GreenPrefix(TMessage.SuccessPatch);
            }
            catch (Exception ex)
            {
                "[UI] Portals to friend's".RedPrefix(TMessage.BadPatch);
                ex.ToString().WriteMessage("EX:");
            }
            */
        }

    }
    /*
    public static class ClickClass_DropPortalToUser
    {
        public static void PortalDrop()
        {
            APIUser user = PageUserInfo.Instance?.user;
            if (user == null) return;
            if (user?.id == APIUser.CurrentUser.id)
            {
                VRCUiPopupManager.Instance.ShowAlert("Error", "You cannot drop a portal to yourself!");
                return;
            }
            string loc = user.location;
            if (string.IsNullOrWhiteSpace(loc))
            {
                VRCUiPopupManager.Instance.ShowAlert("Error", "Player " + user.displayName + " has no valid location!");
                return;
            }
            if (loc == "private")
            {
                VRCUiPopupManager.Instance.ShowAlert("Error", "Player " + user.displayName + " location is private!");
                return;
            }
            if (loc == "offline")
            {
                VRCUiPopupManager.Instance.ShowAlert("Error", "Player " + user.displayName + " is offline!");
                return;
            }
            string[] location = loc.Split(new char[]
            {
                ':'
            });
            UserUtils.SpawnPortal(VRCPlayer.Instance.transform, location[0], location[1]);
        }
    }
    */
}
