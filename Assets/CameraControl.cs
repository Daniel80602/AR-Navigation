using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraControl : MonoBehaviour
{
    // Reference to the main camera
    public Camera mainCamera;

    // Reference to the specific panel
    public GameObject specificPanel;
    
    public void Start()
    {
        // Ensure the main camera is initially disabled
        mainCamera.enabled = false;
    }

     public void OnPanelEnter()
    {
        // Enable the main camera when entering the specific panel
        mainCamera.enabled = true;
    }

    public void OnPanelExit()
    {
        // Disable the main camera when exiting the specific panel
        mainCamera.enabled = false;
    }
}

