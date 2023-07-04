using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Obstacle : MonoBehaviour
{
    public ImageFader imageFader;
    public TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    bool changingScenes = false;
    private AudioSource soundEffect;

    void Start()
    {
        GameObject coinAudioObj = GameObject.Find("DeathSound");
        if (coinAudioObj != null)
        {
            soundEffect = coinAudioObj.GetComponent<AudioSource>();
        }
        // Hide the gameOverText object at the start
        gameOverText.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision!");
        if(other.GetComponent<creature>() != null)
        {
            AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
            foreach (AudioSource audioSource in audioSources)
            {
                audioSource.Stop();
            }
            PlaySoundEffect();
            ShowGameOver();
            ChangeScene("MainMenu");
        }

    }

    void ShowGameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }

    public void ChangeScene(string sceneName ){
        if(changingScenes){
            return;
        }
        changingScenes = true;
        StartCoroutine(ChangeSceneRoutine());
        IEnumerator ChangeSceneRoutine(){
            imageFader.FadeToBlack();
            yield return new WaitForSeconds(imageFader.fadeTime);
            SceneManager.LoadScene(sceneName);
            yield return null;
        }
        
    }
    void PlaySoundEffect()
    {
        soundEffect.Play(); // Play the sound effect
    }
    // Update is called once per frame
    
}
