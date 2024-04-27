using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the 'Q' key is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Quitgame(); // Call the Quitgame function
        }
    }

    public void Quitgame()
    {
        // Log a message to the console to confirm quitting (useful for testing in the editor)
        Debug.Log("Exiting Game");

        // Use UNITY_EDITOR preprocessing to handle quitting in the Unity editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit(); // Quit the game when built
        #endif
    }
}
