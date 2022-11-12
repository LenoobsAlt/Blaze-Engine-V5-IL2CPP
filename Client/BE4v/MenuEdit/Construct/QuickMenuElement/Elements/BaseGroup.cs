using System;
using BE4v.MenuEdit.Construct;

namespace QuickMenuElement.Elements
{
    public class BaseGroup : QuickObject
    {
        public bool IsHeader
        {
            get
            {
                return gameObject?.name?.ToLower().StartsWith("header_") == true;
            }
        }

        public bool IsButtons
        {
            get
            {
                return gameObject?.name?.ToLower().StartsWith("buttons_") == true;
            }
        }
    }
}
