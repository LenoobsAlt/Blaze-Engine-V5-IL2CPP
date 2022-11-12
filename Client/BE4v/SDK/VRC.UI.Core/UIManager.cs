using System;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.UI.Elements;

namespace VRC.UI.Core
{
    public class UIManager : MonoBehaviour
    {
        public UIManager(IntPtr ptr) : base(ptr) { }
        public static UIManager Instance
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(Instance));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
                return property?.GetGetMethod().Invoke()?.GetValue<UIManager>();
            }
        }
        public static new IL2Class Instance_Class = Client.VRCUiManager.Instance_Class.BaseType;
    }
}