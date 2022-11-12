using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE4v.Mods.Core;
using BE4v.Mods.Min;
using BE4v;
using BE4v.SDK;
using UnityEngine;


namespace BE4v.MenuEdit.IMGUI
{
    public class Console : IOnGUI
    {
        private Rect rectText;
        private static Vector2 scrollPosition = Vector2.zero;

        public static GUIStyle NormalStyle = null;
        public static GUIStyle TextStyle = null;

        public static void LoadStyle()
        {
            if (NormalStyle == null)
            {
                NormalStyle = new GUIStyle();
                NormalStyle.Static = true;
            }
            NormalStyle.normal.background = GenTexture2D(new Color32(0, 153, 153, 120));

            // TextStyle
            if (TextStyle == null)
            {
                TextStyle = new GUIStyle();
                TextStyle.Static = true;
            }
            TextStyle.fontSize = 12;
            TextStyle.normal.textColor = Color.white;
            // style.margin.left = 10;
        }

        public bool OnSize()
        {
            int screenHeight = Screen.height;
            int screenWidth = Screen.width;

            if (screenHeight < 1 || screenHeight < 1) return false;
            if (screenHeight < 230 || screenWidth < 370)
            {
                (screenHeight + "").RedPrefix("Height");
                (screenWidth + "").RedPrefix("Width");
                return false;
            }
            rectText = new Rect(screenWidth - 370, screenHeight - 230, 350, 200);
            
            return true;
        }

        public void OnGUI()
        {
            if (!BE4v.Mods.Status.isLog || TabMenu_PlayerList.isPressed)
                return;

            LoadStyle();
            Event m_Event = Event.current;
            if (!OnSize())
            {
                return;
            }

            string Messages = string.Empty;
            foreach(var message in ClientLogs.logs)
            {
                Messages += message + "\n";
            }

            GUILayout.BeginArea(rectText, NormalStyle);
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);
            GUILayout.Label(Messages, TextStyle);
            GUILayout.EndScrollView();
            GUILayout.EndArea();
        }

        public static Texture2D GenTexture2D(Color32 color)
        {
            Texture2D result = new Texture2D(1, 1, TextureFormat.ARGB32, false);
            result.SetPixel(0, 0, color);
            result.Apply();
            return result;
        }
    }
}
