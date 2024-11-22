using UnityEngine;
using UnityEngine.UI;

public class buttonKeyPress : MonoBehaviour
{
    public Button myButton; // Assign the button in the Inspector
    public KeyCode activationKey = KeyCode.Space; // Key to trigger the button

    void Update()
    {
        // Check if the key is pressed
        if (Input.GetKeyDown(activationKey))
        {
            // Simulate button click
            myButton.onClick.Invoke();
        }
    }
}
