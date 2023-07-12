using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ObstacleLevel2 : MonoBehaviour
{
    // Start is called before the first frame update
    public ImageFader imageFader;
    public TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    bool changingScenes = false;
    private AudioSource soundEffect;
    public Transform deathRewindPoint;

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
        if (other.GetComponent<creature>() != null)
        {
            PlaySoundEffect();
            TeleportToDeathRewindPoint(other.gameObject);
        }
    }

    void TeleportToDeathRewindPoint(GameObject creature)
    {
        creature.transform.position = deathRewindPoint.position;
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
}
