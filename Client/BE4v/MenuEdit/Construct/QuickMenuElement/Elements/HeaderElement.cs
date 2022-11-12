using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using BE4v.MenuEdit.Construct;

namespace QuickMenuElement.Elements
{
    public class HeaderElement : BaseGroup
    {
        public string _Text
        {
            get
            {
                return gameObject?.transform.Find("LeftItemContainer/Text_Title")?.GetComponent<TextMeshProUGUI>()?.text;
            }
            set
            {
                TextMeshProUGUI textMesh = gameObject?.transform.Find("LeftItemContainer/Text_Title")?.GetComponent<TextMeshProUGUI>();
                if (textMesh != null)
                {
                    textMesh.text = value;
                }
            }
        }

        public static HeaderElement Create(MenuElement menu, string name)
        {
            HeaderElement element = new HeaderElement();
            element.gameObject = UnityEngine.Object.Instantiate(QuickMenuUtils.buttonGroupHeaderTemplate.gameObject, menu.verticalLayoutGroup.gameObject.transform);
            element.gameObject.name = "Header_" + name;

            element._Text = name;

            return element;
        }
    }
}
