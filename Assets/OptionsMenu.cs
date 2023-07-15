using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the pause menu UI game object
    private bool isPaused = false; // Flag to track if the game is paused
    //public AudioMixer myAudioMixer;

    public UnityEvent onWindowedMode; // Event triggered when switching to windowed mode
    public UnityEvent onFullscreenMode;
    
   // Reference to the MasterAudio UI slider // Event triggered when switching to fullscreen mode

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = false;// Start with the pause menu UI hidden
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
        SetFullscreen(false); // Switch to windowed mode
        onWindowedMode.Invoke(); // Invoke the windowed mode event
    }

    public void SetFullscreenMode()
    {
        SetFullscreen(true); // Switch to fullscreen mode
        onFullscreenMode.Invoke(); // Invoke the fullscreen mode event
    }

    private void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void QuitGame(){
        Application.Quit();
    }
    
}
