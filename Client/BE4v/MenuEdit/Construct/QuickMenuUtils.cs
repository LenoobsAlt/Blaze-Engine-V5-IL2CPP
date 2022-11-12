using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.UI.Elements;

namespace BE4v.MenuEdit.Construct
{
    public static class QuickMenuUtils
    {

        private static Transform _buttonHorizontal = null;
        public static Transform buttonHorizontal
        {
            get
            {
                if (_buttonHorizontal == null)
                {
                    _buttonHorizontal = QuickMenu.BaseContainer.Find(szHorizontalGroup + "/Page_Dashboard");
                }
                return _buttonHorizontal;
            }
        }

        private static Transform _buttonTemplate = null;
        public static Transform buttonTemplate
        {
            get
            {
                if (_buttonTemplate == null)
                {
                    _buttonTemplate = menuDashboardTemplate?.Find(szVerticalLayoutGroup + "/Buttons_QuickActions/Button_Respawn");
                }
                return _buttonTemplate;
            }
        }

        private static Transform _buttonTextTemplate = null;
        public static Transform buttonTextTemplate
        {
            get
            {
                if (_buttonTextTemplate == null)
                {
                    _buttonTextTemplate = menuSettingsTemplate?.Find(szSettingsVerticalLayoutGroup + "/Buttons_Debug/Button_Build");
                }
                return _buttonTextTemplate;
            }
        }
        
        private static Transform _buttonGroupHeaderTemplate = null;
        public static Transform buttonGroupHeaderTemplate
        {
            get
            {
                if (_buttonGroupHeaderTemplate == null)
                {
                    _buttonGroupHeaderTemplate = menuDashboardTemplate?.Find(szVerticalLayoutGroup + "/Header_QuickActions");
                }
                return _buttonGroupHeaderTemplate;
            }
        }
        
        private static Transform _buttonGroupBaseTemplate = null;
        public static Transform buttonGroupBaseTemplate
        {
            get
            {
                if (_buttonGroupBaseTemplate == null)
                {
                    _buttonGroupBaseTemplate = menuDashboardTemplate?.Find(szVerticalLayoutGroup + "/Buttons_QuickActions");
                }
                return _buttonGroupBaseTemplate;
            }
        }

        private static Transform _menuTemplate = null;
        public static Transform menuTemplate
        {
            get
            {
                if (_menuTemplate == null)
                {
                    _menuTemplate = QuickMenu.BaseContainer.Find(szMenuGroup + "/Menu_DevTools");
                }
                return _menuTemplate;
            }
        }

        private static Transform _menuDashboard = null;
        public static Transform menuDashboardTemplate
        {
            get
            {
                if (_menuDashboard == null)
                {
                    _menuDashboard = QuickMenu.BaseContainer.transform.Find(szMenuGroup + "/Menu_Dashboard");
                }
                return _menuDashboard;
            }
        }
        
        private static Transform _menuSettingsTemplate = null;
        public static Transform menuSettingsTemplate
        {
            get
            {
                if (_menuSettingsTemplate == null)
                {
                    _menuSettingsTemplate = QuickMenu.BaseContainer.transform.Find(szMenuGroup + "/Menu_Settings");
                }
                return _menuSettingsTemplate;
            }
        }

        private static Transform _selectedMenuTemplate = null;
        public static Transform selectedMenuTemplate
        {
            get
            {
                if (_selectedMenuTemplate == null)
                {
                    _selectedMenuTemplate = QuickMenu.BaseContainer.transform.Find(szMenuGroup + "/Menu_SelectedUser_Local");
                }
                return _selectedMenuTemplate;
            }
        }

        public static string szHorizontalGroup = "Window/Page_Buttons_QM/HorizontalLayoutGroup";
        
        public static string szMenuGroup = "Window/QMParent";
        
        public static string szVerticalLayoutGroup = "ScrollRect/Viewport/VerticalLayoutGroup";

        public static string szSettingsVerticalLayoutGroup = "Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup";
    }
}
