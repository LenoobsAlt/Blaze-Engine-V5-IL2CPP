using BE4v.MenuEdit.Construct;
using BE4v.Mods;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using BE4v.Patch;
using VRC.UI.Elements;

namespace BE4v.MenuEdit
{
    public static class BE4V_QuickUIMenu_T2
    {

        public static void Start()
        {
            /*
            if (buttons != null) return;
            @menuname = "UIElementsMenu_T2";
            QuickMenu_Utils.CreateQuickMenu(@menuname);
            buttons = new Dictionary<string, QuickButton>();
            toggler = new Dictionary<string, QuickToggler>();
            /* * [ Col -1 ] * */
            // toggler.Add("RPCBlock", new QuickToggler(@menuname, -1, 0, "RPC Block", ClickClass_RPCBlock.OnClick_RPCBlockToggle, "off", "Toggle: Module RPC Block"));
            /* * * * ** * * * */

            /* * [ Col 3 ] * */
            // toggler.Add("BHop", new QuickToggler(@menuname, 3, 0, "Bunny Hop", ClickClass_BunnyHop.OnClick_BunnyHopToggle, "off", "Toggle: Module Bunny Hop"));
            /* * * * ** * * * */

            /* * [ Col 4 ] * */
            // toggler.Add("InfinityJump", new QuickToggler(@menuname, 4, 0, "Infinity Jump", ClickClass_InfinityJump.OnClick_InfinityJumpToggle, "off", "Toggle: Module Infinity jump"));
            // toggler.Add("AntiBlock", new QuickToggler(@menuname, 4, 1, "Anti Block", ClickClass_AntiBlock.OnClick_AntiBlockToggle, "off", "Toggle: Enabled module Anti-Block\nShow blocked users"));
            /* * * * * * * * */

            /* * [ SET BACK BUTTON ] * */
            // GameObject gameObject = QuickMenu.Instance.transform.Find(BE4V_QuickUIMenu.@menuname + "/BackButton").gameObject;
            // var click = gameObject.GetComponent<Button>().onClick;
            // gameObject.SetActive(false);
            // buttons.Add("BackButton", new QuickButton(@menuname, 4, 2, MSGClass_QuickMenu.msgBackButton_name, null, MSGClass_QuickMenu.msgBackButton_ToolTip));
            // buttons["BackButton"].gameObject.GetComponent<Button>().onClick = click;
            /* * [ SET BACK BUTTON ] * */
            /*
            ClickClass_FlyHack.OnClick_FlyToggle_Refresh();
            ClickClass_FlyHack.OnClick_FlyType_Refresh();
            ClickClass_InfinityJump.OnClick_InfinityJumpToggle_Refresh();
            ClickClass_InvisAPI.OnClick_InvisAPIToggle_Refresh();
            ClickClass_SpeedHack.OnClick_SHToggle_Refresh();
            ClickClass_Serilize.OnClick_SerilizeToggle_Refresh();
            ClickClass_FakePing.OnClick_FakePingToggle_Refresh();
            ClickClass_GlobalDynamicBones.OnClick_GlobalDynamicBones_Refresh();
            ClickClass_NoPortalJoin.OnClick_NoPortalJoin_Refresh();
            ClickClass_AntiBlock.OnClick_AntiBlockToggle_Refresh();
            */

            // QuickButton button = new QuickButton(@menuname, -1, -1, string.Empty, ClickClass_ChangeMenu.To_UIElementsMenu_1, "Change to Prev menu");
            /*
            button.gameObject.GetComponentInChildren<Image>().sprite = imgPrev.sprite;
            button.gameObject.GetComponentInChildren<Image>().material = imgPrev.material;
            button.gameObject.transform.localScale = new Vector3(-1, 1);

            button = new QuickButton(@menuname, 4, -1, string.Empty, ClickClass_ChangeMenu.To_UIElementsMenu_1, "Change to Next menu");
            button.gameObject.GetComponentInChildren<Image>().sprite = imgNext.sprite;
            button.gameObject.GetComponentInChildren<Image>().material = imgNext.material;
            */
        }
    }

        

}
