using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;
using VRC.UI.Elements.Menus;
using TMPro;
using BE4v.MenuEdit.Construct;


namespace QuickMenuElement.Elements
{
    public class QMButton : QuickObject
    {
        public Sprite _Sprite
        {
            get
            {
                return gameObject?.transform.Find("Icon")?.GetComponent<Image>()?.sprite;
            }
            set
            {
                Image image = gameObject?.transform.Find("Icon")?.GetComponent<Image>();
                if (image != null)
                {
                    image.sprite = value;
                    image.overrideSprite = value;
                }
            }
        }

        public string _Text
        {
            get
            {
                return gameObject?.transform.Find("Text_H4")?.GetComponent<TextMeshProUGUI>()?.text;
            }
            set
            {
                TextMeshProUGUI textMesh = gameObject?.transform.Find("Text_H4")?.GetComponent<TextMeshProUGUI>();
                if (textMesh != null)
                {
                    textMesh.text = value;
                }
            }
        }

        public static QMButton Create(ButtonsElement buttonsGroup, string buttonName, UnityEngine.Events.UnityAction action = null)
        {
            QMButton QMbutton = new QMButton();
            QMbutton.gameObject = UnityEngine.Object.Instantiate(QuickMenuUtils.buttonTemplate.gameObject, buttonsGroup.gameObject.transform);
            QMbutton.gameObject.name = buttonName;

            QMbutton._Text = buttonName;

            Button button = QMbutton.gameObject.GetComponentInChildren<Button>(true);
            if (button.onClick == null)
                button.onClick = new Button.ButtonClickedEvent();
            button.onClick.RemoveAllListeners();
            if (action != null)
                button.onClick.AddListener(action);

            QMbutton.gameObject.SetActive(true);
            return QMbutton;
        }
    }
}
