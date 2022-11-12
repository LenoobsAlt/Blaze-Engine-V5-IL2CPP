using System;
using System.Collections.Generic;
using UnityEngine;

namespace MoPhoGames.USpeak.Core.Utils
{
	public class USpeakPoolUtils
	{
		public static float[] GetFloat(int length)
		{
			object obj = syncObject;
			float[] result2;
			lock (obj)
			{
				for (int i = 0; i < FloatPool.Count; i++)
				{
					if (FloatPool[i].Length == length)
					{
						float[] result = FloatPool[i];
						FloatPool.RemoveAt(i);
						return result;
					}
				}
				result2 = new float[length];
			}
			return result2;
		}

		public static short[] GetShort(int length)
		{
			object obj = syncObject;
			short[] result2;
			lock (obj)
			{
				for (int i = 0; i < ShortPool.Count; i++)
				{
					if (ShortPool[i].Length == length)
					{
						short[] result = ShortPool[i];
						ShortPool.RemoveAt(i);
						return result;
					}
				}
				result2 = new short[length];
			}
			return result2;
		}

		public static int[] GetInt(int length)
		{
			object obj = syncObject;
			int[] result2;
			lock (obj)
			{
				for (int i = 0; i < IntPool.Count; i++)
				{
					if (IntPool[i].Length == length)
					{
						int[] result = IntPool[i];
						IntPool.RemoveAt(i);
						return result;
					}
				}
				result2 = new int[length];
			}
			return result2;
		}

		public static byte[] GetByte(int length)
		{
			object obj = syncObject;
			byte[] result2;
			lock (obj)
			{
				for (int i = 0; i < BytePool.Count; i++)
				{
					if (BytePool[i].Length == length)
					{
						byte[] result = BytePool[i];
						BytePool.RemoveAt(i);
						return result;
					}
				}
				result2 = new byte[length];
			}
			return result2;
		}

		public static void Return(float[] d)
		{
			if (d == null)
			{
				// Debug.LogError("Returning null array to pool!");
				return;
			}
			object obj = syncObject;
			lock (obj)
			{
				FloatPool.Add(d);
			}
		}

		public static void Return(byte[] d)
		{
			if (d == null)
			{
				// Debug.LogError("Returning null array to pool!");
				return;
			}
			object obj = syncObject;
			lock (obj)
			{
				BytePool.Add(d);
			}
		}

		public static void Return(short[] d)
		{
			if (d == null)
			{
				// Debug.LogError("Returning null array to pool!");
				return;
			}
			object obj = syncObject;
			lock (obj)
			{
				ShortPool.Add(d);
			}
		}

		public static void Return(int[] d)
		{
			if (d == null)
			{
				// Debug.LogError("Returning null array to pool!");
				return;
			}
			object obj = syncObject;
			lock (obj)
			{
				IntPool.Add(d);
			}
		}

		private static object syncObject = new object();

		private static List<byte[]> BytePool = new List<byte[]>();

		private static List<short[]> ShortPool = new List<short[]>();

		private static List<int[]> IntPool = new List<int[]>();

		private static List<float[]> FloatPool = new List<float[]>();
	}
}
