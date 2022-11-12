using BE4v.Mods;
using BE4v.Mods.Min;
using BE4v.Patch;
using BE4v.Patch.List;

namespace BE4v.MenuEdit
{
    public static class BE4V_QuickUIMenu
    {
        public static void Start()
        {
            /*if (buttons != null) return;
            @menuname = "UIElementsMenu";
            buttons = new Dictionary<string, QuickButton>();
            toggler = new Dictionary<string, QuickToggler>();

            /* * [ Line 0 ] * */
            //toggler.Add("InvisAPI", new QuickToggler(@menuname, -1, 0, "Invis API", ClickClass_InvisAPI.OnClick_InvisAPIToggle, "off", "Toggle: Enabled module for offline mode"));
            //toggler.Add("FlyToggle", new QuickToggler(@menuname, 3, 0, "Fly hack", ClickClass_FlyHack.OnClick_FlyToggle, "off", "Toggle: Module Fly Hack"));
            //buttons.Add("FlyType", new QuickButton(@menuname, 4, 0, "Fly Type:", ClickClass_FlyHack.OnClick_FlyType, "Toggle:"));
            /* * * * ** * * * */

            /* * [ Line 1 ] * */
            //toggler.Add("Serilize", new QuickToggler(@menuname, -1, 1, "Serilize", ClickClass_Serilize.OnClick_SerilizeToggle, "off", "Toggle: Enabled module Serilize"));
            //toggler.Add("SHToggle", new QuickToggler(@menuname, 3, 1, "SpeedHack", ClickClass_SpeedHack.OnClick_SHToggle, "off", "Toggle: Module SpeedHack"));
            /* -------------- */
            /*buttons.Add("SHButtonPlus", new QuickButton(@menuname, 5, 0, "+++", ClickClass_SpeedHack.OnClick_SHButtonPlus, "Plus xMove for SpeedHack"));
            RectTransform rectTransform = buttons["SHButtonPlus"].gameObject.transform.MonoCast<RectTransform>();
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y / 2);
            buttons["SHButtonPlus"].MoveLocation(-1, 0.75f);
            /* -------------- */
            /*buttons.Add("SHButtonMinus", new QuickButton(@menuname, 5, 0.5f, "---", ClickClass_SpeedHack.OnClick_SHButtonMinus, "Minus xMove for SpeedHack"));
            rectTransform = buttons["SHButtonMinus"].gameObject.transform.MonoCast<RectTransform>();
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y / 2);
            buttons["SHButtonMinus"].MoveLocation(-1, 0.75f);
            /* * * * ** * * * */

            /* * [ Line 2 ] * */
            /*toggler.Add("FakePing", new QuickToggler(@menuname, -1, 2, "Fake Ping", ClickClass_FakePing.OnClick_FakePingToggle, "off", "Toggle: Enabled module Fake Ping (777)"));
            toggler.Add("GlobalDynamicBones", new QuickToggler(@menuname, 2, 2, "Global\nDynamic Bones", ClickClass_GlobalDynamicBones.OnClick_GlobalDynamicBones, "off", "Toggle: Enabled module Global Dynamic Bones"));
            toggler.Add("NoPortalJoin", new QuickToggler(@menuname, 3, 2, "No Portal Join", ClickClass_NoPortalJoin.OnClick_NoPortalJoin, "off", "Toggle: Enabled module No Portal Join"));
            /* * * * ** * * * */

            /* * [ SET BACK BUTTON ] * */
            /*GameObject gameObject = QuickMenu.Instance.transform.Find(@menuname + "/BackButton").gameObject;
            var click = gameObject.GetComponent<Button>().onClick;
            gameObject.SetActive(false);
            buttons.Add("BackButton", new QuickButton(@menuname, 4, 2, MSGClass_QuickMenu.msgBackButton_name, null, MSGClass_QuickMenu.msgBackButton_ToolTip));
            buttons["BackButton"].gameObject.GetComponent<Button>().onClick = click;
            /* * [ SET BACK BUTTON ] * */

            ClickClass_FlyHack.OnClick_FlyToggle_Refresh();
            ClickClass_FlyHack.OnClick_FlyType_Refresh();
            ClickClass_SpeedHack.OnClick_SHToggle_Refresh();
        }
    }

    public static class ClickClass_InvisAPI
    {
        public static void OnClick_InvisAPIToggle()
        {
            //InvisAPI.Toggle();
        }

        public static void OnClick_InvisAPIToggle_Refresh()
        {
            // BE4V_QuickUIMenu.toggler["InvisAPI"].SetToggleToOn(Status.isInvisAPI);
            if (Status.isInvisAPI)
            {
                // BE4V_QuickUIMenu.toggler["InvisAPI"].setOffText("on");
                // if (InvisAPI.patch?.Enabled == false)
                //    InvisAPI.patch.Enabled = true;
            }
            else
            {
                // BE4V_QuickUIMenu.toggler["InvisAPI"].setOffText("off");
                // if (InvisAPI.patch?.Enabled == true)
                //    InvisAPI.patch.Enabled = false;
            }
        }
    }
    
    public static class ClickClass_SpeedHack
    {
        public static void OnClick_SHButtonPlus()
        {
            if (Status.iSpeedHackSpeed < 100)
                Status.iSpeedHackSpeed++;
            OnClick_SHToggle_Refresh();
        }

        public static void OnClick_SHButtonMinus()
        {
            if (Status.iSpeedHackSpeed > 1)
                Status.iSpeedHackSpeed--;
            OnClick_SHToggle_Refresh();
        }

        public static void OnClick_SHToggle()
        {
            SpeedHack.Toggle();
        }
        public static void OnClick_SHToggle_Refresh()
        {
            /*
            BE4V_QuickUIMenu.toggler["SHToggle"].SetToggleToOn(Status.isSpeedHack);
            BE4V_QuickUIMenu.buttons["SHButtonPlus"].gameObject.SetActive(Status.isSpeedHack);
            BE4V_QuickUIMenu.buttons["SHButtonMinus"].gameObject.SetActive(Status.isSpeedHack);
            if (Status.isSpeedHack)
            {
                BE4V_QuickUIMenu.toggler["SHToggle"].setOffText("x" + Status.iSpeedHackSpeed);
            }
            else
            {
                BE4V_QuickUIMenu.toggler["SHToggle"].setOffText("off");
            }
            */
        }

    }

    public static class ClickClass_FlyHack
    {
        public static void OnClick_FlyToggle()
        {
            FlyHack.Toggle();
        }

        public static void OnClick_FlyToggle_Refresh()
        {
            /*
            BE4V_QuickUIMenu.toggler["FlyToggle"].SetToggleToOn(Status.isFly);
            if (Status.isFly)
            {
                BE4V_QuickUIMenu.toggler["FlyToggle"].setOffText("on");
            }
            else
            {
                BE4V_QuickUIMenu.toggler["FlyToggle"].setOffText("off");
            }
            BE4V_QuickUIMenu.buttons["FlyType"].gameObject.SetActive(Status.isFly);
            */
        }

        public static void OnClick_FlyType()
        {
            FlyHack.ToggleType();
        }

        public static void OnClick_FlyType_Refresh()
        {
            /*
            if (Status.isFlyType)
            {
                BE4V_QuickUIMenu.buttons["FlyType"].setToolTip("Toggle: Change type fly hack to Fly");
                BE4V_QuickUIMenu.buttons["FlyType"].setButtonText("Fly Type:\n<color=red>NoClip</color>");
                return;
            }
            BE4V_QuickUIMenu.buttons["FlyType"].setToolTip("Toggle: Change type fly hack to NoClip");
            BE4V_QuickUIMenu.buttons["FlyType"].setButtonText("Fly Type:\n<color=red>Fly</color>");
            */
        }
    }
}
