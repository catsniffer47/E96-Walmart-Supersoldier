using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public DoNotDestroy musicController;  // Reference to the DoNotDestroy script

    private void Start()
    {
        // Assuming the DoNotDestroy script is attached to the object with the "MenuMusic" tag
        musicController = GameObject.FindGameObjectWithTag("MenuMusic").GetComponent<DoNotDestroy>();
    }

    public void StartGame()
    {
        // Stop the music when the Start Button is clicked
        if (musicController != null)
        {
            musicController.StopMusic();
        }

        // Load the next scene (you might want to adjust the index)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
    }
}
