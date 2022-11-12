using System;
using System.Linq;
using IL2CPP_Core.Objects;

namespace VRC.SDKBase.Validation.Performance
{
    public static class AvatarPerformance
    {
        public static IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod(PerformanceScannerSet.Instance_Class) != null);
    }
}
