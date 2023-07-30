using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinner : MonoBehaviour
{
    // Start is called before the first frame update
    public ImageFader imageFader;
    bool changingScenes = false;
    private AudioSource soundEffect;
    // Start is called before the first frame update
    void Start()
    {
        // Hide the "Game Over" text initially
    }

    void Update()
    {
        // Check if the player's health has reached zero or below
        if (BossControl.bossDead)
        {
            // Health has reached zero, call ChangeScene function with a delay
            StartCoroutine(ChangeSceneWithDelay("Victory"));
        }
    }

    IEnumerator ChangeSceneWithDelay(string sceneName)
    {

        yield return new WaitForSeconds(2.5f); // Show the "Game Over" text for 5 seconds

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

    void PlaySoundEffect()
    {
        soundEffect.Play(); // Play the sound effect
    }
}
