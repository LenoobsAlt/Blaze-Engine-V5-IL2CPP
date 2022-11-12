using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Reflection;
using System.Runtime.ExceptionServices;
using VRCLoader.Attributes;
using VRCLoader.Modules;
using BE4v.MenuEdit.Construct;
using BE4v.SDK;
using BE4v.Mods.API;

namespace BE4v
{
    [ModuleInfo("BE4V", "4.0", "BlazeBest")]
    public class InjectDLL : VRModule
    {
        [HandleProcessCorruptedStateExceptions]
        public static void Start()
        {
            Main();
        }

        private static void InitLicense()
        {
            if (string.IsNullOrEmpty(License.GetLicense))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("---------------------------");
                Console.WriteLine("---- LICENSE NOT FOUND ----");
                Console.WriteLine("---------------------------");
                "Please update license from site: https://client.icefrag.ru/".RedPrefix("License");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("---------------------------");
                Console.WriteLine("---- LICENSE IS LOADED ----");
                Console.WriteLine("---------------------------");
                Console.ForegroundColor = ConsoleColor.Gray;
                try
                {
                    License.Connect();
                    if (License.IsLicense == true)
                    {
                        "Success auth in server!".GreenPrefix("License");
                        Avatars.LoadAvatars();
                    }
                    else if (License.IsLicense == false)
                    {
                        "Failed auth in server!".RedPrefix("License");
                        "Please update license from site: https://client.icefrag.ru/".RedPrefix("License");
                    }
                    else
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    "Failed API Load...".RedPrefix("License");
                    Console.WriteLine(ex);
                }
            }
        }

        public static void Main()
        {
            SDKLoader.Start();
            Patch.Core.Installer.Start();
            Mods.Core.Installer.Start();
            // NetworkSanity.NetworkSanity.Start();
            SDKLoader.Finish();
            Mods.Min.ClientConsole.Start();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--- Color For ESP ---");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[Cyan]   - You blocked or blocked by you");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Yellow] - You Friends");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[Red]    - Others");
            Console.ForegroundColor = ConsoleColor.Gray;
            new Thread(() => { InitLicense(); }).Start();

            if (ClientDebug.IsEnableDebug())
            {
                /*
                var mmm = VRCPlayer.Instance_Class.GetMethod("LoadAvatar", x => x.GetParameters()[0].ReturnType.Name == typeof(bool).FullName);
                IL2Object obj = new IL2Object(Import.Class.il2cpp_type_get_object(mmm.ptr));
                Console.WriteLine("Test Def val: " + obj.GetValuе<bool>());
                /*
                var instructions = NetworkManager.Instance_Class.GetMethod("OnJoinedRoom").GetDisassembler(0x256).Disassemble();
                int u = 0;
                foreach (var instruction in instructions)
                {
                    if (instruction.Mnemonic == SharpDisasm.Udis86.ud_mnemonic_code.UD_Imov)
                    {
                        try
                        {
                            unsafe
                            {
                                if (instruction.Operands.Length > 1)
                                {
                                    if (instruction.Operands[1].Size == 32 && instruction.Operands[1].Base == SharpDisasm.Udis86.ud_type.UD_R_RIP)
                                    {
                                        Console.WriteLine(instruction.Operands[1].Base.ToString());
                                        IntPtr addr = new IntPtr((long)instruction.Offset + instruction.Length + instruction.Operands[1].LvalSDWord);
                                        if (addr != IntPtr.Zero)
                                        {
                                            IntPtr ptr = *(IntPtr*)addr;
                                            // Console.WriteLine(ptr.ToString());
                                            if (ptr != IntPtr.Zero)
                                            {
                                                string test = new string((char*)(ptr + 0x14));
                                                Console.WriteLine(test);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch
                        {
                            int i = 0;
                            Console.WriteLine("Error: " + instruction.ToString());
                            foreach (var operand in instruction.Operands)
                            {
                                i++;
                                Console.WriteLine("[" + i + "]" + operand.ToString());
                            }
                        }
                    }
                }
                */
            }
        }
    }
}
