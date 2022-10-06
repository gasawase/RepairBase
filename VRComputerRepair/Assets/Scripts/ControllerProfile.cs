using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.OpenXR;
using UnityEngine.XR.OpenXR.Features;


public class ControllerProfile : MonoBehaviour
{
    
    private void Start()
    {
        
        Debug.Log("Current Headset in Use: " + OpenXRFeatureSystemInfo.GetHeadsetName());

    }
}
