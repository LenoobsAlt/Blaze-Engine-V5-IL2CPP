using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.UI.Elements;
using BE4v.MenuEdit.Construct;
using CustomQuickMenu.Menus;

namespace BE4v.MenuEdit
{
    public static class Core
    {
        
        public static void Install()
        {
            // Remove Carousel & VRC+ Banners
            Delete();
            try
            {
                MainMenu.BlazeEngine4VersionMenu();
            }
            catch { }
            try
            {
                SelectedMenu.BlazeEngine4VersionMenu();
            }
            catch { }
            try
            {
                BE4VMenu.BlazeEngine4VersionMenu();
            }
            catch { }
            try
            {
                xGameMenu.BlazeEngine4VersionMenu();
            }
            catch { }
            
            /*try
            {
                CustomQuickMenu.Menus.Submenu.Effects.BlazeEngine4VersionMenu();
            }
            catch { }
            */
        }

        public static void Delete()
        {
            Transform transform = null;
            if (QuickMenu.Instance.transform.Find("CanvasGroup") != null)
            {
                transform = QuickMenuUtils.menuDashboardTemplate.Find(QuickMenuUtils.szVerticalLayoutGroup + "/VRC+_Banners");
                if (transform != null)
                {
                    RectTransform rect = new RectTransform(transform.Pointer);
                    rect.localScale = Vector3.zero;
                    rect.sizeDelta = Vector2.zero;
                }

                transform = QuickMenuUtils.menuDashboardTemplate.Find(QuickMenuUtils.szVerticalLayoutGroup + "/Carousel_Banners");
                if (transform != null)
                {
                    RectTransform rect = new RectTransform(transform.Pointer);
                    rect.localScale = Vector3.zero;
                    rect.sizeDelta = Vector2.zero;
                }
            }
            else
            {
                transform = QuickMenuUtils.menuDashboardTemplate.Find(QuickMenuUtils.szVerticalLayoutGroup + "/VRC+_Banners");
                if (transform != null)
                    transform.gameObject.Destroy();

                transform = QuickMenuUtils.menuDashboardTemplate.Find(QuickMenuUtils.szVerticalLayoutGroup + "/Carousel_Banners");
                if (transform != null)
                    transform.gameObject.Destroy();
            }
        }
    }
}
