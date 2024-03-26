using System;
using System.Collections;
using System.Collections.Generic;
using GameServiceLocator;
using UnityEngine;

namespace Games.CameraManager
{
    public class OverlayCameraProvider : MonoBehaviour
    {
        [SerializeField]
        private Camera camera;
        
        private void OnEnable()
        {
            ServiceLocator.Current.Get<ICameraManager>().AddOverlayCamera(camera);
         //   Destroy(this);
        }

        private void OnDisable()
        {
            ServiceLocator.Current.Get<ICameraManager>().RemoveOverlayCamera(camera);
        }
    }
}