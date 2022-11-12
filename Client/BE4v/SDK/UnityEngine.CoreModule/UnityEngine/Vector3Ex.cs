using System;
using System.Runtime.InteropServices;

namespace UnityEngine
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3Ex
    {
        /// <summary>
        ///   <para>Creates a new vector with given x, y, z components.</para>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector3Ex(IntPtr x, IntPtr y, IntPtr z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }



        // =========================================================
        //              VECTOR 3 const's
        // =========================================================

        /// <summary>
        ///   <para>X component of the vector.</para>
        /// </summary>
        public IntPtr x;

        /// <summary>
        ///   <para>Y component of the vector.</para>
        /// </summary>
        public IntPtr y;

        /// <summary>
        ///   <para>Z component of the vector.</para>
        /// </summary>
        public IntPtr z;
    }
}
