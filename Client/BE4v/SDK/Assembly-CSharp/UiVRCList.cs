using System;
using System.Linq;
using System.Collections.Generic;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.Core;

public abstract class UiVRCList : MonoBehaviour
{
    public UiVRCList(IntPtr ptr) : base(ptr) { }

    static UiVRCList()
    {
        // 
        // Find: protected abstract void FetchAndRenderElements(int page);
        // 
        Instance_Class.GetMethod(x => x.IsAbstract && x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == typeof(int).FullName).Name = nameof(FetchAndRenderElements);

        // 
        // Find: protected void StartRenderElementsCoroutine<T>(List<T> list, int offset = 0, bool endOfPickers = true, [Optional] VRCUiContentButton contentHeaderElement)
        // 
        Instance_Class.GetMethod(x => x.ReturnType.Name == typeof(void).FullName
            && x.GetParameters().Length == 4
            && x.GetParameters()[1].ReturnType.Name == typeof(int).FullName
            && x.GetParameters()[2].ReturnType.Name == typeof(bool).FullName
            ).Name = nameof(StartRenderElementsCoroutine);
    }

    public void Refresh()
    {
        FetchAndRenderElements(currentPage);
    }

    public void FetchAndRenderElements(int page)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(FetchAndRenderElements));
        if (method == null)
        {
            "Not found function!".RedPrefix("UiVRCList::FetchAndRenderElements");
            return;
        }
        unsafe
        {
            method.Invoke(this, new IntPtr[] { new IntPtr(&page) }, true);
        }
    }
    
    public void StartRenderElementsCoroutine<T>(IL2ListObject<T> list, int offset = 0, bool endOfPickers = true, VRCUiContentButton contentHeaderElement = null) where T : IL2Object
    {
        IL2Method method = Instance_Class.GetMethod(nameof(StartRenderElementsCoroutine));
        if (method == null)
        {
            "Not found function!".RedPrefix("UiVRCList::StartRenderElementsCoroutine");
            return;
        }
        unsafe
        {
            method.Invoke(this, new IntPtr[] { list == null ? IntPtr.Zero : list.Pointer, new IntPtr(&offset), new IntPtr(&endOfPickers), contentHeaderElement == null ? IntPtr.Zero : contentHeaderElement.Pointer, method.Pointer }, true);
        }
    }

    // Alternative
    public void ClearList()
    {
        int count = pickers.ToArray().Length;
        ClearListRange(0, count);
    }

    unsafe public void ClearListRange(int offset, int count)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(ClearListRange));
        if (method == null)
        {
            (method = Instance_Class.GetMethod(x => x.GetParameters().Length == 2
                && x.GetParameters()[0].ReturnType.Name == typeof(int).FullName
                && x.GetParameters()[1].ReturnType.Name == typeof(int).FullName
            )).Name = nameof(ClearListRange);
            if (method == null)
                return;
        }
        method.Invoke(this, new IntPtr[] { new IntPtr(&offset), new IntPtr(&count) });
    }

    unsafe public int currentPage
    {
        get => Instance_Class.GetField(x => x.Token == 0xC4).GetValue<int>(this).GetValue();
        set => Instance_Class.GetField(x => x.Token == 0xC4).SetValue(this, new IntPtr(&value));
    }

    unsafe public int extendRows
    {
        get => Instance_Class.GetField(nameof(extendRows)).GetValue<int>(this).GetValue();
        set => Instance_Class.GetField(nameof(extendRows)).SetValue(this, new IntPtr(&value));
    }

    unsafe public float expandedHeight
    {
        get => Instance_Class.GetField(nameof(expandedHeight)).GetValue<float>(this).GetValue();
        set => Instance_Class.GetField(nameof(expandedHeight)).SetValue(this, new IntPtr(&value));
    }
    
    public IL2ListObject<VRCUiContentButton> pickers
    {
        get
        {
            IL2Object result = Instance_Class.GetField(nameof(pickers)).GetValue(this);
            if (result == null)
                return null;

            return new IL2ListObject<VRCUiContentButton>(result.Pointer);
        }
        set => Instance_Class.GetField(nameof(pickers)).SetValue(this, value == null ? IntPtr.Zero : value.Pointer);
    }


    public IL2Dictionary<IL2Int32, IL2ListObject<ApiModel>> paginatedLists
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(paginatedLists));
            if (field == null)
            {
                (field = Instance_Class.GetField(x => x.ReturnType.Name.StartsWith("System.Collections.Generic.Dictionary<" + typeof(int).FullName + ","))).Name = nameof(paginatedLists);
                if (field == null)
                {
                    "Not found field!".RedPrefix("UiAvatarList::paginatedLists");
                    return null;
                }
            }
            IL2Object result = field.GetValue(this);
            if (result == null)
                return null;
            return new IL2Dictionary<IL2Int32, IL2ListObject<ApiModel>>(result.Pointer);
        }
    }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass(UiAvatarList.Instance_Class.BaseType.FullName);
}