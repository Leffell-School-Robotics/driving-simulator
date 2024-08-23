using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSettings : MonoBehaviour
{
    // Singleton instance
    public static cameraSettings Instance;

    private string cameraMode = "overhead";

    void Awake()
    {
        // Implement Singleton pattern
        if (Instance == null)
        {
            Instance = this;  // Assign the current instance to the static variable
            DontDestroyOnLoad(this.gameObject);  // Persist this object across scenes
        }
        else
        {
            Destroy(gameObject);  // Destroy any duplicate instance
        }
    }

    // Method to set the camera mode
    public void setCameraMode(string cameraMode)
    {
        this.cameraMode = cameraMode;
    }

    // Method to get the current camera mode
    public string getCameraMode()
    {
        return cameraMode;
    }
}
