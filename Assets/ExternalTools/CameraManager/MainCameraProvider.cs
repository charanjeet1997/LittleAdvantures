using System;
using System.Collections;
using System.Collections.Generic;
using GameServiceLocator;
using UnityEngine;

namespace Games.CameraManager
{
    public class MainCameraProvider : MonoBehaviour
    {
        [SerializeField]
        private Camera camera;
        
        private void OnEnable()
        {
            ServiceLocator.Current.Get<ICameraManager>().UpdateCamera(camera);
            Destroy(this);
        }
        [ContextMenu("ManualUpdate")]
        public void ManualUpdate()
        {
            ServiceLocator.Current.Get<ICameraManager>().UpdateCamera(camera);
            Destroy(this);
        }
    }
}