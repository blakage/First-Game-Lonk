using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBoundary : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the creature
        if (other.CompareTag("Creature"))
        {
            // Allow the creature to pass through by disabling the collider
            GetComponent<EdgeCollider2D>().enabled = false;
            // Alternatively, you can set the collider as a trigger temporarily:
            // GetComponent<EdgeCollider2D>().isTrigger = true;
        }
    }
}
