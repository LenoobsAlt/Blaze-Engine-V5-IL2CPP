using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

public class HighlightsFXMobile : HighlightsFX
{
    public HighlightsFXMobile(IntPtr ptr) : base(ptr) { }

    public HighlightsFXMobile() : base(IntPtr.Zero)
    {
        Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
        Instance_Class.GetMethod(".ctor").Invoke(Pointer);
    }

    unsafe public Color highlightColor
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(highlightColor));
            if (field == null)
                (field = Instance_Class.GetField(Color.Instance_Class)).Name = nameof(highlightColor);

            return field.GetValue<Color>(this).GetValue();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(highlightColor));
            if (field == null)
                (field = Instance_Class.GetField(Color.Instance_Class)).Name = nameof(highlightColor);

            field.SetValue(this, new IntPtr(&value));
        }
    }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetField("mobilePulseSpeed") != null);
}
