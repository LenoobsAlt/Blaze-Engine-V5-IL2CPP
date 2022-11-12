using UnityEngine;
using VRC;
using BE4v.MenuEdit;
using BE4v.Mods.Core;
using CustomQuickMenu.Menus;

namespace BE4v.Mods.Min
{
    public class SpeedHack : IUpdate
    {
        public static void Toggle()
        {
            Status.isSpeedHack = !Status.isSpeedHack;
            MainMenu.SpeedHackToggle.Refresh();
        }

        public void Update()
        {
            if (Threads.isCtrl)
            {
                if (Input.GetKeyDown(KeyCode.G))
                {
                    Toggle();
                    return;
                }
            }

            if (!Status.isSpeedHack) return;
            CharacterController controller = Player.Instance.GetComponent<CharacterController>();
            Vector3 vector = Vector3.zero;
            Vector3 velocity = controller.velocity;
            if (Status.isSpeedHack)
            {
                vector[0] = velocity.x / 200 * Status.iSpeedHackSpeed;
                vector[2] = velocity.z / 200 * Status.iSpeedHackSpeed;
            }
            if (vector != Vector3.zero)
                controller.Move(vector);
        }
    }
}