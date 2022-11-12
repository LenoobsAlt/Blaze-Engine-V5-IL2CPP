using System;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.SDKBase
{
	public abstract class VRC_DataStorage : MonoBehaviour
	{
		public VRC_DataStorage(IntPtr ptr) : base(ptr) { }


		public enum VrcDataMirror
		{
			None,
			Animator,
			SerializeComponent
		}

		public enum VrcDataType
		{
			None,
			Bool,
			Int,
			Float,
			String,
			SerializeBytes,
			SerializeObject,
			Other
		}

		public class VrcDataElement : IL2Object
		{
			public VrcDataElement(IntPtr ptr) : base(ptr) { }

			public VrcDataElement() : base(IntPtr.Zero)
			{
				Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
				Instance_Class.GetMethod(".ctor").Invoke(Pointer);
			}


			public bool Serialize<T>(T objectToSerialize)
			{
				return default(bool);
			}
			/*
			public bool Deserialize<T>(out T objectToDeserialize)
			{
				return default(bool);
			}
			*/

			public string name;

			public VrcDataMirror mirror;

			unsafe public VrcDataType type
            {
				get => Instance_Class.GetField(nameof(type)).GetValue<VrcDataType>(this).GetValue();
				set => Instance_Class.GetField(nameof(type)).SetValue(this, new IntPtr(&value));
            }

			public MonoBehaviour serializeComponent;

			unsafe public bool valueBool
            {
				get => Instance_Class.GetField(nameof(valueBool)).GetValue<bool>(this).GetValue();
				set => Instance_Class.GetField(nameof(valueBool)).SetValue(this, new IntPtr(&value));
            }


			unsafe public int valueInt
			{
				get => Instance_Class.GetField(nameof(valueInt)).GetValue<int>(this).GetValue();
				set => Instance_Class.GetField(nameof(valueInt)).SetValue(this, new IntPtr(&value));
			}

			unsafe public float valueFloat
			{
				get => Instance_Class.GetField(nameof(valueFloat)).GetValue<float>(this).GetValue();
				set => Instance_Class.GetField(nameof(valueFloat)).SetValue(this, new IntPtr(&value));
			}

			public string valueString
			{
				get => Instance_Class.GetField(nameof(type)).GetValue(this)?.GetValue<IL2String>().ToString();
				set => Instance_Class.GetField(nameof(type)).SetValue(this, new IL2String_utf16(value).Pointer);
			}

			public byte[] valueSerializedBytes;

			public bool modified;

			public bool added;

			public VRC_DataStorage dataStorage;

			public static IL2Class Instance_Class = VRC_DataStorage.Instance_Class.GetNestedType("VrcDataElement");
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRCSDKBase"].GetClass("VRC_DataStorage", "VRC.SDKBase");
	}
}
