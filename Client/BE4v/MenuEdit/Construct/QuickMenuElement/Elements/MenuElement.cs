using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using VRC.UI.Elements;
using VRC.UI.Elements.Menus;
using BE4v.MenuEdit.Construct;

namespace QuickMenuElement.Elements
{
    public class MenuElement : QuickObject
    {
        public VerticalLayoutGroup verticalLayoutGroup
        {
            get
            {
                Transform transform = gameObject?.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup");
                if (transform == null)
                {
                    transform = gameObject?.transform.Find("Scrollrect/Viewport/VerticalLayoutGroup");
                }
                return transform?.GetComponent<VerticalLayoutGroup>();
            }
        }

        public void SetText(string text)
        {
            TextMeshProUGUI title = gameObject?.transform.Find("Header_H1/LeftItemContainer/Text_Title")?.GetComponent<TextMeshProUGUI>();
            if (title == null)
            {
                title = gameObject?.transform.Find("Header_DevTools/LeftItemContainer/Text_Title")?.GetComponent<TextMeshProUGUI>();
            }
            if (title != null)
            {
                title.text = text;
                title.richText = true;
            }
        }

        public void Open()
        {
            gameObject.SetActive(true);
            QuickMenu.Instance.MenuStateController.PushPage(gameObject.name);
        }

        public HeaderElement AddHeader(string name)
        {
            return HeaderElement.Create(this, name);
        }

        public ButtonsElement AddButtonsGroup(string name)
        {
            return ButtonsElement.Create(this, name);
        }

        public static MenuElement Create(string name, bool root = true)
        {
            /*
            ScrollRect component = base.RectTransform.Find("Scrollrect").GetComponent<ScrollRect>();
            this._container = component.content;
                        */
            MenuElement element = new MenuElement();
            element.gameObject = UnityEngine.Object.Instantiate(QuickMenuUtils.menuTemplate.gameObject, QuickMenuUtils.menuTemplate.parent);
            element.gameObject.name = "Menu_" + name;
            element.gameObject.SetActive(true);

            Transform transform = element.gameObject.transform;
            transform.SetSiblingIndex(5);

            UnityEngine.Object.DestroyImmediate(transform.gameObject.GetComponent<DevMenu>());
            transform.gameObject.GetOrAddComponent<UIPage>()?.Destroy();

            UIPage uiPage = element.gameObject.AddComponent<UIPage>();
            uiPage.Name = "QuickMenu" + name;
            // this.UiPage.field_Private_Boolean_1 = true;
            uiPage._menuStateController = QuickMenu.Instance.MenuStateController;
            // this.UiPage.field_Private_List_1_UIPage_0 = new List<UIPage>();
            // this.UiPage.field_Private_List_1_UIPage_0.Add(this.UiPage);


            VerticalLayoutGroup verticalLayoutGroup = element.verticalLayoutGroup;
            if (verticalLayoutGroup != null)
            {
                transform = verticalLayoutGroup.transform;
                foreach (Transform obj in transform)
                {
                    UnityEngine.Object.Destroy(obj.gameObject);
                }

                verticalLayoutGroup.childControlHeight = false;
            }

            QuickMenu.Instance.MenuStateController._uiPages.Add(new IL2String_utf16("Menu_" + name), uiPage);
            
            if (root)
            {
                List<UIPage> uIPages = QuickMenu.Instance.MenuStateController.menuRootPages.ToList();
                uIPages.Add(uiPage);
                QuickMenu.Instance.MenuStateController.menuRootPages = uIPages.ToArray();
            }

            element.SetText(name);

            ScrollRect scrollRect = element.gameObject.transform.Find("Scrollrect").GetComponent<ScrollRect>();
            Transform scrollbarTransform = scrollRect.transform.Find("Scrollbar");
            scrollbarTransform.gameObject.SetActive(true);

            scrollRect.enabled = true;
            scrollRect.verticalScrollbar = scrollbarTransform.GetComponent<Scrollbar>();
            scrollRect.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.Permanent;
            scrollRect.viewport.GetComponent<RectMask2D>().enabled = false;

            RectMask2D mask = verticalLayoutGroup?.transform.parent.GetComponent<RectMask2D>();
            if (mask != null)
                mask.enabled = true;

            element.gameObject.SetActive(false);

            return element;
        }
    }
}
