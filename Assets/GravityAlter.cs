using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAlter : MonoBehaviour
{
    public float newGravityScale = 0.2f; // The new gravity scale to be applied to the creature
    public float normalCamera = 7.3f;
    public float smoothTime;

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

        CameraFollow cameraFollowZoom = Camera.main.GetComponent<CameraFollow>();
        if (cameraFollowZoom != null)
        {
            cameraFollowZoom.zoomLevel = normalCamera;
        }

        CameraFollow cameraFollowSmooth = Camera.main.GetComponent<CameraFollow>();
        if (cameraFollowSmooth != null)
        {
            cameraFollowSmooth.smoothTime = smoothTime;
        }
    }
}
