using System;
using Games.CameraManager;
using Games.SinghKage.LittleAdvantures;
using UnityEngine;

namespace GameServiceLocator
{
	public static class Bootstrapper
	{
		#region PUBLIC_VARS
		
		#endregion

		#region PRIVATE_VARS

		#endregion

		#region UNITY_CALLBACKS
		#endregion

		#region PUBLIC_METHODS

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void Initiailze()
		{
			// Initialize default service locator.
			ServiceLocator.Initiailze();
			ServiceLocator.Current.Register<ICameraManager>(new CameraManager());
			ServiceLocator.Current.Register<IPlayerMovementInput>(new PlayerMovementInput());
		}

		#endregion

		#region PRIVATE_METHODS

		#endregion

	}
}