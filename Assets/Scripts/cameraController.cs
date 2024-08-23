using UnityEngine;
using System.IO;

public class CameraController : MonoBehaviour
{
    // Singleton instance
    public static CameraController Instance;

    // Serialized fields for position and rotation
    private Vector3 overheadPosition = new Vector3(-78, 47, 4);
    private Vector3 overheadRotation = new Vector3(90, 0, 0);
    private float overheadFOV = 50;

    private Vector3 realisticPosition = new Vector3(-67, 14, -17);
    private Vector3 realisticRotation = new Vector3(40, -18, -2);
    private float realisticFOV = 90;


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

    void Start()
    {
        
        moveCamera();
    }

    public void moveCamera()
    {
        
        string cameraMode = cameraSettings.Instance.getCameraMode();
        if (cameraMode == "overhead")
        {
            overhead();
        }
        else if (cameraMode == "realistic")
        {
            realistic();
        }
    }

    public void overhead()
    {
        transform.position = overheadPosition;
        transform.rotation = Quaternion.Euler(overheadRotation);
        Camera.main.fieldOfView = overheadFOV;
    }

    void realistic()
    {
        transform.position = realisticPosition;
        transform.rotation = Quaternion.Euler(realisticRotation);
        Camera.main.fieldOfView = realisticFOV;
    }
}
