using System;
using UnityEngine.Analytics;
using IL2CPP_Core.Objects;
using BE4v.SDK;
using BE4v.Patch.Core;

namespace BE4v.Patch.List
{
    public class NoAnalytics_Unity : IPatch
    {
        public delegate AnalyticsResult _UnityEngine_Analytics_CustomEvent();
        public void Start()
        {
            IL2Method method = IL2CPP.AssemblyList["UnityEngine.UnityAnalyticsModule"].GetClass("Analytics", "UnityEngine.Analytics").GetMethod(x => x.Name == "CustomEvent" && x.GetParameters().Length == 2 && x.GetParameters()[1].Name == "eventData");
            if (method != null)
            {
                new IL2Patch(method, (_UnityEngine_Analytics_CustomEvent)UnityEngine_Analytics_CustomEvent);
            }
            else
                throw new NullReferenceException();
        }

        private static AnalyticsResult UnityEngine_Analytics_CustomEvent()
        {
            return AnalyticsResult.Ok;
        }
    }
}
