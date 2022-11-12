using UnityEngine;
using VRC;
using BE4v.Mods.Core;

namespace BE4v.Mods.Min
{
    public class ForceCloneAvatar : IUpdate
    {
        public void Update()
        {
            CustomQuickMenu.Menus.SelectedMenu.ForceCloneAvatar.Update();
        }
    }
}
