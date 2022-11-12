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
    public class QMButtonText : QuickObject
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
        
        public string _TextHeader
        {
            get
            {
                return gameObject?.transform.Find("Text_H1")?.GetComponent<TextMeshProUGUI>()?.text;
            }
            set
            {
                TextMeshProUGUI textMesh = gameObject?.transform.Find("Text_H1")?.GetComponent<TextMeshProUGUI>();
                if (textMesh != null)
                {
                    textMesh.text = value;
                }
            }
        }

        public static QMButtonText Create(ButtonsElement buttonsGroup, string buttonName, string header, UnityEngine.Events.UnityAction action = null)
        {
            QMButtonText QMbutton = new QMButtonText();
            QMbutton.gameObject = UnityEngine.Object.Instantiate(QuickMenuUtils.buttonTextTemplate.gameObject, buttonsGroup.gameObject.transform);
            QMbutton.gameObject.name = buttonName;

            QMbutton._Text = buttonName;
            QMbutton._TextHeader = header;

            Button button = QMbutton.gameObject.GetOrAddComponent<Button>();
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
