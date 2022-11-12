using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BE4v.MenuEdit.Construct
{
    public class QuickObject
    {
        public GameObject gameObject;
        
        public override bool Equals(object obj)
        {
            if (obj == null) return this == null;
            if (obj is QuickObject b) return b.gameObject.Pointer == gameObject.Pointer;
            return false;
        }
        public override int GetHashCode() => gameObject.Pointer.GetHashCode();
        public static bool operator !=(QuickObject x, QuickObject y) => !(x == y);
        public static bool operator ==(QuickObject x, QuickObject y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return x.gameObject?.Pointer == y.gameObject?.Pointer;
        }
    }
}
