using System;
using System.Linq;
using IL2CPP_Core.Objects;

public class VRCInput : IL2Object
{
    public VRCInput(IntPtr ptr) : base(ptr) { }

    public string name
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(name));
            if (property == null)
                (property = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == typeof(string).FullName)).Name = nameof(name);
            return property.GetGetMethod().Invoke(this)?.GetValue<IL2String>().ToString();
        }
    }

    public bool down
    {
        get
        {
            return bValue && !bValuePrev;
        }
    }

    public bool up
    {
        get
        {
            return !bValue && bValuePrev;
        }
    }

    public bool button
    {
        get
        {
            return bValue;
        }
    }

    public void Reset()
    {
        if (!bValue)
        {
            timePressed = 0f;
        }
        bValuePrev = bValue;
        bValue = false;
        fValue = 0f;
    }

    unsafe public float timePressed
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(timePressed));
            if (field == null)
                (field = Instance_Class.GetField(x => x.Token == 0x18)).Name = nameof(timePressed);

            return field.GetValue<float>(this).GetValue();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(timePressed));
            if (field == null)
                (field = Instance_Class.GetField(x => x.Token == 0x18)).Name = nameof(timePressed);

            field.SetValue(this, new IntPtr(&value));
        }
    }
    
    unsafe public float lastDownTime
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(lastDownTime));
            if (field == null)
                (field = Instance_Class.GetField(x => x.Token == 0x28)).Name = nameof(lastDownTime);

            return field.GetValue<float>(this).GetValue();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(lastDownTime));
            if (field == null)
                (field = Instance_Class.GetField(x => x.Token == 0x28)).Name = nameof(lastDownTime);

            field.SetValue(this, new IntPtr(&value));
        }
    }
    
    unsafe public float lastUpTime
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(lastUpTime));
            if (field == null)
                (field = Instance_Class.GetField(x => x.Token == 0x2C)).Name = nameof(lastUpTime);

            return field.GetValue<float>(this).GetValue();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(lastUpTime));
            if (field == null)
                (field = Instance_Class.GetField(x => x.Token == 0x2C)).Name = nameof(lastUpTime);

            field.SetValue(this, new IntPtr(&value));
        }
    }

    unsafe public float fValue
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(fValue));
            if (field == null)
                (field = Instance_Class.GetField(x => x.Token == 0x30)).Name = nameof(fValue);

            return field.GetValue<float>(this).GetValue();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(fValue));
            if (field == null)
                (field = Instance_Class.GetField(x => x.Token == 0x30)).Name = nameof(fValue);

            field.SetValue(this, new IntPtr(&value));
        }
    }

    // 0x34
    unsafe public bool bValue
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(bValue));
            if (field == null)
                (field = Instance_Class.GetFields().First(x => x.ReturnType.Name == typeof(bool).FullName)).Name = nameof(bValue);

            return field.GetValue<bool>(this).GetValue();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(bValue));
            if (field == null)
                (field = Instance_Class.GetFields().First(x => x.ReturnType.Name == typeof(bool).FullName)).Name = nameof(bValue);

            field.SetValue(this, new IntPtr(&value));
        }
    }

    unsafe public bool bValuePrev
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(bValue));
            if (field == null)
                (field = Instance_Class.GetFields().Last(x => x.ReturnType.Name == typeof(bool).FullName)).Name = nameof(bValue);

            return field.GetValue<bool>(this).GetValue();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(bValue));
            if (field == null)
                (field = Instance_Class.GetFields().Last(x => x.ReturnType.Name == typeof(bool).FullName)).Name = nameof(bValue);

            field.SetValue(this, new IntPtr(&value));
        }
    }

    public static IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass(
            LocomotionInputController.Instance_Class.GetField(
                x => LocomotionInputController.Instance_Class.GetFields().Where(y => y.ReturnType.Name == x.ReturnType.Name).Count() > 9
            ).ReturnType.Name
        );
}