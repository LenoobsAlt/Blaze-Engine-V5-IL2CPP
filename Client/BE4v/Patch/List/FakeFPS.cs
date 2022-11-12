using System;
using UnityEngine;
using IL2CPP_Core.Objects;
using BE4v.Mods;
using BE4v.SDK;
using BE4v.Patch.Core;

namespace BE4v.Patch.List
{
    public class FakeFPS: IPatch
    {
        public delegate float _get_smoothDeltaTime();

        public static void Toggle()
        {
            Status.isFakeFPS = !Status.isFakeFPS;
            CustomQuickMenu.Menus.BE4VMenu.FakeFPS.Refresh();
        }

        public void Start()
        {
            IL2Method method = Time.Instance_Class.GetProperty("smoothDeltaTime").GetGetMethod();
            if (method != null)
            {
                patch = new IL2Patch(method, (_get_smoothDeltaTime)get_smoothDeltaTime);
                __get_smoothDeltaTime = patch.CreateDelegate<_get_smoothDeltaTime>();
                patch.Enabled = false;
            }
            else
                throw new NullReferenceException();
        }

        private static float get_smoothDeltaTime()
        {
            float result = 1f / 200;
            if (!Status.isFakeFPS)
                result = __get_smoothDeltaTime();
            return result;
        }

        public static IL2Patch patch;

        public static _get_smoothDeltaTime __get_smoothDeltaTime;
    }
}
