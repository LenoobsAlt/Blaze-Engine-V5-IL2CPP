using System;
using System.Collections.Generic;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.Core;
using BE4v.Mods;
using BE4v.Patch.Core;
using BE4v.Utils;

namespace BE4v.Utils
{
    public static class ESPUtils
    {
        public static void ESP_ForPlayer(VRC.Player player)
        {
            try
            {
                if (player == VRC.Player.Instance) return;
                Renderer renderer = player.Components?.playerSelector?.GetComponent<Renderer>();

                if (renderer != null)
                {
                    APIUser user = player.user;
                    if (user == null)
                        return;

                    HighlightUtils.GetLight(Color.yellow).EnableOutline(renderer, false);
                    HighlightUtils.GetLight(Color.red).EnableOutline(renderer, false);
                    HighlightUtils.GetLight(Color.cyan).EnableOutline(renderer, false);
                    // if (blocked[player.ptr] || blockedBy[player.ptr])
                    // {
                    //    HighlightUtils.GetLight(Color.cyan).EnableOutline(renderer, Status.isGlowESP);
                    //}
                    if (APIUser.IsFriendsWith(user.id))
                    {
                        HighlightUtils.GetLight(Color.yellow).EnableOutline(renderer, Status.isGlowESP);
                    }
                    else
                    {
                        HighlightUtils.GetLight(Color.red).EnableOutline(renderer, Status.isGlowESP);
                    }
                }
            }
            catch { }
            /*
            try
            {
                Canvas canvas = player.transform.Find("Player Nameplate/Canvas").GetComponent<Canvas>();
                if (canvas != null)
                {
                    if (Status.isNameplatesESP)
                    {
                        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                    }
                    else
                    {
                        canvas.renderMode = RenderMode.WorldSpace;
                    }
                }
            }
            catch { }
            */
        }

        public static void EnableESP(Renderer renderer, Color color, bool status)
        {
            HighlightUtils.GetLight(color).EnableOutline(renderer, status);
        }
    }
}
