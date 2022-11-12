using System;
using IL2CPP_Core.Objects;
using BE4v.SDK;
using BE4v.Patch.Core;

namespace BE4v.Patch.List
{
    public class NoAnalytics_SendGen : IPatch
    {
        public delegate void _Analytics_SendOrSendError(IntPtr arg1, IntPtr arg2, IntPtr arg3);
        public void Start()
        {
            IL2Method method = Analytics.Instance_Class.GetMethod(x => x.ReturnType.Name == typeof(void).FullName && x.GetParameters().Length == 3 && x.GetParameters()[0].ReturnType.Name.StartsWith(x.ReflectedType.FullName) && x.GetParameters()[1].ReturnType.Name.StartsWith("System.Collections.Generic") && x.IsStatic);
            if (method != null)
            {
                new IL2Patch(method, (_Analytics_SendOrSendError)Analytics_SendOrSendError);
            }
            else
                throw new NullReferenceException();
        }
        
        private static void Analytics_SendOrSendError(IntPtr arg1, IntPtr arg2, IntPtr arg3)
        {

        }
    }
}
