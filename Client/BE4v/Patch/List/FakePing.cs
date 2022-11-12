using System;
using System.Linq;
using IL2CPP_Core.Objects;
using BE4v.MenuEdit;
using BE4v.Mods;
using BE4v.SDK;
using BE4v.Patch.Core;
using SharpDisasm.Udis86;

namespace BE4v.Patch.List
{
    public class FakePing : IPatch
    {
        public delegate int _NetworkPing();

        public static void Toggle()
        {
            Status.isFakePing = !Status.isFakePing;
            CustomQuickMenu.Menus.BE4VMenu.FakePing.Refresh();
        }

        public void Start()
        {
            IL2Method method = VRC.UI.DebugDisplayText.Instance_Class.GetMethod("Update");
            var methods = IL2Photon.Pun.PhotonNetwork.Instance_Class.GetMethods(x => x.ReturnType.Name == typeof(int).FullName && x.GetParameters().Length == 0);

            unsafe
            {
                var disassembler = method.GetDisassembler(0x512);
                var instructions = disassembler.Disassemble().Where(x => x.Mnemonic == ud_mnemonic_code.UD_Icall);
                foreach (var instruction in instructions)
                {
                    IntPtr addr = new IntPtr((long)instruction.Offset + instruction.Length + instruction.Operands[0].LvalSDWord);
                    if ((method = methods.FirstOrDefault(x => *(IntPtr*)x.Pointer == addr)) != null)
                        break;
                }
            }

            if (method != null)
            {
                patch = new IL2Patch(method, (_NetworkPing)methodNetworkPing);
                _RealPing = patch.CreateDelegate<_NetworkPing>();
                patch.Enabled = false;
            }
            else
                throw new NullReferenceException();
        }

        private static int methodNetworkPing()
        {
            int result = 777;
            if (!Status.isFakePing || VRC.Player.Instance == null)
                result = _RealPing();
            return result;
        }

        public static IL2Patch patch;

        public static _NetworkPing _RealPing;
    }
}
