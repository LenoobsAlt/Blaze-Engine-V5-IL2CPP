using System;
using System.Runtime.InteropServices;
using IL2CPP_Core.Objects;
namespace System
{
	public class IL2Array<T> : IL2Object where T : unmanaged
	{
		public IL2Array(int length, IL2Class typeobject = null) : base(IntPtr.Zero)
		{
			if (typeobject == null)
				typeobject = IL2ObjectSystem.Instance_Class;

			Pointer = Import.Object.il2cpp_array_new(typeobject.Pointer, (ulong)length);
		}

		public IL2Array(IntPtr ptr) : base(ptr) { }

		unsafe public T this[int index]
		{
			get
			{
				if (index < 0 || index >= Length)
				{
					throw new ArgumentOutOfRangeException();
				}
				return *(T*)((byte*)IntPtr.Add(Pointer, 4 * IntPtr.Size).ToPointer() + index * sizeof(T));
			}
			set
			{
				if (index < 0 || index >= Length)
				{
					throw new ArgumentOutOfRangeException();
				}
				*(T*)((byte*)IntPtr.Add(Pointer, 4 * IntPtr.Size).ToPointer() + index * sizeof(T)) = value;
			}
		}

		public int Length
		{
			get
			{
				int result;
				if (typeof(T) == typeof(byte))
				{
					result = (int)Import.Object.il2cpp_array_get_byte_length(Pointer);
				}
				else
				{
					result = Import.Object.il2cpp_array_length(Pointer);
				}
				return result;
			}
		}

		public T[] ToArray()
        {
			int len = Length;
			T[] result = new T[Length];
			for(int i = 0;i< len; i++)
            {
				result[i] = this[i];
			}
			return result;
        }

		public T2[] ToArray<T2>() where T2 : IL2Object
        {
			int len = Length;
			T2[] result = new T2[Length];
			for(int i = 0;i< len; i++)
            {
				T2 obj = (T2)Activator.CreateInstance(typeof(T2), new object[] { IntPtr.Zero });
				obj.Pointer = (IntPtr)(object)this[i];
				result[i] = obj;
			}
			return result;
        }

		unsafe public byte[] GetAsByteArray()
        {
			int size = (int)Import.Object.il2cpp_array_get_byte_length(Pointer);
			byte[] result = new byte[size];
			if (size > 0)
				Marshal.Copy((IntPtr)((long*)Pointer + 4), result, 0, size);
			return result;
		}
	
		public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass(typeof(Array).Name, typeof(Array).Namespace);
	}
}
