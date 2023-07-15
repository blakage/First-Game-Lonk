using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitPortal : MonoBehaviour
{
    // Start is called before the first frame update
    public ImageFader imageFader;
    
    // Start is called before the first frame updat
    private AudioSource soundEffect;
    public Transform deathRewindPoint;

    public float portalReq;

    void Start()
    {
        GameObject coinAudioObj = GameObject.Find("DeathSound");
        if (coinAudioObj != null)
        {
            soundEffect = coinAudioObj.GetComponent<AudioSource>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<creature>() != null && Coin.score >= portalReq)
        {
            PlaySoundEffect();
            TeleportToDeathRewindPoint(other.gameObject);
        }
    }

    void TeleportToDeathRewindPoint(GameObject creature)
    {
        creature.transform.position = deathRewindPoint.position;
    }

    
    void PlaySoundEffect()
    {
        soundEffect.Play(); // Play the sound effect
    }
}
