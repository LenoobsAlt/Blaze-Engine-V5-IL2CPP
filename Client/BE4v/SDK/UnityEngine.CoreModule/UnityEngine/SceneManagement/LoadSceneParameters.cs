using System;

namespace UnityEngine.SceneManagement
{
	[Serializable]
	public struct LoadSceneParameters
	{
		public LoadSceneParameters(LoadSceneMode mode)
		{
			m_LoadSceneMode = mode;
			m_LocalPhysicsMode = LocalPhysicsMode.None;
		}

		// [SerializeField]
		private LoadSceneMode m_LoadSceneMode;

		// [SerializeField]
		private LocalPhysicsMode m_LocalPhysicsMode;
	}
}
