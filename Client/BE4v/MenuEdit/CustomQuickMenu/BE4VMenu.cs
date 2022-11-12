using BE4v.Mods;
using BE4v.Mods.Min;
using BE4v.Patch;
using BE4v.Patch.Core;
using BE4v.Patch.List;
using BE4v.MenuEdit.Construct;
using BE4v.MenuEdit.Construct.Horizontal;
using QuickMenuElement.Elements;
using BE4v.Utils;
using VRC.UI.Elements;
using VRC.UI.Elements.Controls;
using UnityEngine;

namespace CustomQuickMenu.Menus
{
    public static class BE4VMenu
    {
        public static MenuElement registerMenu = null;
        public static ElementHorizontalButton horizontalButton = null;

        public static void BlazeEngine4VersionMenu()
        {
            try
            {
                registerMenu = MenuElement.Create("BlazeEngine4Version");
            }
            catch { "Register menu is error".RedPrefix("Error!"); }

            horizontalButton = new ElementHorizontalButton("BlazeEngine4Version", delegate () { registerMenu.Open(); }, "Open BE4v Menu", sprite: LoadSprites.be4vLogo);

            // registerMenu.AddHeader("Sub menus");
            // ButtonsElement butttonsGroup = registerMenu.AddButtonsGroup("Sub menus");
            // butttonsGroup.AddButton("Advanced Effects", () => { Submenu.Effects.registerMenu.Open(); });

            registerMenu.AddHeader("Networking Tools");
            ButtonsElement butttonsGroup = registerMenu.AddButtonsGroup("Networking Tools");
            //RPCBlock.button = butttonsGroup.AddButton("RPC Block", RPCBlock.OnClick);
            //RPCBlock.Refresh();
            InvisAPI.button = butttonsGroup.AddButton("Invis API", InvisAPI.OnClick);
            InvisAPI.Refresh();
            FakePing.button = butttonsGroup.AddButton("Fake Ping", FakePing.OnClick);
            FakePing.Refresh();
            FakeFPS.button = butttonsGroup.AddButton("Fake FPS", FakeFPS.OnClick);
            FakeFPS.Refresh();
            SendAvatarData.button = butttonsGroup.AddButton("Send Avatars Data\n<color=red>Not working</color>", SendAvatarData.OnClick);
            SendAvatarData.Refresh();
            //AutoClearRAM.button = butttonsGroup.AddButton("AutoClear RAM", AutoClearRAM.OnClick);
            //AutoClearRAM.Refresh();
            //DeathMap.button = butttonsGroup.AddButton("Death Map", DeathMap.OnClick);
            //DeathMap.Refresh();

            registerMenu.AddHeader("Movement Tools");
            butttonsGroup = registerMenu.AddButtonsGroup("Movement Tools");
            FlyType.button = butttonsGroup.AddButton("Fly Type", FlyType.OnClick);
            FlyType.button._Sprite = LoadSprites.flyTypeIco;
            FlyType.Refresh();
            InfinityJump.button = butttonsGroup.AddButton("JetPack", InfinityJump.OnClick);
            InfinityJump.Refresh();
            BunnyHop.button = butttonsGroup.AddButton("BunnyHop", BunnyHop.OnClick);
            BunnyHop.Refresh();
            ForceJump.button = butttonsGroup.AddButton("ForceJump", ForceJump.OnClick);


            registerMenu.AddHeader("Settings for Tools");
            butttonsGroup = registerMenu.AddButtonsGroup("Settings for Tools");
            SitOnHeadType.button = butttonsGroup.AddButton("<color=red>Head</color>\nSit on head", SitOnHeadType.OnClick);
            SitOnHeadType.Refresh();

            registerMenu.AddHeader("ESP Tools");
            butttonsGroup = registerMenu.AddButtonsGroup("ESP Tools");
            ESP_LineRenderer.button = butttonsGroup.AddButton("ESP LineRenderer", ESP_LineRenderer.OnClick);
            ESP_LineRenderer.Refresh();
            ESP_Nameplates.button = butttonsGroup.AddButton("ESP Nameplates", ESP_Nameplates.OnClick);
            ESP_Nameplates.Refresh();
            // GlobalUdonEvent.button = new ElementButton("Global Udon Events", elementGroup, GlobalUdonEvent.OnClick);
            // GlobalUdonEvent.Refresh();

            // elementGroup = new ElementGroup("First Test GRoup 3", registerMenu);
            // ConsoleLog.button = new ElementButton("Log Events", elementGroup, ConsoleLog.OnClick);
            // ConsoleLog.Refresh();

            registerMenu.AddHeader("Funny BE4v");
            butttonsGroup = registerMenu.AddButtonsGroup("Funny BE4v");
            DevMenu.DevStatusMenu.button = butttonsGroup.AddButton("Dev GUI Menu", DevMenu.DevStatusMenu.OnClick);
            DevMenu.DevStatusMenu.Refresh();
            DevMenu.HideSelfAvatar.button = butttonsGroup.AddButton("Hide Self Avatar", DevMenu.HideSelfAvatar.OnClick);
            DevMenu.HideSelfAvatar.Refresh();
        }

        public static class DevMenu
        {
            public static class DevStatusMenu
            {
                public static QMButton button = null;

                public static void OnClick()
                {
                    if (Status.devMenuStatus++ > 1)
                        Status.devMenuStatus = 0;
                    Refresh();
                }

                public static void Refresh()
                {
                    if (button != null)
                    {
                        if (Status.devMenuStatus == 1)
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

            public static class HideSelfAvatar
            {
                public static QMButton button = null;

                public static void OnClick()
                {
                    Transform transform = VRCPlayer.Instance.avatarGameObject.transform.parent;
                    if (transform != null)
                    {
                        transform.gameObject.active = !transform.gameObject.active;
                    }
                    Refresh();
                }

                public static void Refresh()
                {
                    if (button != null)
                    {
                        Transform transform = VRCPlayer.Instance.avatarGameObject.transform.parent;
                        if (transform != null)
                        {
                            if (VRCPlayer.Instance.avatarGameObject.transform.parent.gameObject.active)
                            {
                                button._Sprite = LoadSprites.offButton;
                            }
                            else
                            {
                                button._Sprite = LoadSprites.onButton;
                            }
                        }
                    }
                }
            }
        }

        public static class SitOnHeadType
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                if (++Status.SitOnType > 2)
                    Status.SitOnType = 0;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    // SitOnHead.SitOnType.Head = 0
                    if (Status.SitOnType == 0)
                    {
                        button._Text = "<color=red>Head</color>\nSit on player";
                    }
                    // SitOnHead.SitOnType.LeftHand = 1
                    else if (Status.SitOnType == 1)
                    {
                        button._Text = "<color=red>Left Hand</color>\nSit on player";
                    }
                    // SitOnHead.SitOnType.RightHand = 2
                    else
                    {
                        button._Text = "<color=red>Right Hand</color>\nSit on player";
                    }
                }
            }
        }

        /*
        public static class RPCBlock
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                Status.isRPCBlock = !Status.isRPCBlock;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isRPCBlock)
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
        */
        
        public static class FlyType
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                FlyHack.ToggleType();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isFlyType)
                    {
                        button._Text = "<color=red>Directional</color>\nFly Type:";
                    }
                    else
                    {
                        button._Text = "<color=red>Standart</color>\nFly Type:";
                    }
                }
            }
        }

        public static class InvisAPI
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                BE4v.Patch.List.InvisAPI.Toggle();
            }

            public static void Refresh()
            {
                if (Status.isInvisAPI)
                {
                    if (button != null)
                        button._Sprite = LoadSprites.onButton;

                    if (BE4v.Patch.List.InvisAPI.patch?.Enabled == false)
                        BE4v.Patch.List.InvisAPI.patch.Enabled = true;
                }
                else
                {
                    if (button != null)
                        button._Sprite = LoadSprites.offButton;

                    if (BE4v.Patch.List.InvisAPI.patch?.Enabled == true)
                        BE4v.Patch.List.InvisAPI.patch.Enabled = false;
                }
            }
        }

        public static class FakePing
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                BE4v.Patch.List.FakePing.Toggle();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isFakePing)
                    {
                        button._Sprite = LoadSprites.onButton;

                        if (BE4v.Patch.List.FakePing.patch?.Enabled == false)
                            BE4v.Patch.List.FakePing.patch.Enabled = true;
                    }
                    else
                    {
                        button._Sprite = LoadSprites.offButton;

                        if (BE4v.Patch.List.FakePing.patch?.Enabled == true)
                            BE4v.Patch.List.FakePing.patch.Enabled = false;
                    }
                }
            }
        }
        
        public static class FakeFPS
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                BE4v.Patch.List.FakeFPS.Toggle();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isFakeFPS)
                    {
                        button._Sprite = LoadSprites.onButton;

                        if (BE4v.Patch.List.FakeFPS.patch?.Enabled == false)
                            BE4v.Patch.List.FakeFPS.patch.Enabled = true;
                    }
                    else
                    {
                        button._Sprite = LoadSprites.offButton;

                        if (BE4v.Patch.List.FakeFPS.patch?.Enabled == true)
                            BE4v.Patch.List.FakeFPS.patch.Enabled = false;
                    }
                }
            }
        }

        public static class DeathMap
        {
            public static QMButton button = null;

            public static bool isEnabled = false;

            public static void OnClick()
            {
                isEnabled = !isEnabled;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (isEnabled)
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
        
        /*
        public static class AutoClearRAM
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                Status.isAutoClear = !Status.isAutoClear;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isAutoClear)
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
        */
        public static class InfinityJump
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                Status.isInfinityJump = !Status.isInfinityJump;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isInfinityJump)
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
        
        
        public static class BunnyHop
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                Status.isBHop = !Status.isBHop;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isBHop)
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
        
        public static class ForceJump
        {
            public static QMButton button = null;
            public static void OnClick()
            {
                VRCPlayer player = VRCPlayer.Instance;
                if (player == null) return;

                VRC.SDKBase.Networking.LocalPlayer.SetJumpImpulse(3f);
            }
        }
        
        public static class GlobalUdonEvent
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                Status.isGlobalUdonEvent = !Status.isGlobalUdonEvent;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isGlobalUdonEvent)
                    {
                        button._Sprite = LoadSprites.onButton;

                        foreach (var patch in GlobalUdonEvents.patch)
                        {
                            if (patch?.Enabled == false)
                                patch.Enabled = true;
                        }
                    }
                    else
                    {
                        button._Sprite = LoadSprites.offButton;

                        foreach(var patch in GlobalUdonEvents.patch)
                        {
                            if (patch?.Enabled == true)
                                patch.Enabled = false;
                        }
                    }
                }
            }
        }

        public static class ESP_LineRenderer
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                Status.isLineRenderESP = !Status.isLineRenderESP;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isLineRenderESP)
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
                        LineRenderer lineRenderer = player.transform.GetComponent<LineRenderer>();
                        if (lineRenderer != null)
                            lineRenderer.Destroy();
                    }
                }
            }
        }

        public static class ESP_Nameplates
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                Status.isNameplatesESP = !Status.isNameplatesESP;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isNameplatesESP)
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
        public static class ConsoleLog
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                Status.isLog = !Status.isLog;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.isLog)
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

        public static class SendAvatarData
        {
            public static QMButton button = null;

            public static void OnClick()
            {
                Status.SendAvatarData = !Status.SendAvatarData;
                Refresh();
            }

            public static void Refresh()
            {
                if (button != null)
                {
                    if (Status.SendAvatarData)
                    {
                        button._Sprite = LoadSprites.onButton;
                        if (AvatarData.patch_LoadAvatar != null)
                            AvatarData.patch_LoadAvatar.Enabled = true;
                        if (AvatarData.patch_ShowImage != null)
                            AvatarData.patch_ShowImage.Enabled = true;
                    }
                    else
                    {
                        button._Sprite = LoadSprites.offButton;
                        if (AvatarData.patch_LoadAvatar != null)
                            AvatarData.patch_LoadAvatar.Enabled = false;
                        if (AvatarData.patch_ShowImage != null)
                            AvatarData.patch_ShowImage.Enabled = false;
                    }
                }
            }
        }

    }
}