using System;
using System.Runtime.CompilerServices;

namespace UnityEngine
{
	/// <summary>
	///   <para>Specifies Layers to use in a Physics.Raycast.</para>
	/// </summary>
	public struct LayerMask
	{
		public static implicit operator int(LayerMask mask)
		{
			return mask.m_Mask;
		}

		public static implicit operator LayerMask(int intVal)
		{
			LayerMask result;
			result.m_Mask = intVal;
			return result;
		}

		/// <summary>
		///   <para>Converts a layer mask value to an integer value.</para>
		/// </summary>
		public int value
		{
			get
			{
				return m_Mask;
			}
			set
			{
				m_Mask = value;
			}
		}

		private int m_Mask;
	}
}
