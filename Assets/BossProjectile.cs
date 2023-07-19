using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BossProjectile : MonoBehaviour
{

    [Header("projectile")]
    public float speed = 5.0f;
    Rigidbody2D rb;

    [Header("Audio")]
    private AudioSource soundEffect;

    // Start is called before the first frame update

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject,5);

    }
    

    public void LaunchProjectile(Vector3 position){
        transform.rotation = Quaternion.LookRotation(transform.forward, position - transform.position);
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        creature creature = collision.gameObject.GetComponent<creature>();
        if (creature != null)
        {
            // Handle collision with the player's creature

            // Destroy the BossProjectile game object
            Destroy(gameObject);
        }
    }
   

    
}
