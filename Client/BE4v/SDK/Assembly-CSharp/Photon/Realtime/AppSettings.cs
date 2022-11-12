using System;
using IL2CPP_Core.Objects;

namespace IL2Photon.Realtime
{
    public class AppSettings : IL2Object
	{
		public AppSettings(IntPtr ptr) : base(ptr) { }

		unsafe public bool IsBestRegion
		{
			get => Instance_Class.GetProperty(nameof(IsBestRegion)).GetGetMethod().Invoke<bool>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(IsBestRegion)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public bool IsMasterServerAddress
		{
			get => Instance_Class.GetProperty(nameof(IsMasterServerAddress)).GetGetMethod().Invoke<bool>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(IsMasterServerAddress)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public bool IsDefaultNameServer
		{
			get => Instance_Class.GetProperty(nameof(IsDefaultNameServer)).GetGetMethod().Invoke<bool>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(IsDefaultNameServer)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public bool IsDefaultPort
		{
			get => Instance_Class.GetProperty(nameof(IsDefaultPort)).GetGetMethod().Invoke<bool>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(IsDefaultPort)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}
		
		public string AppIdRealtime
		{
			get => Instance_Class.GetField(nameof(AppIdRealtime)).GetValue(this)?.GetValue<IL2String>().ToString();
			set => Instance_Class.GetField(nameof(AppIdRealtime)).SetValue(this, new IL2String_utf8(value).Pointer);
		}


		public string AppIdChat
		{
			get => Instance_Class.GetField(nameof(AppIdChat)).GetValue(this).GetValue<IL2String>().ToString();
			set => Instance_Class.GetField(nameof(AppIdChat)).SetValue(this, new IL2String_utf8(value).Pointer);
		}


		public string AppIdVoice
		{
			get => Instance_Class.GetField(nameof(AppIdVoice)).GetValue(this)?.GetValue<IL2String>().ToString();
			set => Instance_Class.GetField(nameof(AppIdVoice)).SetValue(this, new IL2String_utf8(value).Pointer);
		}


		public string AppVersion
		{
			get => Instance_Class.GetField(nameof(AppVersion)).GetValue(this)?.GetValue<IL2String>().ToString();
			set => Instance_Class.GetField(nameof(AppVersion)).SetValue(this, new IL2String_utf8(value).Pointer);
		}


		unsafe public bool UseNameServer
		{
			get => Instance_Class.GetField(nameof(UseNameServer)).GetValue<bool>(this).GetValue();
			set => Instance_Class.GetField(nameof(UseNameServer)).SetValue(this, new IntPtr(&value));
		}

		public string FixedRegion
		{
			get => Instance_Class.GetField(nameof(FixedRegion)).GetValue(this)?.GetValue<IL2String>().ToString();
			set => Instance_Class.GetField(nameof(FixedRegion)).SetValue(this, new IL2String_utf8(value).Pointer);
		}


		public string Server
		{
			get => Instance_Class.GetField(nameof(Server)).GetValue(this)?.GetValue<IL2String>().ToString();
			set => Instance_Class.GetField(nameof(Server)).SetValue(this, new IL2String_utf8(value).Pointer);
		}

		unsafe public int Port
		{
			get => Instance_Class.GetField(nameof(Port)).GetValue<int>(this).GetValue();
			set => Instance_Class.GetField(nameof(Port)).SetValue(this, new IntPtr(&value));
		}

		unsafe public bool EnableLobbyStatistics
		{
			get => Instance_Class.GetField(nameof(EnableLobbyStatistics)).GetValue<bool>(this).GetValue();
			set => Instance_Class.GetField(nameof(EnableLobbyStatistics)).SetValue(this, new IntPtr(&value));
		}

		public static IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass("AppSettings", "Photon.Realtime");
    }
}