using BE4v.Mods;
using BE4v.Mods.Min;
using BE4v.Patch;
using BE4v.Patch.Core;
using BE4v.Patch.List;
using BE4v.MenuEdit.Construct;
using BE4v.MenuEdit.Construct.Horizontal;
using QuickMenuElement.Elements;
using BE4v.Utils;


namespace CustomQuickMenu.Menus.Submenu
{
    public static class Effects
    {
        public static MenuElement registerMenu = null;
        public static ElementHorizontalButton registerMenuButton = null;

        public static HeaderElement header_Game_Murder = null;
        public static ButtonsElement buttonsGroup_JumpEffects = null;

        public static void BlazeEngine4VersionMenu()
        {

            registerMenu = MenuElement.Create("Advanced Effects");

            /* | * * * * * * * * * | */
            /* | ~ Murder  Buttons | */
            /* | * * * * * * * * * | */
            if (buttonsGroup_JumpEffects == null)
            {
                header_Game_Murder = registerMenu.AddHeader("Jump Effects");
                buttonsGroup_JumpEffects = registerMenu.AddButtonsGroup("Jump Effects");
            }

            JumpEffects.Enabled.button = buttonsGroup_JumpEffects.AddButton("Enabled", JumpEffects.Enabled.OnClick);
            JumpEffects.Enabled.Refresh();

            JumpEffects.Cylinder.button = buttonsGroup_JumpEffects.AddButton("Cylinder", JumpEffects.Cylinder.OnClick);
            
            JumpEffects.RefreshAll();
        }


        public static class JumpEffects
        {
            public static void RefreshAll()
            {
                if (Status.CylinderType < 0 || Status.CylinderType > 0)
                    Status.CylinderType = 0;
                Cylinder.Refresh();
            }

            public static class Enabled
            {
                public static QMButton button = null;

                public static void OnClick()
                {
                    Status.isJumpEffects = !Status.isJumpEffects;
                    Refresh();
                }

                public static void Refresh()
                {
                    if (button != null)
                    {
                        if (Status.isJumpEffects)
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

            public static class Cylinder
            {
                public static QMButton button = null;

                public static void OnClick()
                {
                    Status.CylinderType = 0;
                    RefreshAll();
                }

                public static void Refresh()
                {
                    if (button != null)
                    {
                        if (Status.CylinderType == 0)
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
        }
    }
}