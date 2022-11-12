using System;

namespace VRC.Core.Pool
{
	public struct PooledArray
	{
		public PooledArray(IntPtr[] array)
		{
			Array = array;
		}

		public static implicit operator IntPtr[](PooledArray pa)
		{
			return null;
		}

		public IntPtr[] Array;
	}
}
