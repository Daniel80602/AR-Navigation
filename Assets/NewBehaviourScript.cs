using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPanelCameraControl : MonoBehaviour
{
    [Tooltip("The main camera provided by Unity")]
    public Camera mainCamera;

    void Start()
    {
        if (mainCamera == null)
        {
            Debug.LogError("No main camera found in the scene!");
            return;
        }

        // Check if this script is attached to panel1 or panel2 (modify names as needed)
        if (gameObject.name == "panel1" || gameObject.name == "panel2")
        {
            mainCamera.enabled = true;
        }
        else
        {
            mainCamera.enabled = false;
        }
    }
}
