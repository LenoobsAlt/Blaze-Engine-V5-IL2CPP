using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;
using UnityEngine.UI;

public class VRCUiPopupManager : MonoBehaviour
{
    public VRCUiPopupManager(IntPtr ptr) : base(ptr) { }

    unsafe static VRCUiPopupManager()
    {
        IL2Method method = null;
        IL2Method[] methods = Instance_Class.GetMethods(x =>
            x.ReturnType.Name == typeof(void).FullName
        );
        var instructions = UiInputField.Instance_Class.GetMethod("PressEdit").GetDisassembler(0x256).Disassemble();
        foreach(var instruction in instructions)
        {
            if (instruction.Mnemonic == SharpDisasm.Udis86.ud_mnemonic_code.UD_Icall)
            {
                IntPtr addr = new IntPtr((long)instruction.Offset + instruction.Length + instruction.Operands[0].LvalSDWord);
                if ((method = methods.FirstOrDefault(x => *(IntPtr*)x.Pointer == addr)) != null)
                    continue;
            }
        }
        var parameters = method.GetParameters();
        if (parameters.Length != 12)
        {
            "VRCUiPopupManager::ShowUnityInputPopupWithCancel".RedPrefix("Failed");

            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i].ReturnType.Name.RedPrefix("" + i);
            }
        }
        else
        {
            method.Name = nameof(ShowUnityInputPopupWithCancel);
        }
    }

    public static VRCUiPopupManager Instance
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(Instance));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
            return property.GetGetMethod().Invoke().GetValue<VRCUiPopupManager>();
        }
    }

    unsafe public void ShowAlert(string title, string body, float timeout = 10f)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(ShowAlert));
        if (method == null)
            (method = Instance_Class.GetMethods(x => x.GetParameters().Length == 3 && x.GetParameters()[2].ReturnType.Name == typeof(float).FullName).First(x => x.GetDisassembler().Disassemble().Count() == 1010)).Name = nameof(ShowAlert);
        method.Invoke(this, new IntPtr[] { new IL2String_utf16(title).Pointer, new IL2String_utf16(body).Pointer, new IntPtr(&timeout) });
    }

    public void ShowUnityInputPopupWithCancel(
        string title,
        string body,
        InputField.InputType inputType,
        bool useNumericKeypad,
        string submitButtonText,
        // Action<string, List<KeyCode>, Text>
        Action<IntPtr, IntPtr, IntPtr> submitButtonAction,
        Action cancelButtonAction,
        string placeholderText = "Enter text....",
        bool hidePopupOnSubmit = true,
        Action<VRCUiPopup> additionalSetup = null,
        bool nanBool = false,
        int nanInt32 = 0
    )
    {
        IL2Delegate _submitButtonAction = null;
        if (submitButtonAction != null)
            _submitButtonAction = IL2Delegate.CreateDelegate(submitButtonAction, IL2Action<IntPtr, IntPtr, IntPtr>.Instance_Class);

        IL2Delegate _cancelButtonAction = null;
        if (cancelButtonAction != null)
            _cancelButtonAction = IL2Delegate.CreateDelegate(cancelButtonAction);

        IL2Delegate _additionalSetup = null;

        ShowUnityInputPopupWithCancel(
            title,
            body,
            inputType,
            useNumericKeypad,
            submitButtonText,
            _submitButtonAction,
            _cancelButtonAction,
            placeholderText,
            hidePopupOnSubmit,
            _additionalSetup,
            nanBool,
            nanInt32
        );
    }
    unsafe public void ShowUnityInputPopupWithCancel(
        string title,
        string body,
        InputField.InputType inputType,
        bool useNumericKeypad,
        string submitButtonText,
        IL2Delegate submitButtonAction,
        IL2Delegate cancelButtonAction,
        string placeholderText = "Enter text....",
        bool hidePopupOnSubmit = true,
        IL2Delegate additionalSetup = null,
        bool nanBool = false,
        int nanInt32 = 0
    )
    {
        IL2Method method = Instance_Class.GetMethod(nameof(ShowUnityInputPopupWithCancel));
        if (method == null)
        {
            "Method not found!".RedPrefix("VRCUiPopupManager::ShowUnityInputPopupWithCancel");
            return;
        }

        method.Invoke(this, new IntPtr[] {
            new IL2String_utf8(title).Pointer, // string
            new IL2String_utf8(body).Pointer, //  string
            new IntPtr(&inputType), // InputType : int
            new IntPtr(&useNumericKeypad), // bool
            new IL2String_utf8(submitButtonText).Pointer, // string
            submitButtonAction == null ? IntPtr.Zero : submitButtonAction.Pointer, // Action<string, IL2List<KeyCode>, Text>
            cancelButtonAction == null ? IntPtr.Zero : cancelButtonAction.Pointer, // Action
            new IL2String_utf8(placeholderText).Pointer, // string Default: "Enter text...."
            new IntPtr(&hidePopupOnSubmit), // bool Default: true
            additionalSetup == null ? IntPtr.Zero :additionalSetup.Pointer, // Action<VRCUiPopup> Default: null
            new IntPtr(&nanBool), // bool Default: false
            new IntPtr(&nanInt32) // bool Default: 0
        });
    }


    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("ShowControllerBindingsPopup") != null);

    public enum inputStyle
    {
        Javascript,
        Unity
    }
}