using System;
using System.Linq;
using UnityEngine;
using IL2CPP_Core.Objects;

public class ChatBubbleController : MonoBehaviour
{
    public ChatBubbleController(IntPtr ptr) : base(ptr) { }

	public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetField("_characterLimit") != null);
}