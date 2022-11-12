using System;

namespace UnityEngine
{
    /// <summary>
    ///   <para>Representation of rays.</para>
    /// </summary>
    public struct Ray
    {
        /// <summary>
        ///   <para>Creates a ray starting at origin along direction.</para>
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="direction"></param>
        public Ray(Vector3 origin, Vector3 direction)
        {
            this.m_Origin = origin;
            this.m_Direction = direction.normalized;
        }

        /// <summary>
        ///   <para>The origin point of the ray.</para>
        /// </summary>
        public Vector3 origin
        {
            get
            {
                return this.m_Origin;
            }
            set
            {
                this.m_Origin = value;
            }
        }

        /// <summary>
        ///   <para>The direction of the ray.</para>
        /// </summary>
        public Vector3 direction
        {
            get
            {
                return this.m_Direction;
            }
            set
            {
                this.m_Direction = value.normalized;
            }
        }

        /// <summary>
        ///   <para>Returns a point at distance units along the ray.</para>
        /// </summary>
        /// <param name="distance"></param>
        public Vector3 GetPoint(float distance)
        {
            return this.m_Origin + this.m_Direction * distance;
        }

        /// <summary>
        ///   <para>Returns a nicely formatted string for this ray.</para>
        /// </summary>
        /// <param name="format"></param>
        public override string ToString()
        {
            return UnityString.Format("Origin: {0}, Dir: {1}", new object[]
            {
                this.m_Origin,
                this.m_Direction
            });
        }

        /// <summary>
        ///   <para>Returns a nicely formatted string for this ray.</para>
        /// </summary>
        /// <param name="format"></param>
        public string ToString(string format)
        {
            return UnityString.Format("Origin: {0}, Dir: {1}", new object[]
            {
                this.m_Origin.ToString(format),
                this.m_Direction.ToString(format)
            });
        }

        private Vector3 m_Origin;

        private Vector3 m_Direction;
    }
}
