using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BE4v.MenuEdit.Construct;

namespace BE4v.NotifySystem
{
    public static class Notify
    {
        public static bool isEnabled = false;
        public static void OnGUI()
        {
            if (isEnabled)
            {
                int SizeX1 = Screen.width / 3;

                GUILayout.BeginArea(new Rect(SizeX1-30, 50, 30, 30), LoadSprites.notifyIco.texture);
                GUILayout.EndArea();

                GUILayout.BeginArea(new Rect(SizeX1, 45, SizeX1, 30), GUI.skin.box);

                GUILayout.Button("I'm the bottom button");

                GUILayout.EndArea();
            }
        }
    }
}
