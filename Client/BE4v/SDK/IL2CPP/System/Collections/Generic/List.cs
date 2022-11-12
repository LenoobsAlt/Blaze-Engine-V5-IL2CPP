using System;
using System.Linq;
using IL2CPP_Core.Objects;

namespace System.Collections.Generic
{
    unsafe public class IL2List : IL2Object
    {
        public IL2List(IntPtr ptr) : base(ptr) { }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass("List`1", "System.Collections.Generic");
    }

    unsafe public class IL2ListObject<T> : IL2List<IntPtr> where T : IL2Object
    {
        public IL2ListObject(IntPtr ptr) : base(ptr) { }

        public void Add(T item)
        {
            IL2Method method = Instance_Class.GetMethod("Add", x => x.ReturnType.Name == typeof(void).FullName);
            method.Invoke(this, new IntPtr[] { item == null ? IntPtr.Zero : item.Pointer, method.Pointer });
        }

        public bool Contains(T item)
        {
            IL2Method method = Instance_Class.GetMethod("Contains", x => x.GetParameters()[0].ReturnType.Name != typeof(object).FullName);
            return method.Invoke<bool>(this, new IntPtr[] { item == null ? IntPtr.Zero : item.Pointer, method.Pointer }).GetValue();
        }

        public bool Remove(T item)
        {
            IL2Method method = Instance_Class.GetMethod("Remove", x => x.ReturnType.Name == typeof(bool).FullName);
            return method.Invoke<bool>(this, new IntPtr[] { item == null ? IntPtr.Zero : item.Pointer, method.Pointer }).GetValue();
        }

        public new void Clear()
        {
            IL2Method method = Instance_Class.GetMethod("Clear");
            method.Invoke(this, new IntPtr[] { method.Pointer });
        }

        public new T[] ToArray()
        {
            IL2Method method = Instance_Class.GetMethod("ToArray");
            IL2Object result = method.Invoke(this, new IntPtr[] { method.Pointer });
            if (result == null)
                return null;

            return new IL2Array<IntPtr>(result.Pointer).ToArray<T>();
        }

        public static new IL2Class Instance_Class = IL2List.Instance_Class.MakeGenericType(new Type[] { typeof(T) });
    }

    unsafe public class IL2List<T> : IL2List where T : unmanaged
    {
        public IL2List(IntPtr ptr) : base(ptr) { }

        public void Add(T item)
        {
            IL2Method method = Instance_Class.GetMethod("Add", x => x.ReturnType.Name == typeof(void).FullName);
            method.Invoke(this, new IntPtr[] { new IntPtr(&item), method.Pointer });
        }

        public bool Contains(T item)
        {
            IL2Method method = Instance_Class.GetMethod("Contains", x => x.GetParameters()[0].ReturnType.Name != typeof(object).FullName);
            return method.Invoke<bool>(this, new IntPtr[] { new IntPtr(&item), method.Pointer }).GetValue();
        }

        public bool Remove(T item)
        {
            IL2Method method = Instance_Class.GetMethod("Remove", x => x.ReturnType.Name == typeof(bool).FullName);
            return method.Invoke<bool>(this, new IntPtr[] { new IntPtr(&item), method.Pointer }).GetValue();
        }

        public void Clear()
        {
            IL2Method method = Instance_Class.GetMethod("Clear");
            method.Invoke(this, new IntPtr[] { method.Pointer });
        }

        public T[] ToArray()
        {
            IL2Method method = Instance_Class.GetMethod("ToArray");
            IL2Object result = method.Invoke(this, new IntPtr[] { method.Pointer });
            if (result == null)
                return null;

            return new IL2Array<T>(result.Pointer).ToArray();
        }

        public T2[] ToArray<T2>() where T2 : IL2Object
        {
            IL2Method method = Instance_Class.GetMethod("ToArray");
            IL2Object result = method.Invoke(this, new IntPtr[] { method.Pointer });
            if (result == null)
                return null;

            return new IL2Array<IntPtr>(result.Pointer).ToArray<T2>();
        }

        public static new IL2Class Instance_Class = IL2List.Instance_Class.MakeGenericType(new Type[] { typeof(T) });
    }
}
