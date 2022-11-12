using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VRC.UI.Elements;
using VRC.UI.Elements.Controls;
using VRC.UI.Elements.Tooltips;

namespace BE4v.MenuEdit.Construct.Horizontal
{
    public class ElementHorizontalButton : QuickObject
    {
        public ElementHorizontalButton(string buttonName, UnityAction action, string tooltip = "", Sprite sprite = null)
        {
            gameObject = UnityEngine.Object.Instantiate(QuickMenuUtils.buttonHorizontal.gameObject, QuickMenuUtils.buttonHorizontal.parent);
            gameObject.name = "Page_" + buttonName;

            MenuTab menuTab = gameObject.GetComponent<MenuTab>();
            menuTab.pageName = "QuickMenu" + buttonName;
            menuTab.menuStateController = QuickMenu.Instance.MenuStateController;

            Button button = gameObject.GetComponent<Button>();
            if (button.onClick == null)
                button.onClick = new Button.ButtonClickedEvent();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(action);

            UiTooltip uiTooltip = gameObject.GetComponent<UiTooltip>();
            uiTooltip.text = tooltip;
            uiTooltip.alternateText = tooltip;

            if (sprite != null)
                SetSprite(sprite);

            gameObject.SetActive(true);
        }

        public void SetSprite(Sprite sprite)
        {
            Image image = gameObject.transform.Find("Icon").GetComponent<Image>();
            image.sprite = sprite;
            image.overrideSprite = sprite;
        }
    }
}
