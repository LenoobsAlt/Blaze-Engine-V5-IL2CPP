using System;

namespace UnityEngine
{
    /// <summary>
    ///   <para>Structure used to get information back from a raycast.</para>
    /// </summary>
    public struct RaycastHit
    {
        /// <summary>
        ///   <para>The impact point in world space where the ray hit the collider.</para>
        /// </summary>
        public Vector3 point
        {
            get
            {
                return m_Point;
            }
            set
            {
                m_Point = value;
            }
        }

        /// <summary>
        ///   <para>The normal of the surface the ray hit.</para>
        /// </summary>
        public Vector3 normal
        {
            get
            {
                return m_Normal;
            }
            set
            {
                m_Normal = value;
            }
        }

        /// <summary>
        ///   <para>The barycentric coordinate of the triangle we hit.</para>
        /// </summary>
        public Vector3 barycentricCoordinate
        {
            get
            {
                return new Vector3(1f - (m_UV.y + m_UV.x), m_UV.x, m_UV.y);
            }
            set
            {
                m_UV = value;
            }
        }

        /// <summary>
        ///   <para>The distance from the ray's origin to the impact point.</para>
        /// </summary>
        public float distance
        {
            get
            {
                return m_Distance;
            }
            set
            {
                m_Distance = value;
            }
        }

        /// <summary>
        ///   <para>The index of the triangle that was hit.</para>
        /// </summary>
        public int triangleIndex
        {
            get
            {
                return m_FaceID;
            }
        }

        /*
        /// <summary>
        ///   <para>The uv texture coordinate at the collision location.</para>
        /// </summary>
        public Vector2 textureCoord
        {
            get
            {
                Vector2 result;
                RaycastHit.CalculateRaycastTexCoord(out result, collider, m_UV, m_Point, m_FaceID, 0);
                return result;
            }
        }

        /// <summary>
        ///   <para>The secondary uv texture coordinate at the impact point.</para>
        /// </summary>
        public Vector2 textureCoord2
        {
            get
            {
                Vector2 result;
                RaycastHit.CalculateRaycastTexCoord(out result, collider, m_UV, m_Point, m_FaceID, 1);
                return result;
            }
        }

        public Vector2 textureCoord1
        {
            get
            {
                Vector2 result;
                RaycastHit.CalculateRaycastTexCoord(out result, collider, m_UV, m_Point, m_FaceID, 1);
                return result;
            }
        }

        /// <summary>
        ///   <para>The uv lightmap coordinate at the impact point.</para>
        /// </summary>
        public Vector2 lightmapCoord
        {
            get
            {
                Vector2 result;
                RaycastHit.CalculateRaycastTexCoord(out result, .collider, m_UV, m_Point, m_FaceID, 1);
                if (collider.GetComponent<Renderer>() != null)
                {
                    Vector4 lightmapScaleOffset = collider.GetComponent<Renderer>().lightmapScaleOffset;
                    result.x = result.x * lightmapScaleOffset.x + lightmapScaleOffset.z;
                    result.y = result.y * lightmapScaleOffset.y + lightmapScaleOffset.w;
                }
                return result;
            }
        }
        */

        /// <summary>
        ///   <para>The Collider that was hit.</para>
        /// </summary>
        public Collider collider
        {
            get => Object.FindObjectFromInstanceID(m_Collider)?.GetValue<Collider>();
        }

        /*
        /// <summary>
        ///   <para>The Rigidbody of the collider that was hit. If the collider is not attached to a rigidbody then it is null.</para>
        /// </summary>
        public Rigidbody rigidbody
        {
            get
            {
                return (!(collider != null)) ? null : collider.attachedRigidbody;
            }
        }
        */
        /*
        /// <summary>
        ///   <para>The Transform of the rigidbody or collider that was hit.</para>
        /// </summary>
        public Transform transform
        {
            get
            {
                Transform result;
                /*
                Rigidbody rigidbody = rigidbody;
                if (rigidbody != null)
                {
                    result = rigidbody.transform;
                }
                else */
        /*
                if (collider != null)
                {
                    result = collider.transform;
                }
                else
                {
                    result = null;
                }
                return result;
            }
        }
        */
        private Vector3 m_Point;

        private Vector3 m_Normal;

        private int m_FaceID;

        private float m_Distance;

        private Vector2 m_UV;

        private int m_Collider;
    }
}
