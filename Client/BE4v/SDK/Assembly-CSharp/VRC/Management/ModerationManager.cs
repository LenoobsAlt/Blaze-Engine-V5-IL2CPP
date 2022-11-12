using System;
using System.Linq;
using IL2CPP_Core.Objects;
using VRC.Core;
using SharpDisasm.Udis86;

namespace VRC.Management
{
    public class ModerationManager : IL2Object
    {
        public ModerationManager(IntPtr ptr) : base(ptr) { }

        public static ModerationManager Instance
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(Instance));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
                return property.GetGetMethod().Invoke().GetValue<ModerationManager>();
            }
        }

        unsafe public bool HasPlayerModeration(string userId, ApiPlayerModeration.ModerationType moderationType)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(HasPlayerModeration));
            if (method == null)
                (method = Instance_Class.GetMethod(x => x.IsPublic && x.ReturnType.Name == typeof(bool).FullName && x.GetParameters().Length == 2 && x.GetParameters()[1].ReturnType.Name == "VRC.Core.ApiPlayerModeration.ModerationType")).Name = nameof(HasPlayerModeration);
            return method.Invoke<bool>(this, new IntPtr[] { new IL2String_utf8(userId).Pointer, new IntPtr(&moderationType) }).GetValue();
        }
        

        unsafe public bool IsBlocked(APIUser user)
        {
            if (user == null) return false;
            IL2Method method = Instance_Class.GetMethod(nameof(IsBlocked));
            if (method == null)
            {

                var disassembler = VRC.Player.Instance_Class.GetMethod("OnNetworkReady").GetDisassembler(0x1000);
                var instructions = disassembler.Disassemble().Where(x => x.Mnemonic == ud_mnemonic_code.UD_Icall);
                foreach (var instruction in instructions)
                {
                    IntPtr addr = new IntPtr((long)instruction.Offset + instruction.Length + instruction.Operands[0].LvalSDWord);

                    method = Instance_Class.GetMethods().FirstOrDefault(x => *(IntPtr*)x.Pointer == addr && x.ReturnType.Name == typeof(bool).FullName);
                    if (method != null)
                    {
                        method.Name = nameof(IsBlocked);
                        break;
                    }
                }
            }
            return method?.Invoke<bool>(this, new IntPtr[] { user.Pointer }).GetValue() ?? default(bool);
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod(y => y.IsPrivate && y.GetParameters().Length == 2 && y.GetParameters()[1].ReturnType.Name == "VRC.Core.ApiPlayerModeration.ModerationType") != null);
    }
}
