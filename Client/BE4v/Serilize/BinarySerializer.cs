using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using VRC.Core;
using VRC.SDKBase;

namespace BE4v.Serilize
{
	public static class NonIL_BinarySerializer
	{
		private static void Clear()
		{
			bytePos = 1;
			encBuffer.Clear();
			decBuffer = null;
			objectTypeCounts.Clear();
			objectCount = 1;
		}

		private static bool DeserializeBool()
		{
			bytePos++;
			return BitConverter.ToBoolean(decBuffer, bytePos - 1);
		}
		private static long DeserializeLong()
		{
			bytePos += 8;
			return BitConverter.ToInt64(decBuffer, bytePos - 8);
		}

		private static int DeserializeInt()
		{
			bytePos += 4;
			return BitConverter.ToInt32(decBuffer, bytePos - 4);
		}

		private static double DeserializeDouble()
		{
			bytePos += 8;
			return BitConverter.ToDouble(decBuffer, bytePos - 8);
		}

		private static float DeserializeFloat()
		{
			bytePos += 4;
			return BitConverter.ToSingle(decBuffer, bytePos - 4);
		}
		private static void SerializeShort(short obj)
		{
			encBuffer.AddRange(BitConverter.GetBytes(obj));
		}

		private static short DeserializeShort()
		{
			bytePos += 2;
			return BitConverter.ToInt16(decBuffer, bytePos - 2);
		}

		private static void SerializeString(string obj)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(obj);
			SerializeShort((short)bytes.Length);
			encBuffer.AddRange(bytes);
		}

		private static string DeserializeString()
		{
			short num = DeserializeShort();
			bytePos += num;
			return Encoding.UTF8.GetString(decBuffer, bytePos - num, num);
		}

		private static object DeserializeTypeArray()
		{
			short num = DeserializeShort();
			BinarySerializer.TypeCode type = (BinarySerializer.TypeCode)decBuffer[bytePos++];
			Array array = Array.CreateInstance(CodeToType[type], num);
			for (int i = 0; i < num; i++)
			{
				array.SetValue(DeserializeBytes(type), i);
			}
			return array;
		}

		private static Vector2 DeserializeVector2()
		{
			return new Vector2(DeserializeFloat(), DeserializeFloat());
		}

		private static Vector3 DeserializeVector3()
		{
			return new Vector3(DeserializeFloat(), DeserializeFloat(), DeserializeFloat());
		}

		private static Vector4 DeserializeVector4()
		{
			return new Vector4(DeserializeFloat(), DeserializeFloat(), DeserializeFloat(), DeserializeFloat());
		}

		private static Quaternion DeserializeQuaternion()
		{
			return new Quaternion(DeserializeFloat(), DeserializeFloat(), DeserializeFloat(), DeserializeFloat());
		}
		private static Color DeserializeColor()
		{
			return new Color(DeserializeFloat(), DeserializeFloat(), DeserializeFloat(), DeserializeFloat());
		}
		private static Color32 DeserializeColor32()
		{
			return new Color32(decBuffer[bytePos++], decBuffer[bytePos++], decBuffer[bytePos++], decBuffer[bytePos++]);
		}
		private static VRC_EventLog.EventLogEntry DeserializeEventLogEntry()
		{
			VRC_EventLog.EventLogEntry @event = new VRC_EventLog.EventLogEntry();
			@event.theEvent = new VRC_EventHandler.VrcEvent();
			// @event.DHLPNKMIODE = (double)DeserializeFloat();
			DeserializeFloat();
			@event.instigatorPhotonId = DeserializeInt();
			@event.ObjectPath = DeserializeString();
			@event.theEvent.EventType = (VRC_EventHandler.VrcEventType)Enum.ToObject(typeof(VRC_EventHandler.VrcEventType), DeserializeInt());
			@event.theEvent.TakeOwnershipOfTarget = DeserializeBool();
			@event.theEvent.ParameterBoolOp = (VRC_EventHandler.VrcBooleanOp)Enum.ToObject(typeof(VRC_EventHandler.VrcBooleanOp), DeserializeInt());
			@event.theEvent.ParameterFloat = DeserializeFloat();
			@event.theEvent.ParameterInt = DeserializeInt();
			@event.theEvent.ParameterString = DeserializeString();
			try
			{
				//@event.HCAACLCGPMC = DeserializeFloat();
				DeserializeFloat();
				//@event.MPCLDPKHGHG = (VRC_EventHandler.VrcBroadcastType)DeserializeShort();
				DeserializeShort();
				@event.theEvent.ParameterBytes = (byte[])DeserializeTypeArray();
			}
			catch (IndexOutOfRangeException)
			{
				// @event.HCAACLCGPMC = 0f;
				@event.theEvent.ParameterBytes = new byte[0];
			}
			@event.theEvent.ParameterBytesVersion = new int?(1);
			return @event;
		}

		/*
		private VRC_SyncVideoPlayer.VideoEntry DeserializePlayerVideoEntry()
		{
			return new VRC_SyncVideoPlayer.VideoEntry
			{
				Source = VideoSource.Url,
				AspectRatio = (VideoAspectRatio)decBuffer[bytePos++],
				PlaybackSpeed = DeserializeFloat(),
				URL = DeserializeString()
			};
		}

		private static object DeserializeSerializableBehaviour()
		{
		}

		private static object DeserializeSerializableContainer()
		{
			return new ParameterSerialization.SerializableContainer
			{
				name = DeserializeString(),
				data = (byte[])DeserializeTypeArray()
			};
		}
		*/

		public static object Deserialize(byte[] bytes)
		{
			Clear();
			decBuffer = bytes;
			object result = null;

			if (bytes == null || bytes.Length == 0)
				return result;

			try
			{
				result = DeserializeBytes();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Failed to deserialize, no parameters will be returned: {ex.Message}");
			}
			return result;
		}

		private static object DeserializeBytes(BinarySerializer.TypeCode type = 0)
		{
			if (type == 0)
			{
				type = (BinarySerializer.TypeCode)decBuffer[bytePos++];
			}
			if (decBuffer.Length < bytePos)
			{
				throw new Exception("Overread of buffer");
			}
			switch (type)
			{
				case BinarySerializer.TypeCode.VECTOR2:
					return DeserializeVector2();
				case BinarySerializer.TypeCode.VECTOR3:
					return DeserializeVector3();
				case BinarySerializer.TypeCode.VECTOR4:
					return DeserializeVector4();
				case BinarySerializer.TypeCode.QUATERNION:
					return DeserializeQuaternion();
				case BinarySerializer.TypeCode.COLOR:
					return DeserializeColor();
				case BinarySerializer.TypeCode.COLOR32:
					return DeserializeColor32();
				case BinarySerializer.TypeCode.EVENTLOG_ENTRY:
					return DeserializeEventLogEntry();
				/*
				case BinarySerializer.TypeCode.PLAYER_VIDEO_ENTRY:
					return DeserializePlayerVideoEntry();
				case BinarySerializer.TypeCode.STREAM_VIDEO_ENTRY:
					return this.ABPBIBONCMA();
				case BinarySerializer.TypeCode.DATA_ELEMENT:
					return this.KHAOBGNONHE();
				case BinarySerializer.TypeCode.SERIALIZABLE_BEHAVIOR:
					return this.MIHPDNKKPIG();
				case BinarySerializer.TypeCode.SERIALIZABLE_CONTAINER:
					return this.CKCGNEMANID();
				case BinarySerializer.TypeCode.GAMEOBJECT:
					return this.BDJBNMCJMDE();
				case BinarySerializer.TypeCode.TRANSFORM:
					return this.KHIPMPFFHAD();*/
				case BinarySerializer.TypeCode.NULL:
					return null;
				case BinarySerializer.TypeCode.BYTE:
					return decBuffer[bytePos++];
				case BinarySerializer.TypeCode.DOUBLE:
					return DeserializeDouble();
				case BinarySerializer.TypeCode.FLOAT:
					return DeserializeFloat();
				case BinarySerializer.TypeCode.INT:
					return DeserializeInt();
				case BinarySerializer.TypeCode.SHORT:
					return DeserializeShort();
				case BinarySerializer.TypeCode.LONG:
					return DeserializeLong();
				case BinarySerializer.TypeCode.BOOL:
					return DeserializeBool();
				case BinarySerializer.TypeCode.STRING:
					return DeserializeString();
				/*
				case BinarySerializer.TypeCode.OBJECT_ARRAY:
					return DPPNCLGNFEO();
				*/
				case BinarySerializer.TypeCode.TYPE_ARRAY:
					return DeserializeTypeArray();
				default:
					throw new Exception("Deserializer encountered unhandled type: " + type);
			}
		}

		private static readonly Dictionary<BinarySerializer.TypeCode, Type> CodeToType = new Dictionary<BinarySerializer.TypeCode, Type>
		{
			{
				BinarySerializer.TypeCode.BYTE,
				typeof(byte)
			},
			{
				BinarySerializer.TypeCode.DOUBLE,
				typeof(double)
			},
			{
				BinarySerializer.TypeCode.FLOAT,
				typeof(float)
			},
			{
				BinarySerializer.TypeCode.INT,
				typeof(int)
			},
			{
				BinarySerializer.TypeCode.SHORT,
				typeof(short)
			},
			{
				BinarySerializer.TypeCode.LONG,
				typeof(long)
			},
			{
				BinarySerializer.TypeCode.BOOL,
				typeof(bool)
			},
			{
				BinarySerializer.TypeCode.STRING,
				typeof(string)
			},
			{
				BinarySerializer.TypeCode.OBJECT_ARRAY,
				typeof(object[])
			},
			{
				BinarySerializer.TypeCode.TYPE_ARRAY,
				typeof(object)
			},
			{
				BinarySerializer.TypeCode.VECTOR2,
				typeof(Vector2)
			},
			{
				BinarySerializer.TypeCode.VECTOR3,
				typeof(Vector3)
			},
			{
				BinarySerializer.TypeCode.VECTOR4,
				typeof(Vector4)
			},
			{
				BinarySerializer.TypeCode.QUATERNION,
				typeof(Quaternion)
			},
			{
				BinarySerializer.TypeCode.COLOR,
				typeof(Color)
			},
			{
				BinarySerializer.TypeCode.COLOR32,
				typeof(Color32)
			},
			{
				BinarySerializer.TypeCode.EVENTLOG_ENTRY,
				typeof(object)
			},
			{
				BinarySerializer.TypeCode.PLAYER_VIDEO_ENTRY,
				typeof(object)
			},
			{
				BinarySerializer.TypeCode.STREAM_VIDEO_ENTRY,
				typeof(object)
			},
			{
				BinarySerializer.TypeCode.DATA_ELEMENT,
				typeof(object)
			},
			{
				BinarySerializer.TypeCode.SERIALIZABLE_BEHAVIOR,
				typeof(object)
			},
			{
				BinarySerializer.TypeCode.SERIALIZABLE_CONTAINER,
				typeof(object)
			},
			{
				BinarySerializer.TypeCode.GAMEOBJECT,
				typeof(object)
			},
			{
				BinarySerializer.TypeCode.TRANSFORM,
				typeof(object)
			}
		};
		private const short ObjectCountLimit = 512;

		private static int bytePos;

		private static List<byte> encBuffer;

		private static byte[] decBuffer;

		private static Dictionary<BinarySerializer.TypeCode, short> objectTypeCounts;

		private static short objectCount;
	}
}
