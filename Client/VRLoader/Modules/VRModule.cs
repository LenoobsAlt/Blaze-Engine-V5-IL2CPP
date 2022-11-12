using System;
using System.Security.Policy;
using VRCLoader.Attributes;

namespace VRCLoader.Modules
{
	public class VRModule
	{
		public VRModule()
        {

        }

		internal VRModule(Type type)
        {
			this.type = type;
        }

		public Type type { get; private set; }

		public string Name { get; private set; }

		public string Version { get; private set; }

		public string Author { get; private set; }

		public ModuleManager ModuleManager { get; private set; }

		public void Unload()
		{
			ModuleManager.UnloadModule(this);
		}

		internal void Initialize(ModuleInfoAttribute moduleInfo, ModuleManager moduleManager)
		{
			Name = moduleInfo.Name;
			Version = moduleInfo.Version;
			Author = moduleInfo.Author;
			ModuleManager = moduleManager;
		}

		public override string ToString()
		{
			return string.Format("{0} ({1}) by {2}", this.Name, this.Version, this.Author);
		}
	}
}
