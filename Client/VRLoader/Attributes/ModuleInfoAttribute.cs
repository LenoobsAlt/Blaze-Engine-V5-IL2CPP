using System;

namespace VRCLoader.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class ModuleInfoAttribute : Attribute
	{
		public string Name { get; }

		public string Version { get; }

		public string Author { get; }

		public ModuleInfoAttribute(string name, string version, string author)
		{
			Name = name;
			Version = version;
			Author = author;
		}
	}
}
