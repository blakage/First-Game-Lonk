using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAlter : MonoBehaviour
{
    public float normalCamera = 7.3f;
    public float smoothTime;
    public float linDrag;
    public float angDrag;
    void OnTriggerEnter2D(Collider2D other)
    {
        creature creature = other.GetComponent<creature>();
        if (creature != null)
        {
            Rigidbody2D creatureRigidbody = creature.GetComponent<Rigidbody2D>();
            if (creatureRigidbody != null)
            {
                creatureRigidbody.angularDrag = angDrag;
                creatureRigidbody.drag = linDrag;

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
