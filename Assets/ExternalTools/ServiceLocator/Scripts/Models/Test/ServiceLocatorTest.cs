using System;
using UnityEngine;

namespace GameServiceLocator
{
	public class ServiceLocatorTest : MonoBehaviour
	{

		#region PUBLIC_VARS
		
		#endregion

		#region PRIVATE_VARS

		#endregion

		#region UNITY_CALLBACKS

		private void Start()
		{
			ServiceLocator.Current.Get<TestService1>().LoadService();
			ServiceLocator.Current.Get<TestService2>().LoadService();
		}
		#endregion

		#region PUBLIC_METHODS

		#endregion

		#region PRIVATE_METHODS

		#endregion

	}
}