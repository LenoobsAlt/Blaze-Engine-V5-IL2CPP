using System;
using IL2CPP_Core.Objects;
using UnityEngine;

public abstract class HighlightsFX : PostEffectsBase
{
    public HighlightsFX(IntPtr ptr) : base(ptr) { }

    public static HighlightsFX Instance
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(Instance));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
            return property?.GetGetMethod().Invoke()?.GetValue<HighlightsFXStandalone>();
        }
    }

    unsafe public static void EnableObjectHighlight(Renderer outlineRenderer, bool enable)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(EnableObjectHighlight));
        if (method == null)
            (method = Instance_Class.GetMethod(x => x.GetParameters().Length == 2 && x.IsStatic)).Name = nameof(EnableObjectHighlight);
        method.Invoke(new IntPtr[] { outlineRenderer == null ? IntPtr.Zero : outlineRenderer.Pointer, new IntPtr(&enable) });
    }

    unsafe public void EnableOutline(Renderer outlineRenderer, bool enable)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(EnableOutline));
        if (method == null)
            (method = Instance_Class.GetMethod(x => x.GetParameters().Length == 2 && !x.IsStatic)).Name = nameof(EnableOutline);
        method.Invoke(this, new IntPtr[] { outlineRenderer == null ? IntPtr.Zero : outlineRenderer.Pointer, new IntPtr(&enable) });
    }

    public static new IL2Class Instance_Class = HighlightsFXStandalone.Instance_Class.BaseType;
}
