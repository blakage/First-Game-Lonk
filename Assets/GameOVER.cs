using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOVER : MonoBehaviour
{
    public TextMeshProUGUI gameOverText; // Reference to the "Game Over" Text component
    public ImageFader imageFader;
    bool changingScenes = false;
    private AudioSource soundEffect;
    // Start is called before the first frame update
    void Start()
    {
        // Hide the "Game Over" text initially
        gameOverText.gameObject.SetActive(false);
        GameObject death = GameObject.Find("DeathSound");
        if (death != null)
        {
            soundEffect = death.GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Assuming the "creature" script is attached to the player object
        creature playerCreature = FindObjectOfType<creature>();
        
        // Check if the player's health has reached zero or below
        if (playerCreature != null && playerCreature.healthPoints <= 0)
        {
            PlaySoundEffect();

            Destroy(playerCreature.gameObject);
            // Health has reached zero, call ChangeScene function with a delay
            StartCoroutine(ChangeSceneWithDelay("Level 1"));
        }
    }

    IEnumerator ChangeSceneWithDelay(string sceneName)
    {
        ShowGameOver(); // Show "Game Over" text

        yield return new WaitForSeconds(5f); // Show the "Game Over" text for 5 seconds

        // Now proceed to change the scene
        if (changingScenes)
        {
            yield break;
        }
        changingScenes = true;
        imageFader.FadeToBlack();
        yield return new WaitForSeconds(imageFader.fadeTime);
        SceneManager.LoadScene(sceneName);
    }
    void ShowGameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }

    void PlaySoundEffect()
    {
        soundEffect.Play(); // Play the sound effect
    }
}

