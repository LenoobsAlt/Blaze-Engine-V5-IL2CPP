using System;
using System.Collections.Generic;
using UnityEngine;

namespace BE4v.Utils
{
    public static class HighlightUtils
    {
        public static HighlightsFXStandalone GetLight(Color color)
        {
            string colorName = color.ToString();
            HighlightsFXStandalone highlight = null;
            list.TryGetValue(colorName, out highlight);
            if (highlight == null)
            {
                highlight = HighlightsFX.Instance.gameObject.AddComponent<HighlightsFXStandalone>();
                highlight.highlightColor = color;
                list.Add(colorName, highlight);
            }
            return highlight;
        }

        private static Dictionary<string, HighlightsFXStandalone> list = new Dictionary<string, HighlightsFXStandalone>();
    }
}
