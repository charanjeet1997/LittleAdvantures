using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Games.CameraManager
{
	public class CameraManager : ICameraManager
	{
		public List<ICameraUpdateReceiver> CameraUpdateReceivers { get; }
		public List<ICameraUpdateReceiver> cameraUpdateReceivers;

		private Camera camera;
		private Camera arCamera;
		public CameraManager()
		{
			this.cameraUpdateReceivers = new List<ICameraUpdateReceiver>();
		}
		
		public void UpdateCamera(Camera camera)
		{
			this.camera = camera;
			Debug.Log("Update Camera from Camera Manager");
			for (int indexOfReceiver = 0; indexOfReceiver < cameraUpdateReceivers.Count; indexOfReceiver++)
			{
				cameraUpdateReceivers[indexOfReceiver].OnCameraUpdated(this.camera);
			}
		}

		public void AddOverlayCamera(Camera camera)
		{
			if (this.camera != null)
			{
				UniversalAdditionalCameraData additionalCameraData = this.camera.GetUniversalAdditionalCameraData();
				if (!additionalCameraData.cameraStack.Contains(camera))
				{
					List<Camera> cameras = new List<Camera>(additionalCameraData.cameraStack);
					additionalCameraData.cameraStack.Clear();
					additionalCameraData.cameraStack.Add(camera);
					additionalCameraData.cameraStack.AddRange(cameras);
				}
			}
		}

		public void RemoveOverlayCamera(Camera camera)
		{
			if (this.camera != null)
			{
				UniversalAdditionalCameraData additionalCameraData = this.camera.GetUniversalAdditionalCameraData();
				if (additionalCameraData.cameraStack.Contains(camera))
				{
					additionalCameraData.cameraStack.Remove(camera);
				}
			}
		}

		public Camera GetCamera()
		{
			return camera;
		}
		

		public void RegisterCameraUpdateReceiver(ICameraUpdateReceiver cameraUpdateReceiver)
		{
			if (!cameraUpdateReceivers.Contains(cameraUpdateReceiver))
			{
				cameraUpdateReceivers.Add(cameraUpdateReceiver);
			}

			if (camera != null)
			{
				cameraUpdateReceiver.OnCameraUpdated(camera);
			}
		}

		public void UnRegisterCameraUpdateReceiver(ICameraUpdateReceiver cameraUpdateReceiver)
		{
			if (cameraUpdateReceivers.Contains(cameraUpdateReceiver))
			{
				cameraUpdateReceivers.Remove(cameraUpdateReceiver);
			}
		}
		
	}
}