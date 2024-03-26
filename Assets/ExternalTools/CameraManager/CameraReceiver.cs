using System;
using GameServiceLocator;
using UnityEngine;
using UnityEngine.Events;

namespace Games.CameraManager
{
	public class CameraReceiver : MonoBehaviour,ICameraUpdateReceiver
	{
		#region PUBLIC_VARS

		public UnityEvent<Camera> UpdateCamera;
		#endregion

		#region PRIVATE_VARS

		#endregion

		#region UNITY_CALLBACKS

		private void OnEnable()
		{
			ServiceLocator.Current.Get<ICameraManager>().RegisterCameraUpdateReceiver(this);
		}
		private void OnDisable()
		{
			ServiceLocator.Current.Get<ICameraManager>().UnRegisterCameraUpdateReceiver(this);
		}
		#endregion

		#region PUBLIC_METHODS

		public void OnCameraUpdated(Camera camera)
		{
			Debug.Log("Update Camera Camera reciever");
			UpdateCamera.Invoke(camera);
		}

		#endregion

		#region PRIVATE_METHODS

		#endregion

	}
}