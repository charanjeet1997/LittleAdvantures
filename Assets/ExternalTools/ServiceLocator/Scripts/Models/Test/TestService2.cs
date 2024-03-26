using System;
using UnityEngine;

namespace GameServiceLocator
{
	public class TestService2 : MonoBehaviour,IGameService
	{
		#region PUBLIC_VARS

		#endregion

		#region PRIVATE_VARS

		#endregion

		#region UNITY_CALLBACKS

		private void OnEnable()
		{
			ServiceLocator.Current.Register(this);
		}
		private void OnDisable()
		{
			ServiceLocator.Current.Unregister<TestService1>();
		}
		#endregion

		#region PUBLIC_METHODS

		#endregion

		#region PRIVATE_METHODS

		#endregion

		public void LoadService()
		{
			Debug.Log("Load service 2");
		}

		public void UnloadService()
		{
			
		}
	}
}