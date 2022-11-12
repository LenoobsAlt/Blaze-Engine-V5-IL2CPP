using System;
using IL2CPP_Core.Objects;

namespace VRC.Core
{
    public class ApiPlayerModeration : ApiModel
    {
		public ApiPlayerModeration(IntPtr ptr) : base(ptr) { }


		public enum ModerationType
		{
			None,
			Block,
			Mute,
			Unmute,
			HideAvatar,
			ShowAvatar
		}

		public class ModerationType_Class : IL2Object
		{
			public ModerationType_Class(IntPtr ptr) : base(ptr) { }

			public static IL2Class Instance_Class = ApiPlayerModeration.Instance_Class.GetNestedType("ModerationType", ApiPlayerModeration.Instance_Class.FullName);
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRCCore-Standalone"].GetClass("ApiPlayerModeration", "VRC.Core");
    }
}