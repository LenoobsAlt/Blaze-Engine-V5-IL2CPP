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
    public class ButtonsElement : BaseGroup
    {
        public QMButton this[string key]
        {
            get
            {
                if (gameObject != null)
                {
                    Transform transform = gameObject.transform;
                    foreach (Transform obj in transform)
                    {
                        if (obj.gameObject.name.ToLower() == ("Button_" + key).ToLower())
                        {
                            QMButton button = new QMButton();
                            button.gameObject = obj.gameObject;
                            return button;
                        }
                    }
                }
                return null;
            }
        }

        public QMButton[] _Buttons
        {
            get
            {
                List<QMButton> buttons = new List<QMButton>();
                if (gameObject != null)
                {
                    Transform transform = gameObject.transform;
                    foreach (Transform obj in transform)
                    {
                        if (obj.gameObject.name.ToLower().StartsWith("Button_".ToLower()))
                        {
                            QMButton button = new QMButton();
                            button.gameObject = obj.gameObject;
                            buttons.Add(button);
                        }
                    }
                }
                return buttons.ToArray();
            }
        }

        public void DestroyAllButtons()
        {
            Transform transform = gameObject?.transform;
            if (transform != null)
            {
                foreach (Transform obj in transform)
                {
                    obj.gameObject?.Destroy();
                }
            }
        }

        public QMButton AddButton(string buttonName, UnityEngine.Events.UnityAction action = null)
        {
            return QMButton.Create(this, buttonName, action);
        }
        
        public QMButtonText AddButtonText(string buttonName, string header, UnityEngine.Events.UnityAction action = null)
        {
            return QMButtonText.Create(this, buttonName, header, action);
        }

        public static ButtonsElement Create(MenuElement menu, string name)
        {
            ButtonsElement element = new ButtonsElement();
            element.gameObject = UnityEngine.Object.Instantiate(QuickMenuUtils.buttonGroupBaseTemplate.gameObject, menu.verticalLayoutGroup.gameObject.transform);
            element.gameObject.name = "Buttons_" + name;
            
            element.DestroyAllButtons();

            return element;
        }
    }
}
