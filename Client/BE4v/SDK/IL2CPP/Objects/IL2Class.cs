using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IL2CPP_Core.Objects
{
    public class IL2Class : IL2Object
    {
        public string Name { get; set; }
        public string Namespace { get; set; }
        public string FullName
        {
            get
            {
                if (string.IsNullOrEmpty(Namespace))
                    return Name;

                return Namespace + "." + Name;
            }
        }
        private List<IL2Method> MethodList = new List<IL2Method>();
        private List<IL2Field> FieldList = new List<IL2Field>();
        //private List<IL2CPP_Event> EventList = new List<IL2CPP_Event>();
        private List<IL2Class> NestedTypeList = new List<IL2Class>();
        private List<IL2Class> InterfaceTypeList = new List<IL2Class>();
        private List<IL2Property> PropertyList = new List<IL2Property>();
        public IL2Class(IntPtr ptr) : base(ptr)
        {
            Pointer = ptr;
            Name = Marshal.PtrToStringAnsi(Import.Class.il2cpp_class_get_name(ptr));
            Namespace = Marshal.PtrToStringAnsi(Import.Class.il2cpp_class_get_namespace(ptr));
            // Name = Import.StringFromNativeUtf8(Import.Class.il2cpp_class_get_name(ptr));
            //Namespace = Import.StringFromNativeUtf8(Import.Class.il2cpp_class_get_namespace(ptr));

            // Find Methods
            IntPtr method_iter = IntPtr.Zero;
            IntPtr method = IntPtr.Zero;
            while ((method = Import.Class.il2cpp_class_get_methods(ptr, ref method_iter)) != IntPtr.Zero)
                MethodList.Add(new IL2Method(method));

            // Find Fields
            IntPtr field_iter = IntPtr.Zero;
            IntPtr field = IntPtr.Zero;
            while ((field = Import.Class.il2cpp_class_get_fields(ptr, ref field_iter)) != IntPtr.Zero)
                FieldList.Add(new IL2Field(field));
            /*

            // Map out Events
            IntPtr evt_iter = IntPtr.Zero;
            IntPtr evt = IntPtr.Zero;
            while ((evt = IL2CPP.il2cpp_class_get_events(Ptr, ref evt_iter)) != IntPtr.Zero)
                EventList.Add(new IL2CPP_Event(evt));

            */
            // Find Nested Class
            IntPtr nestedtype_iter = IntPtr.Zero;
            IntPtr nestedtype = IntPtr.Zero;
            while ((nestedtype = Import.Class.il2cpp_class_get_nested_types(ptr, ref nestedtype_iter)) != IntPtr.Zero)
                NestedTypeList.Add(new IL2Class(nestedtype));

            IntPtr interfacetype_iter = IntPtr.Zero;
            IntPtr interfacetype = IntPtr.Zero;
            while ((interfacetype = Import.Class.il2cpp_class_get_interfaces(ptr, ref interfacetype_iter)) != IntPtr.Zero)
                InterfaceTypeList.Add(new IL2Class(interfacetype));

            // Find Property
            IntPtr property_iter = IntPtr.Zero;
            IntPtr property = IntPtr.Zero;
            while ((property = Import.Class.il2cpp_class_get_properties(ptr, ref property_iter)) != IntPtr.Zero)
            {
                IL2Property p = new IL2Property(property);
                PropertyList.Add(p);
                if (p.GetGetMethod() != null)
                    MethodList.Remove(p.GetGetMethod());
                if (p.GetSetMethod() != null)
                    MethodList.Remove(p.GetSetMethod());
            }
        }

        public int Token => Import.Class.il2cpp_class_get_type_token(Pointer);

        public IL2Assembly Assembly
        {
            get
            {
                IntPtr pointer = Import.Class.il2cpp_class_get_image(Pointer);
                if (pointer != IntPtr.Zero)
                    return new IL2Assembly(pointer);

                return null;
            }
        }

        public IL2Class DeclaringType
        {
            get
            {
                IntPtr pointer = Import.Class.il2cpp_class_get_declaring_type(Pointer);
                if (pointer != IntPtr.Zero)
                    return new IL2Class(pointer);

                return null;
            }
        }

        public IL2Class BaseType
        {
            get
            {
                IntPtr pointer = Import.Class.il2cpp_class_get_parent(Pointer);
                if (pointer != IntPtr.Zero)
                    return new IL2Class(pointer);

                return null;
            }
        }

        public bool HasAttribute(IL2Class klass)
        {
            if (klass == null) return false;
            return Import.Class.il2cpp_class_has_attribute(Pointer, klass.Pointer);
        }

        public bool IsEnum => Import.Class.il2cpp_class_is_enum(Pointer);
        public bool IsAbstract => HasFlag(IL2BindingFlags.TYPE_ABSTRACT);
        public bool IsInterface => HasFlag(IL2BindingFlags.TYPE_INTERFACE);

        public IL2BindingFlags Flags
        {
            get
            {
                uint f = 0;
                return (IL2BindingFlags)Import.Class.il2cpp_class_get_flags(Pointer, ref f);
            }
        }
        public bool HasFlag(IL2BindingFlags flag) => ((Flags & flag) != 0);

        // Methods
        public IL2Method GetMethodByName(string name, int argsCount)
        {
            IntPtr result = Import.Class.il2cpp_class_get_method_from_name(Pointer, new IL2String_utf16(name).Pointer, argsCount);
            if (result != IntPtr.Zero)
                return new IL2Method(result);
            return null;
        }
        public IL2Method[] GetMethods() => MethodList.ToArray();
        public IL2Method[] GetMethods(IL2BindingFlags flags) => GetMethods(flags, null);
        public IL2Method[] GetMethods(Func<IL2Method, bool> func) => GetMethods().Where(x => func(x)).ToArray();
        public IL2Method[] GetMethods(IL2BindingFlags flags, Func<IL2Method, bool> func) => GetMethods().Where(x => x.HasFlag(flags) && func(x)).ToArray();
        public IL2Method GetMethod(Func<IL2Method, bool> func) => GetMethods().Where(x => func(x)).FirstOrDefault();
        public IL2Method GetMethod(string name) => GetMethod(name, null);
        public IL2Method GetMethod(string name, IL2BindingFlags flags) => GetMethod(name, flags, null);
        public IL2Method GetMethod(string name, Func<IL2Method, bool> func)
        {
            IL2Method returnval = null;
            foreach (IL2Method method in GetMethods())
            {
                if (method.Name.Equals(name) && ((func == null) || func(method)))
                {
                    returnval = method;
                    break;
                }
            }
            return returnval;
        }
        public IL2Method GetMethod(string name, IL2BindingFlags flags, Func<IL2Method, bool> func)
        {
            IL2Method returnval = null;
            foreach (IL2Method method in GetMethods())
            {
                if (method.Name.Equals(name) && method.HasFlag(flags) && ((func == null) || func(method)))
                {
                    returnval = method;
                    break;
                }
            }
            return returnval;
        }
        public IL2Method GetMethod(IL2Class type)
        {
            IL2Method[] methods = GetMethods();
            int length = methods.Length;
            for (int i = 0; i < length; i++)
            {
                if (methods[i].ReturnType.Name == type.FullName)
                    return methods[i];
            }
            return null;
        }


        // Fields
        public IL2Field[] GetFields() => FieldList.ToArray();
        public IL2Field[] GetFields(IL2BindingFlags flags) => GetFields(flags, null);
        public IL2Field[] GetFields(Func<IL2Field, bool> func) => GetFields().Where(x => func(x)).ToArray();
        public IL2Field[] GetFields(IL2BindingFlags flags, Func<IL2Field, bool> func) => GetFields().Where(x => (x.HasFlag(flags) && func(x))).ToArray();
        public IL2Field GetField(Func<IL2Field, bool> func) => GetFields().FirstOrDefault(x => func(x));
        public IL2Field GetField(string name) => GetField(name, null);
        public IL2Field GetField(string name, IL2BindingFlags flags) => GetField(name, flags, null);
        public IL2Field GetField(IL2Class type)
        {
            IL2Field[] fields = GetFields();
            for (int i=0;i< fields.Length;i++)
            {
                if (fields[i].ReturnType.Name == type.FullName)
                    return fields[i];
            }
            return null;
        }
        public IL2Field GetField(string name, Func<IL2Field, bool> func)
        {
            IL2Field returnval = null;
            foreach (IL2Field field in GetFields())
            {
                if (field.Name.Equals(name) && ((func == null) || func(field)))
                {
                    returnval = field;
                    break;
                }
            }
            return returnval;
        }
        public IL2Field GetField(string name, IL2BindingFlags flags, Func<IL2Field, bool> func)
        {
            IL2Field returnval = null;
            foreach (IL2Field field in GetFields())
            {
                if (field.Name.Equals(name) && field.HasFlag(flags) && ((func == null) || func(field)))
                {
                    returnval = field;
                    break;
                }
            }
            return returnval;
        }

        /*
        // Events
        public IL2CPP_Event[] GetEvents() => EventList.ToArray();
        */

        // Properties
        public IL2Property[] GetProperties() => PropertyList.ToArray();
        public IL2Property[] GetProperties(IL2BindingFlags flags) => GetProperties(x => x.HasFlag(flags));
        public IL2Property[] GetProperties(Func<IL2Property, bool> func) => GetProperties().Where(x => func(x)).ToArray();
        public IL2Property GetProperty(Func<IL2Property, bool> func) => GetProperties().FirstOrDefault(x => func(x));
        public IL2Property GetProperty(IL2Class type) => GetProperties().FirstOrDefault(x => x.GetGetMethod()?.ReturnType.Name == type.FullName || x.GetSetMethod()?.GetParameters()[0]?.Name == type.FullName);
        public IL2Property GetProperty(string name)
        {
            IL2Property returnval = null;
            foreach (IL2Property prop in GetProperties())
            {
                if (prop.Name.Equals(name))
                {
                    returnval = prop;
                    break;
                }
            }
            return returnval;
        }

        public IL2Property GetProperty(string name, IL2BindingFlags flags)
        {
            IL2Property returnval = null;
            foreach (IL2Property prop in GetProperties())
            {
                if (prop.Name.Equals(name) && prop.HasFlag(flags))
                {
                    returnval = prop;
                    break;
                }
            }
            return returnval;
        }

        // Nested Types
        public IL2Class[] GetNestedTypes() => NestedTypeList.ToArray();
        public IL2Class[] GetNestedTypes(IL2BindingFlags flags) => GetNestedTypes().Where(x => x.HasFlag(flags)).ToArray();
        public IL2Class GetNestedType(string name) => GetNestedType(name, null);
        public IL2Class GetNestedType(string name, IL2BindingFlags flags) => GetNestedType(name, null, flags);
        public IL2Class GetNestedType(string name, string name_space)
        {
            IL2Class returnval = null;
            foreach (IL2Class type in GetNestedTypes())
            {
                if (type.Name.Equals(name) && (string.IsNullOrEmpty(type.Namespace) || type.Namespace.Equals(name_space)))
                {
                    returnval = type;
                    break;
                }
            }
            return returnval;
        }
        public IL2Class GetNestedType(string name, string name_space, IL2BindingFlags flags)
        {
            IL2Class returnval = null;
            foreach (IL2Class type in GetNestedTypes())
            {
                if (type.Name.Equals(name) && (string.IsNullOrEmpty(type.Namespace) || type.Namespace.Equals(name_space)) && type.HasFlag(flags))
                {
                    returnval = type;
                    break;
                }
            }
            return returnval;
        }

        // Interface Types
        public IL2Class[] GetInterfaceTypes() => InterfaceTypeList.ToArray();
        public IL2Class[] GetInterfaceTypes(IL2BindingFlags flags) => GetInterfaceTypes().Where(x => x.HasFlag(flags)).ToArray();
        public IL2Class GetInterfaceType(string name) => GetInterfaceType(name, null);
        public IL2Class GetInterfaceType(string name, IL2BindingFlags flags) => GetInterfaceType(name, null, flags);
        public IL2Class GetInterfaceType(string name, string name_space)
        {
            IL2Class returnval = null;
            foreach (IL2Class type in GetNestedTypes())
            {
                if (type.Name.Equals(name) && (string.IsNullOrEmpty(type.Namespace) || type.Namespace.Equals(name_space)))
                {
                    returnval = type;
                    break;
                }
            }
            return returnval;
        }
        public IL2Class GetInterfaceType(string name, string name_space, IL2BindingFlags flags)
        {
            IL2Class returnval = null;
            foreach (IL2Class type in GetInterfaceTypes())
            {
                if (type.Name.Equals(name) && (string.IsNullOrEmpty(type.Namespace) || type.Namespace.Equals(name_space)) && type.HasFlag(flags))
                {
                    returnval = type;
                    break;
                }
            }
            return returnval;
        }

        public IL2Class MakeGenericType(Type[] types) => new IL2Class(new RuntimeType(Pointer).MakeGenericType(types));
        public IL2Class MakeGenericType(IntPtr[] types) => new IL2Class(new RuntimeType(Pointer).MakeGenericType(types));
    }
}
