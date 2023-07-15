using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBoundary : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the "Block" tag
        if (collision.gameObject.CompareTag("Block"))
        {
            // Block the movement of objects with the "Block" tag
            Rigidbody2D collidingRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (collidingRigidbody != null)
            {
                // Prevent the colliding object from moving
                collidingRigidbody.velocity = Vector2.zero;
                collidingRigidbody.angularVelocity = 0f;
            }
        }
    }
}
