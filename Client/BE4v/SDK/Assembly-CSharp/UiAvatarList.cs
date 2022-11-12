using System;
using System.Linq;
using System.Collections.Generic;
using IL2CPP_Core.Objects;
using VRC.Core;
using BE4v.SDK;

public class UiAvatarList : UiVRCList
{
    public UiAvatarList(IntPtr ptr) : base(ptr) { }

    static UiAvatarList()
    {
        // Find: specificListIds
        Instance_Class.GetField(x => x.ReturnType.Name == "System.String[]").Name = nameof(specificListIds);
        // Find: category
        Instance_Class.GetField(x => x.ReturnType.Name.StartsWith(Instance_Class.FullName)).Name = nameof(category);
        // Find Method: SingleAvatarAvailable
        Instance_Class.GetMethod(x => x.ReturnType.Name == typeof(void).FullName && x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == ApiContainer.Instance_Class.FullName).Name = nameof(SingleAvatarAvailable);
        // Find Method: FetchAndRenderElements(int page)
        IL2Method method = UiVRCList.Instance_Class.GetMethod(nameof(FetchAndRenderElements));
        Instance_Class.GetMethod(method.OriginalName).Name = nameof(FetchAndRenderElements);
    }

    public new void Refresh()
    {
        FetchAndRenderElements(currentPage);
    }

    public new void FetchAndRenderElements(int page)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(FetchAndRenderElements));
        if (method == null)
        {
            "Not found function!".RedPrefix("UiAvatarList::FetchAndRenderElements");
            return;
        }
        unsafe
        {
            method.Invoke(this, new IntPtr[] { new IntPtr(&page) }, true);
        }
    }
    public void SingleAvatarAvailable(ApiContainer container)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(SingleAvatarAvailable));
        if (method == null)
        {
            "Not found function!".RedPrefix("UiAvatarList::SingleAvatarAvailable");
            return;
        }
        method.Invoke(this, new IntPtr[] { container == null ? IntPtr.Zero : container.Pointer });
    }

    public string[] specificListIds
    {
        get
        {
            IL2Object result = Instance_Class.GetField(nameof(specificListIds)).GetValue(this);
            if (result == null)
                return null;

            IL2String[] array = new IL2Array<IntPtr>(result.Pointer).ToArray<IL2String>();
            return array.Select(x => x.ToString()).ToArray();
        }
        set
        {
            int len = value.Length;
            IL2Array<IntPtr> array = null;
            if (value != null)
            {
                array = new IL2Array<IntPtr>(len, IL2String.Instance_Class);
                for(int i=0;i<len;i++)
                {
                    array[i] = new IL2String_utf8(value[i]).Pointer;
                }
            }
            Instance_Class.GetField(nameof(specificListIds)).SetValue(this, array == null ? IntPtr.Zero : array.Pointer);
        }
    }

    unsafe public Category category
    {
        get => Instance_Class.GetField(nameof(category)).GetValue<Category>(this).GetValue();
        set => Instance_Class.GetField(nameof(category)).SetValue(this, new IntPtr(&value));
    }
    
    public IL2Dictionary<IL2String, ApiAvatar> specificListValues
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(specificListValues));
            if (field == null)
            {
                (field = Instance_Class.GetField(x => x.ReturnType.Name == "System.Collections.Generic.Dictionary<System.String," + ApiAvatar.Instance_Class.FullName + ">")).Name = nameof(specificListValues);
                if (field == null)
                {
                    "Not found field!".RedPrefix("UiAvatarList::specificListValues");
                    return null;
                }
            }
            return field.GetValue(this)?.GetValue<IL2Dictionary<IL2String, ApiAvatar>>();
        }
    }
    
    /*
    public IL2HashSet HashSet_field
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(HashSet_field));
            if (field == null)
            {
                (field = Instance_Class.GetField(x => x.ReturnType.Name.StartsWith("System.Collections.Generic.HashSet"))).Name = nameof(HashSet_field);
                if (field == null)
                {
                    "Not found field!".RedPrefix("UiAvatarList::HashSet_field");
                    return null;
                }
            }
            IL2Object result = field.GetValue(ptr);
            if (result == null)
                return null;
            return new IL2HashSet(result.ptr);
        }
    }
    */

    public enum Category
    {
        Internal,
        Public,
        Mine,
        Favorite,
        SpecificList,
        PublicQuest,
        Classic,
        Licensed,
        PublicFallback,
        MineFallback
    }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetField(y => y.ReturnType.Name == "System.Collections.Generic.Dictionary<System.String," + ApiAvatar.Instance_Class.FullName + ">") != null);
}