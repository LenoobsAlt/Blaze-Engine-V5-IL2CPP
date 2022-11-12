using System;
using System.Linq;
using IL2CPP_Core.Objects;
using VRC.SDKBase;

public class VRC_EventLog : VRCNetworkBehaviour
{
    static VRC_EventLog()
    {
        Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses()
            .FirstOrDefault(
                x =>
                    x.BaseType == VRCNetworkBehaviour.Instance_Class
                 && x.GetMethod("OnApplicationQuit") != null
                 && x.GetNestedTypes().Length == 3
                 && x.GetNestedTypes().FirstOrDefault(
                    y => y.GetField(
                        f => f.ReturnType.Name == "VRC.SDKBase.VRC_EventHandler.VrcBroadcastType"
                        ) != null
                    ) != null
            );
    }

    public VRC_EventLog(IntPtr ptr) : base(ptr) { }


    public class EventLogEntry : IL2Object
    {
        static EventLogEntry()
        {
            Instance_Class = VRC_EventLog.Instance_Class.GetNestedTypes().FirstOrDefault(
                x => x.GetField(y => y.ReturnType.Name == "VRC.SDKBase.VRC_EventHandler.VrcBroadcastType") != null
            );
        }

        public EventLogEntry(IntPtr ptr) : base(ptr) { }

        public EventLogEntry() : base(IntPtr.Zero)
        {
            Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
            Instance_Class.GetMethod(".ctor").Invoke(Pointer);
        }

        unsafe public string ObjectPath
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(ObjectPath));
                if (property == null)
                {
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == typeof(string).FullName)).Name = nameof(ObjectPath);
                    if (property == null)
                        return null;
                }
                IL2Object obj = property.GetGetMethod().Invoke(this);
                if (obj == null)
                    return null;

                return obj.GetValue<IL2Object>().ToString();
            }
            set
            {
                IL2Property property = Instance_Class.GetProperty(nameof(ObjectPath));
                if (property == null)
                {
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == typeof(string).FullName)).Name = nameof(ObjectPath);
                    if (property == null)
                        return;
                }
                property.GetSetMethod().Invoke(this, new IntPtr[] { new IL2String_utf16(value).Pointer });
            }
        }

        unsafe public int instigatorPhotonId
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(instigatorPhotonId));
                if (field == null)
                {
                    (field = Instance_Class.GetFields(x => x.IsPrivate && x.ReturnType.Name == typeof(int).FullName).Skip(1).FirstOrDefault()).Name = nameof(instigatorPhotonId);
                    if (field == null)
                        return default;
                }
                return field.GetValue<int>(this).GetValue();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(instigatorPhotonId));
                if (field == null)
                {
                    (field = Instance_Class.GetFields(x => x.IsPrivate && x.ReturnType.Name == typeof(int).FullName).Skip(1).FirstOrDefault()).Name = nameof(instigatorPhotonId);
                    if (field == null)
                        return;
                }
                field.SetValue(this, new IntPtr(&value));
            }
        }

        unsafe public VRC_EventHandler.VrcEvent theEvent
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(theEvent));
                if (field == null)
                {
                    (field = Instance_Class.GetField(x => x.IsPrivate && x.ReturnType.Name == VRC_EventHandler.VrcEvent.Instance_Class.FullName)).Name = nameof(theEvent);
                    if (field == null)
                        return default;
                }
                return field.GetValue(this)?.GetValue<VRC_EventHandler.VrcEvent>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(theEvent));
                if (field == null)
                {
                    (field = Instance_Class.GetField(x => x.IsPrivate && x.ReturnType.Name == VRC_EventHandler.VrcEvent.Instance_Class.FullName)).Name = nameof(theEvent);
                    if (field == null)
                        return;
                }
                field.SetValue(this, value == null ? IntPtr.Zero : value.Pointer);
            }
        }


        public static IL2Class Instance_Class;
    }

    public static new IL2Class Instance_Class;
}