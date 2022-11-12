using System;
using UnityEngine;
using BE4v.Utils;
using BE4v.Mods;
using BE4v.Mods.Core;
using BE4v.Mods.Min;

namespace BE4v.MenuEdit.IMGUI
{
    public class TabMenu_PlayerList : IUpdate, IOnGUI
    {
        public static bool isPressed = false;
        
        public void Update()
        {
            if (Status.devMenuStatus != 0) return;
            isPressed = Input.GetKey(KeyCode.Tab);
        }

        int screenHeight = 0;
        int screenWidth = 0;
        public bool OnSize()
        {
            screenHeight = Screen.height;
            screenWidth = Screen.width;

            if (screenHeight < 1 || screenHeight < 1) return false;
            // rectText = new Rect(screenWidth - 370, screenHeight - 230, 350, 200);

            return true;
        }

        public void OnGUI()
        {
            if (Status.devMenuStatus != 0) return;
            NotifySystem.Notify.OnGUI();
            if (!isPressed) return;
            if (!OnSize())
            {
                return;
            }
            GUI.backgroundColor = new Color(255, 0, 0);

            int SizeX1 = screenWidth - (iLeftMargin * 2);

            Rect rectPlayerId = new Rect(120, iTopMargin, 40, 20);
            Rect rectPlayerName = new Rect(iLeftMargin, iTopMargin, SizeX1, 20);

            VRC.Player[] playerArray = NetworkSanity.NetworkSanity.players;

            GUI.Label(new Rect(120, iTopMargin, 40, 20), "<b>#</b>");
            GUI.Label(new Rect(160, iTopMargin, SizeX1, 20), "<b>displayName</b>");
            try
            {
                GUI.Box(new Rect(100, 50, Screen.width - 200, Screen.height - 100), new IL2String(IntPtr.Zero));
                
                foreach (var player in playerArray)
                {
                    int? playerId = player?.PhotonPlayer?.ActorNumber;
                    if (playerId == null) continue;
                    if (iSelectUser == playerId)
                    {
                        if (uSelectSteam != 0L)
                        {
                            if (GUI.Button(new Rect(180, 112, 150, 17), string.Empty))
                            {
                                Avatars.OpenUrlBrowser("https://steamcommunity.com/profiles/" + uSelectSteam);
                            }
                        }
                        GUI.Label(new Rect(130, 80, 300, iTopMargin - 80), tempText);
                        if (GUI.Button(new Rect(400, 100, 120, 20), "Teleport"))
                        {
                            VRC.Player.Instance.transform.position = player.transform.position;
                        }
                        string sitText;
                        if (SitOnHead.VRC_Player_Pointer != player.Pointer)
                            sitText = "Sit on";
                        else
                            sitText = "Get up";
                        if (GUI.Button(new Rect(400, 120, 120, 20), sitText))
                        {
                            if (SitOnHead.VRC_Player_Pointer != player.Pointer)
                                SitOnHead.SelectUser = player;
                            else
                                SitOnHead.SelectUser = null;
                        }
                        /*string blockButton = (NetworkSanity.NetworkSanity.userList.Contains(playerId.Value) ? "Data unBlock" : "Data Block");
                        if (GUI.Button(new Rect(550, 100, 120, 20), blockButton))
                        {
                            if (NetworkSanity.NetworkSanity.userList.Contains(playerId.Value))
                            {
                                NetworkSanity.NetworkSanity.userList.Remove(playerId.Value);
                            }
                            else
                            {
                                NetworkSanity.NetworkSanity.userList.Add(playerId.Value);
                            }
                        }
                        */
                    }
                    string userName = player.user.username;
                    if (string.IsNullOrWhiteSpace(userName))
                        player.user.Fetch();

                    string userIdMessage = string.Empty;
                    if (iSelectUser == playerId)
                        userIdMessage += "<b><color=red>" + playerId + "</color></b>";
                    else if (NetworkSanity.NetworkSanity.userList.Contains(playerId.Value))
                        userIdMessage += "<b><color=yellow>" + playerId + "</color></b>";
                    else
                        userIdMessage += "<b><color=white>" + playerId + "</color></b>";
                    
                    rectPlayerName.y = (rectPlayerId.y += 20);

                    if (GUI.Button(rectPlayerId, userIdMessage)
                    || GUI.Button(rectPlayerName, new IL2String_utf16(player.user.displayName)))
                    {
                        playerPhoton = player;
                        iSelectUser = playerId;

                        // uSelectSteam = player.Components;
                        string text = "<b>Selected player:</b>";
                        text += "\n<b>ID:</b>\t" + playerId;
                        uSelectSteam = 0L;
                        if (userName.StartsWith("steam_"))
                        {
                            uSelectSteam = long.Parse(userName.Remove(0, "steam_".Length));
                            if (uSelectSteam != 0L)
                            {
                                text += "\n<b>Steam:</b>\t" + uSelectSteam;
                            }
                        }
                        tempText = text;
                    }
                }
            }
            catch
            {
                
            }
        }

        private static string tempText = string.Empty;

        private static long uSelectSteam = 0L;

        private static int? iSelectUser = null;

        public static VRC.Player playerPhoton = null;

        private static readonly int iTopMargin = 160;

        private static readonly int iLeftMargin = 160;
    }
}
