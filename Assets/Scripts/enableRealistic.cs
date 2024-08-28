using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class enableRealistic : MonoBehaviour {
    

    void Start() 
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ModifyTxt);
        if (cameraSettings.Instance.getCameraMode() == "realistic"){
            btn.Select();
        }
    }
    
    void ModifyTxt()
    {              
        cameraSettings.Instance.setCameraMode("realistic");
    }
}