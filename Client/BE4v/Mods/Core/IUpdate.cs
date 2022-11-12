using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE4v.Mods.Core
{
    public interface IUpdate : IThread
    {
        void Update();
    }
}
