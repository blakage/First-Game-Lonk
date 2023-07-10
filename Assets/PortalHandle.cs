using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalHandle : MonoBehaviour
{
     public ImageFader imageFader;
    // Start is called before the first frame update
    public void PrintHello(){
        Debug.Log("Hello!");
    }

    bool changingScenes = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<creature>() != null && Coin.score == 2)
        {
            
            ChangeScene("Level 2");

        }
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
}
