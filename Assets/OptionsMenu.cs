using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the pause menu UI game object
    private bool isPaused = false; // Flag to track if the game is paused
    public AudioMixer audioMixer; 
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false;
        //pauseMenuUI.SetActive(false); // Start with the pause menu UI hidden
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Debug.Log("Paused");
        Time.timeScale = 0f; // Freeze the game time
        isPaused = true;
        GetComponent<Canvas>().enabled = true; // Show the pause menu UI

       
    }

    public void ResumeGame()
    {
        Debug.Log("Resumed");
        Time.timeScale = 1f; // Restore the game time
        isPaused = false;
        GetComponent<Canvas>().enabled = false;// Hide the pause menu UI

        
    }

    public void SetWindowedMode()
    {
        Screen.fullScreen = false; // Switch to windowed mode
    }

    public void SetFullscreenMode()
    {
        Screen.fullScreen = true; // Switch to fullscreen mode
    }

    
    
}

