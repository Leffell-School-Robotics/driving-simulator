using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneToLoad = "test";  // Name of the scene to load
    public int targetDisplay = 0;   // Index of the target display (0 for Display 1, 1 for Display 2)

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(SwitchScene);
    }

    void SwitchScene()
    {
        // Start the scene loading process
        StartCoroutine(LoadSceneAndSetResolution());
    }

    IEnumerator LoadSceneAndSetResolution()
    {
        // Load the scene asynchronously
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }

        // Find the main camera in the newly loaded scene
        Camera camera = Camera.main;

        if (camera != null)
        {
            // Set the camera to render on the target display
            camera.targetDisplay = targetDisplay;

            // Activate the target display
            Display.displays[targetDisplay].Activate();

            // Set the resolution to 1920x1080 in windowed mode
            Screen.SetResolution(1920, 1080, false, 60);

            Debug.Log($"Switched to {sceneToLoad} on Display {targetDisplay + 1} with resolution 1920x1080 in windowed mode.");
        }
        else
        {
            Debug.LogWarning("No camera found in the scene!");
        }
    }
}
