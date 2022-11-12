using System;
using System.Linq;
using System.Collections.Generic;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.UI.Core;


namespace VRC.UI.Elements
{
    public class MenuStateController : MonoBehaviour
    {
        static MenuStateController()
        {
            try
            {
                // ------------------ [ Find By PushPage ] args:
                // contentIndex or pageName
                // uiContext
                // clearPageStack
                // inPlace
                // 
                IL2Method showTabContent = Instance_Class.GetMethod("ShowTabContent");
                var instruction = showTabContent.GetDisassembler(0x100).Disassemble().FirstOrDefault(x => x.Mnemonic == SharpDisasm.Udis86.ud_mnemonic_code.UD_Icall);
                IntPtr addr = new IntPtr((long)instruction.Offset + instruction.Length + instruction.Operands[0].LvalSDWord);
                IL2Method method = null;
                unsafe
                {
                    method = Instance_Class.GetMethod(x => *(IntPtr*)x.Pointer == addr);
                }
                if (method != null)
                {
                    string methodName = method.Name;
                    foreach(var m in Instance_Class.GetMethods(x => x.Name == methodName))
                    {
                        m.Name = nameof(PushPage);
                    }
                }
            }
            catch
            {
                "Failed find!".RedPrefix("MenuStateController::PushPage");
            }
        }

        public MenuStateController(IntPtr ptr) : base(ptr) { }

        public unsafe void PushPage(string pageName, UIContext uiContext = null, bool clearPageStack = false, bool inPlace = false)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(PushPage), x => x.GetParameters()[0].ReturnType.Name == typeof(string).FullName);
            if (method == null)
            {
                "Not found function!".RedPrefix("MenuStateController::PushPage");
                return;
            }

            method.Invoke(this, new IntPtr[] { new IL2String_utf16(pageName).Pointer, uiContext == null ? IntPtr.Zero : uiContext.Pointer, new IntPtr(&clearPageStack), new IntPtr(&inPlace) });
        }
        
        public unsafe void PushPage(int contentIndex, UIContext uiContext = null, bool clearPageStack = false, bool inPlace = false)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(PushPage), x => x.GetParameters()[0].ReturnType.Name == typeof(string).FullName);
            if (method == null)
            {
                "Not found function!".RedPrefix("MenuStateController::PushPage");
                return;
            }

            method.Invoke(this, new IntPtr[] { new IntPtr(&contentIndex), uiContext == null ? IntPtr.Zero : uiContext.Pointer, new IntPtr(&clearPageStack), new IntPtr(&inPlace) });
        }


        public unsafe UIPage[] menuRootPages
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(menuRootPages));
                if (field == null)
                {
                    try
                    {
                        (field = Instance_Class.GetField(x => x.ReturnType.Name == UIPage.Instance_Class.FullName + "[]")).Name = nameof(menuRootPages);
                        if (field == null)
                            return null;
                    }
                    catch { "Get error find Reflection".RedPrefix("MenuStateController::menuRootPages"); }
                }
                IL2Object result = field.GetValue(this);
                if (result == null)
                    return null;

                return new IL2Array<IntPtr>(result.Pointer).ToArray<UIPage>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(menuRootPages));
                if (field == null)
                {
                    try
                    {
                        (field = Instance_Class.GetField(x => x.ReturnType.Name == UIPage.Instance_Class.FullName + "[]")).Name = nameof(menuRootPages);
                        if (field == null)
                            return;
                    }
                    catch { "Set error find Reflection".RedPrefix("MenuStateController::menuRootPages"); }
                }
                IL2Array<IntPtr> array = null;
                if (value != null)
                {
                    int len = value.Length;
                    array = new IL2Array<IntPtr>(len, UIPage.Instance_Class);
                    for(int i=0;i<len;i++)
                    {
                        array[i] = value[i] == null ? IntPtr.Zero : value[i].Pointer;
                    }
                }
                field.SetValue(this, array == null ? IntPtr.Zero : array.Pointer);
            }
        }

        public unsafe IL2Dictionary<IL2String, UIPage> _uiPages
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(_uiPages));
                if (field == null)
                {
                    (field = Instance_Class.GetField(x => x.ReturnType.Name.StartsWith("System.Collections.Generic.Dictionary"))).Name = nameof(_uiPages);
                    if (field == null)
                        return null;
                }
                IL2Object result = field.GetValue(this);
                if (result == null)
                    return null;

                return new IL2Dictionary<IL2String, UIPage>(result.Pointer);
            }
            set
            {

                IL2Field field = Instance_Class.GetField(nameof(_uiPages));
                if (field == null)
                {
                    (field = Instance_Class.GetField(x => x.ReturnType.Name.StartsWith("System.Collections.Generic.Dictionary"))).Name = nameof(_uiPages);
                    if (field == null)
                        return;
                }
                field.SetValue(this, value == null ? IntPtr.Zero : value.Pointer);
            }
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRC.UI.Elements"].GetClasses().FirstOrDefault(x => x.GetMethod("ShowTabContent", y => y.GetParameters().Length > 1) != null);
    }
}