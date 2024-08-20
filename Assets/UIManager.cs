using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text displayText;
    public Button myButton;

    private void Start()
    {
        // Ensure the button and text are assigned
        if (myButton != null)
        {
            myButton.onClick.AddListener(OnButtonClick);
        }
    }

    private void OnButtonClick()
    {
        if (displayText != null)
        {
            displayText.text = "Button Clicked!";
        }
    }
}