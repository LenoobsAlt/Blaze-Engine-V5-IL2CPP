using System;
using System.Reflection;
using IL2CPP_Core.Objects;

namespace System.Collections.Generic
{
	unsafe public class IL2Dictionary : IL2Object
	{
		public IL2Dictionary(IntPtr ptrNew) : base(ptrNew) { }

		public int Count
		{
			get => Instance_Class.GetProperty(nameof(Count)).GetGetMethod().Invoke<int>(this).GetValue();
		}

		public void Clear()
		{
			Instance_Class.GetMethod(nameof(Clear)).Invoke(this, ex: false);
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass("Dictionary`2", "System.Collections.Generic");
	}

	unsafe public class IL2Dictionary<TKey, TValue> : IL2Dictionary
	{
		public IL2Dictionary(IntPtr ptrNew) : base(ptrNew) { }

		public IL2Object this[IL2Object key]
		{
			get
			{
				IL2Method method = Instance_Class.GetProperty("Item").GetGetMethod();
				return method.Invoke(this, new IntPtr[] { key.Pointer, method.Pointer });
			}
			set
			{
				IL2Method method = Instance_Class.GetProperty("Item").GetSetMethod();
				method.Invoke(this, new IntPtr[] { key.Pointer, value.Pointer, method.Pointer });
			}
		}

		public int FindEntry(IntPtr key)
		{
			IL2Method method = Instance_Class.GetMethod("FindEntry");
			return method.Invoke<int>(this, new IntPtr[] { key, method.Pointer }).GetValue();
		}

		public void Add(IntPtr key, IntPtr value)
		{
			IL2Method method = Instance_Class.GetMethod("Add");
			method.Invoke(this, new IntPtr[] { key, value, method.Pointer });
		}

		public bool Remove(IntPtr key)
		{
			IL2Method method = Instance_Class.GetMethod("Remove");
			return method.Invoke<bool>(this, new IntPtr[] { key, method.Pointer }).GetValue();
		}

		public static new IL2Class Instance_Class = IL2Dictionary.Instance_Class.MakeGenericType(new Type[] { typeof(TKey), typeof(TValue) });
	}
}
