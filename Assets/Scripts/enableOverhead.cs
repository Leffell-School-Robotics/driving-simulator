using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class enableOverhead : MonoBehaviour {
    
    //cameraSettings cameraSettings_;
    
    void Start() 
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ModifyTxt);
    }
    
    void ModifyTxt()
    {              
        //cameraSettings_ = GameObject.FindGameObjectWithTag("CameraSettings").GetComponent<cameraSettings>();
        cameraSettings.Instance.setCameraMode("overhead");
        //Debug.Log("set to overhead");
    }
}