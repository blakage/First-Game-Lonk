using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float speed = 5.0f;

    //public GameObject target;

    Rigidbody2D rb;

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

    /*
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            // Destroy the block
            Destroy(collision.gameObject);

            // Destroy the projectile
            Destroy(gameObject);
        }
    }
    */

    
}
