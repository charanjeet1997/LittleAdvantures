using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    #region PUBLIC_VARS
    [Range(0,120)]
    public int targetFramerate;
    [Range(0,4)]
    public int vSyncCount;

    public bool logEnabled;
    public bool runInBackground;
    #endregion

    #region PRIVATE_VARS

    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        Application.runInBackground = runInBackground;
        Application.targetFrameRate = targetFramerate;
        QualitySettings.vSyncCount = vSyncCount;
        Debug.unityLogger.logEnabled = logEnabled;


    }

    #endregion

    #region PUBLIC_METHODS
    #endregion

    #region PRIVATE_METHODS

    #endregion
}
