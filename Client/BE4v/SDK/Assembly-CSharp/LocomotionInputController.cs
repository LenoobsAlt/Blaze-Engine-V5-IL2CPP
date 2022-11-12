using System;
using System.Linq;
using IL2CPP_Core.Objects;

public class LocomotionInputController : InputStateController
{
    public LocomotionInputController(IntPtr ptr) : base(ptr) { }

    public VRCInput inJump
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(inJump));
            if (field == null)
                (field = Instance_Class.GetFields().Last(x => x.ReturnType.Name == VRCInput.Instance_Class.FullName)).Name = nameof(inJump);

            return field?.GetValue(this)?.GetValue<VRCInput>();
        }
    }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass(PlayerModComponentJump.Instance_Class.GetField(x => !x.ReturnType.Name.StartsWith("System")).ReturnType.Name);
}