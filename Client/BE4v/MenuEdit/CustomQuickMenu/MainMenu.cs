using BE4v.Mods;
using BE4v.Mods.Min;
using BE4v.SDK.IL2Dumper;
using System;
using System.Net;
using UnityEngine;
using VRC;
using VRC.UI.Elements;
using BE4v.Patch;
using BE4v.MenuEdit.Construct;
using QuickMenuElement.Elements;
using BE4v.Utils;

namespace CustomQuickMenu.Menus
{
    public static class MainMenu
    {
        public static MenuElement registerMenu = null;
        public static ButtonsElement buttonsGroup = null;
        public static void BlazeEngine4VersionMenu()
        {
            if (registerMenu == null)
            {
                registerMenu = new MenuElement();
                registerMenu.gameObject = QuickMenuUtils.menuDashboardTemplate.gameObject;
            }

            if (buttonsGroup == null)
            {
                registerMenu.AddHeader("Toggle's BE4v");
                buttonsGroup = registerMenu.AddButtonsGroup("Toggle's BE4v");
            }

            if (GlowESP.button == null)
            {
                GlowESP.button = buttonsGroup.AddButton("Toggle ESP", GlowESP.OnClick);
                GlowESP.Refresh();
            }
            if (FlyToggle.button == null)
            {
                FlyToggle.button = buttonsGroup.AddButton("Fly Toggle", FlyToggle.OnClick);
                FlyToggle.Refresh();
            }
            if (SpeedHackToggle.button == null)
            {
                SpeedHackToggle.button = buttonsGroup.AddButton("SpeedHack", SpeedHackToggle.OnClick);
                SpeedHackToggle.Refresh();
            }
            if (Serilize.button == null)
            {
                Serilize.button = buttonsGroup.AddButton("Serilize\n<color=red>experimental</color>", Serilize.OnClick);
                Serilize.Refresh();
            }

            /*
            if (buttonRemoveObjects == null)
            {
                buttonRemoveObjects = new ElementButton("Remove Objects", elementGroup, UserUtils.RemoveInstiatorObjects);
                buttonRemoveObjects.SetSprite(LoadSprites.trashIco);
            }
            */
        }

        public static class FlyToggle
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                FlyHack.Toggle();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isFly)
                    {
                        button._Sprite = LoadSprites.onButton;
                    }
                    else
                    {
                        button._Sprite = LoadSprites.offButton;
                    }
                }
            }
        }
        
        public static class SpeedHackToggle
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                SpeedHack.Toggle();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isSpeedHack)
                    {
                        button._Sprite = LoadSprites.onButton;
                    }
                    else
                    {
                        button._Sprite = LoadSprites.offButton;
                    }
                }
            }
        }

        public static class GlowESP
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                Status.isGlowESP = !Status.isGlowESP;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isGlowESP)
                    {
                        button._Sprite = LoadSprites.onButton;
                    }
                    else
                    {
                        button._Sprite = LoadSprites.offButton;
                    }
                }

                VRC.Player localPlayer = VRC.Player.Instance;
                if (localPlayer != null)
                {
                    Threads.UpdatePlayers();
                    foreach (var player in NetworkSanity.NetworkSanity.players)
                    {
                        if (player == localPlayer) continue;
                        ESPUtils.ESP_ForPlayer(player);
                    }
                }
            }
        }

        public static class Serilize
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                BE4v.Patch.List.Serilize.Toggle();
            }

            public static void Refresh()
            {
                if (Status.isSerilize)
                {
                    if (button != null)
                        button._Sprite  = LoadSprites.onButton;

                    if (BE4v.Patch.List.Serilize.patch != null)
                        BE4v.Patch.List.Serilize.patch.Enabled = true;
                }
                else
                {
                    if (button != null)
                        button._Sprite = LoadSprites.offButton;

                    if (BE4v.Patch.List.Serilize.patch != null)
                        BE4v.Patch.List.Serilize.patch.Enabled = false;
                }
            }
        }

    }

    /*
    public static class ClickClass_OpenGUI
    {
        public static void Click()
        {
            DumpForm form = new DumpForm();
            form.Show();
            form.Activate();
        }

        public static void UpdateStatus()
        {

        }

        public static bool isEnabled = false;
    }
    public static class ClickClass_GAIN
    {
        public static void ButtonToggle()
        {
            
        }

        // public static QuickToggler quickTogglerGAIN;
    }
    */
}
