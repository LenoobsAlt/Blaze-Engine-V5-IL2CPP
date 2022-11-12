using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime;
using VRCLoader.Attributes;
using VRCLoader.Utils;

namespace VRCLoader.Modules
{
    public sealed class ModuleManager
	{
		private List<VRModule> _modules { get; } = new List<VRModule>();

		public ReadOnlyCollection<VRModule> Modules
		{
			get
			{
				return _modules.AsReadOnly();
			}
		}

		internal ReadOnlyCollection<VRModule> FindModules(string path = "Modules\\")
		{
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
				Logs.Log("Modules folder does not exist.");
				return Modules;
			}
			foreach (string path2 in Directory.GetFiles(path))
			{
				if (Path.GetExtension(path2) == ".dll")
				{
					Assembly assembly;
                    /*
					try
					{
						assembly = Assembly.LoadFrom(path2);
					}
					catch (Exception ex)
					{
						Logs.Log("Error loading \"{0}\". Are you sure this is a valid assembly?", Path.GetFileName(path2));
						Logs.Log("EX: " + ex);
						goto IL_10A;
					}
					*/
                    try
					{
						assembly = Assembly.Load(File.ReadAllBytes(path2));
					}
					catch (Exception ex)
					{
						Logs.Log("Error loading \"{0}\". Are you sure this is a valid assembly?", Path.GetFileName(path2));
						goto IL_10A;
					}
					foreach (Type type in from t in assembly.GetTypes()
										  where t.IsSubclassOf(typeof(VRModule))
										  select t)
					{
						ModuleInfoAttribute moduleInfo;
						if ((moduleInfo = (type.GetCustomAttributes(typeof(ModuleInfoAttribute), true).FirstOrDefault<object>() as ModuleInfoAttribute)) != null)
						{
							VRModule vrmodule = new VRModule(type);
							_modules.Add(vrmodule);
							vrmodule.Initialize(moduleInfo, this);
							Logs.Log("{0} loaded.", vrmodule);
						}
					}
				}
			IL_10A:;
			}
			return Modules;
		}

		public void UnloadModule(VRModule module)
		{
			if (_modules.Contains(module))
			{
				_modules.Remove(module);
				Logs.Log("{0} unloaded.", module);
			}
		}
	}
}
