using System;
using IL2CPP_Core.Objects;
using MoPhoGames.USpeak.Core.Utils;

namespace MoPhoGames.USpeak.Core
{
	public struct USpeakFrameContainer
	{
		public int LoadFrom(byte[] source, int sourceOffset)
		{
			FrameIndex = BitConverter.ToUInt16(source, sourceOffset);
			int num = sourceOffset + 2;
			int num2 = BitConverter.ToInt32(source, num);
			num += 4;
			encodedData = USpeakPoolUtils.GetByte(num2);
			Array.Copy(source, num, encodedData, 0, num2);
			return num2 + 6;
		}

		public void Cleanup()
		{
			if (encodedData != null)
			{
				USpeakPoolUtils.Return(encodedData);
				encodedData = null;
			}
		}

		public static ushort ParseFrameIndex(byte[] source, int sourceOffset)
		{
			return BitConverter.ToUInt16(source, sourceOffset);
		}

		public int GetByteLength()
		{
			return encodedData.Length + 6;
		}

		public int CopyToByteArray(byte[] target, int offset)
		{
			int byteLength = GetByteLength();
			if (byteLength > target.Length - offset)
			{
				// Debug.LogError("USpeakFrameContainer.CopyToByteArray: not enough space in target buffer");
				return -1;
			}
			byte[] bytes = BitConverter.GetBytes(FrameIndex);
			Array.Copy(bytes, 0, target, offset, 2);
			offset += 2;
			byte[] bytes2 = BitConverter.GetBytes(encodedData.Length);
			bytes2.CopyTo(target, offset);
			offset += 4;
			encodedData.CopyTo(target, offset);
			return byteLength;
		}

		public ushort FrameIndex;

		public byte[] encodedData;

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass(USpeaker.EncodeInfo.Instance_Class.GetField(x => !x.ReturnType.Name.StartsWith("System.")).ReturnType.Name);
	}
}
