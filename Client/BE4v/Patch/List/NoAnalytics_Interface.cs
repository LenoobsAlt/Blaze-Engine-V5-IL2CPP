using System;
using IL2CPP_Core.Objects;
using BE4v.SDK;
using BE4v.Patch.Core;

namespace BE4v.Patch.List
{
    public class NoAnalytics_Interface : IPatch
    {
        public delegate void _VRC_Core_AnalyticsInterface_Send_3(IntPtr eventType, IntPtr eventProperties, IntPtr options);
        public void Start()
        {
            IL2Method method = IL2CPP.AssemblyList["VRCCore-Standalone"].GetClass("AnalyticsInterface", "VRC.Core").GetMethod("Send", x => x.GetParameters().Length == 3);
            if (method != null)
            {
                new IL2Patch(method, (_VRC_Core_AnalyticsInterface_Send_3)VRC_Core_AnalyticsInterface_Send_3);
            }
            else
                throw new NullReferenceException();
        }

        private static void VRC_Core_AnalyticsInterface_Send_3(IntPtr eventType, IntPtr eventProperties, IntPtr options)
        {
        }
    }
}
