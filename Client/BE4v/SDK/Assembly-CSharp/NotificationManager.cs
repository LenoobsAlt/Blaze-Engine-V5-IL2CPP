using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;
using Transmtn.DTO.Notifications;
using VRC.UI;

public class NotificationManager : MonoBehaviour
{
    public NotificationManager(IntPtr ptr) : base(ptr) { }

    public static NotificationManager Instance
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(Instance));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);

            return property?.GetGetMethod().Invoke()?.GetValue<NotificationManager>();
        }
    }

    private static IL2Method methodSendNotification = null;
    public void SendNotification(string receiverUserId, string type, string message, NotificationDetails details)
    {
        if (methodSendNotification == null)
        {
            IL2Method method = PageUserInfo.Instance_Class.GetMethod("RequestInvitation");
            unsafe
            {
                var disassembler = method.GetDisassembler(0x1000);
                var instructions = disassembler.Disassemble().Where(x => x.Mnemonic == SharpDisasm.Udis86.ud_mnemonic_code.UD_Icall);
                foreach (var instruction in instructions)
                {
                    try
                    {

                        IntPtr addr = new IntPtr((long)instruction.Offset + instruction.Length + instruction.Operands[0].LvalSDWord);
                        methodSendNotification = Instance_Class.GetMethods().Where(x => !x.IsStatic && x.GetParameters().Length == 4).FirstOrDefault(x => *(IntPtr*)x.Pointer == addr);
                        if (methodSendNotification != null)
                            break;
                    }
                    catch
                    {
                    }
                }
            }
            if (methodSendNotification == null)
                return;
        }

        methodSendNotification.Invoke(this, new IntPtr[] { new IL2String_utf16(receiverUserId).Pointer, new IL2String_utf16(type).Pointer, new IL2String_utf16(message).Pointer, details.Pointer });
    }

    public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass("NotificationManager");
}
