using BE4v.Mods;
using BE4v.Mods.Min;
using BE4v.Patch;
using BE4v.Patch.Core;
using BE4v.Patch.List;
using BE4v.MenuEdit.Construct;
using BE4v.MenuEdit.Construct.Horizontal;
using QuickMenuElement.Elements;
using BE4v.Utils;

namespace CustomQuickMenu.Menus
{
    public static class xGameMenu
    {
        public static MenuElement registerMenu = null;
        public static ElementHorizontalButton registerMenuButton = null;

        public static HeaderElement header_Game_Murder = null;
        public static ButtonsElement buttonsGroup_Game_Murder = null;
        public static ButtonsElement buttonsGroup_Game_Murder2 = null;

        public static void BlazeEngine4VersionMenu()
        {

            registerMenu = MenuElement.Create("xGameMenu");

            registerMenuButton = new ElementHorizontalButton("xGameMenu", delegate () { registerMenu.Open(); });
            registerMenuButton.SetSprite(LoadSprites.gamingIco);

            /* | * * * * * * * * * | */
            /* | ~ Murder  Buttons | */
            /* | * * * * * * * * * | */
            if (buttonsGroup_Game_Murder == null)
            {
                header_Game_Murder = registerMenu.AddHeader("Murder");
                buttonsGroup_Game_Murder = registerMenu.AddButtonsGroup("Game Murder");
                buttonsGroup_Game_Murder2 = registerMenu.AddButtonsGroup("Game Murder 2");
            }

            buttonsGroup_Game_Murder.AddButton("Start Game", xGameUtils.Murder.Start);
            buttonsGroup_Game_Murder.AddButton("Kill All", xGameUtils.Murder.KillAll);
            buttonsGroup_Game_Murder.AddButton("Win Bystand", xGameUtils.Murder.ByStandWin);
            buttonsGroup_Game_Murder.AddButton("Win Murder", xGameUtils.Murder.MurderWin);

            buttonsGroup_Game_Murder2.AddButton("Blind All", xGameUtils.Murder.BlindAll);
            buttonsGroup_Game_Murder2.AddButton("Abort", xGameUtils.Murder.Abort);

        }
    }
}