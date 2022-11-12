using System;
using System.Linq;
using UnityEngine;
using VRC.UI.Client.HUD;
using IL2CPP_Core.Objects;

public class VRCUiManager : MonoBehaviour
{
    public VRCUiManager(IntPtr ptr) : base(ptr) { }

    public static VRCUiManager Instance
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(Instance));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
            return property?.GetGetMethod().Invoke()?.GetValue<VRCUiManager>();
        }
    }

    public static T GetPage<T>(string screenPath) where T : VRCUiPage
	{
        return GameObject.Find(screenPath)?.GetComponent<T>();
    }

	public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetField(HudController.Instance_Class) != null && x.GetField("_dragMenuPanel") != null);
}