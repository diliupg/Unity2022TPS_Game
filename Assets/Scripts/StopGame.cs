using UnityEngine;

public class StopGame : MonoBehaviour
{
    // Define the key you want to use for stopping the game (e.g., Escape key).
    public KeyCode stopKey = KeyCode.Escape;

    void Update()
    {
        // Check if the designated key is pressed.
        if (Input.GetKeyDown(stopKey))
        {
            // Stop the game by setting the isPlaying flag to false.
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}