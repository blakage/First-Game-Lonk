using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAlter : MonoBehaviour
{
    public float newGravityScale = 0.2f; // The new gravity scale to be applied to the creature

    void OnTriggerEnter2D(Collider2D other)
    {
        creature creature = other.GetComponent<creature>();
        if (creature != null)
        {
            Rigidbody2D creatureRigidbody = creature.GetComponent<Rigidbody2D>();
            if (creatureRigidbody != null)
            {
                creatureRigidbody.gravityScale = newGravityScale;
            }
        }
    }
}
