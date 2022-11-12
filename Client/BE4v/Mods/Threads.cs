using System;
using UnityEngine;
using BE4v.Mods.Core;
using BE4v.MenuEdit.Construct;
using CustomQuickMenu.Menus;

namespace BE4v.Mods
{
    public class Threads : IUpdate
    {
        public static bool isCtrl = false;

        public static long timestamp = 0;

        public static GameObject be4v_gui = null;

        public static void Create()
        {
            if (be4v_gui == null)
            {
                Application.targetFrameRate = 145;
                LoadSprites.DownloadAll();

                be4v_gui = new GameObject("BE4V_GUI");
                be4v_gui.AddComponent<OVRLipSyncMicInput>();
                UnityEngine.Object.DontDestroyOnLoad(be4v_gui);
            }
        }

        public void Update()
        {
            if (!isLoadedCharacter)
            {
                isLoadedCharacter = true;
                Create();
                MenuEdit.Core.Install();

            }
            timestamp = UnixTimeNow();
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (!Threads.isCtrl) return;
                float volume = USpeaker.LocalGain;
                if (volume <= 1f)
                {
                    USpeaker.LocalGain = float.MaxValue;
                    "Enabled Max Volume".RedPrefix("MaxGain");
                }
                else
                {
                    USpeaker.LocalGain = 1f;
                    "Disabled Max Volume".RedPrefix("MaxGain");
                }
                return;
            }
        }

        public static void CheckGameButtons()
        {
            if (xGameMenu.header_Game_Murder != null)
            {
                bool gameInit = Utils.xGameUtils.Murder.IsGameWorld;
                xGameMenu.header_Game_Murder.gameObject.SetActive(gameInit);
                xGameMenu.buttonsGroup_Game_Murder.gameObject.SetActive(gameInit);
                xGameMenu.buttonsGroup_Game_Murder2.gameObject.SetActive(gameInit);
                if (gameInit)
                {
                    xGameMenu.registerMenuButton.gameObject.SetActive(true);
                    return;
                }


                xGameMenu.registerMenuButton.gameObject.SetActive(false);
            }
        }

        public static void UpdatePlayers()
        {
            CheckGameButtons();
            NetworkSanity.NetworkSanity.players = VRC.PlayerManager.PlayersCopy;
            int len = NetworkSanity.NetworkSanity.players.Length;
            if (len > 0)
            {
                VRC.PlayerManager.MasterId = NetworkSanity.NetworkSanity.players[0].PhotonPlayer.ActorNumber;
                if (VRC.PlayerManager.MasterId < 0 && len > 1)
                {
                    VRC.PlayerManager.MasterId = NetworkSanity.NetworkSanity.players[1].PhotonPlayer.ActorNumber;
                 }
            }
            else
                VRC.PlayerManager.MasterId = 0;
        }

        public static long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }

        private static bool isLoadedCharacter = false;
    }
}
