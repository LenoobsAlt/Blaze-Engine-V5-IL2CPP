using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using IL2CPP_Core.Objects;

namespace BE4v.Patch.Core
{
    public static class Installer
    {
        public static void Start()
        {
            IEnumerable<Type> types;
            try
            {
                types = Assembly.GetExecutingAssembly().GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                types = e.Types.Where(t => t != null);
            }
            foreach (var t in types)
            {
                if (t.IsAbstract)
                    continue;
                if (!typeof(IPatch).IsAssignableFrom(t))
                    continue;

                var patch = Activator.CreateInstance(t) as IPatch;
                try
                {
                    patch.Start();
                    $"Success patch: {t.Name}".GreenPrefix(nameof(IPatch));
                }
                catch (Exception ex)
                {
                    $"Success patch: {t.Name} | Ex: {ex}".RedPrefix(nameof(IPatch));
                }
            }
        }
    }
}
