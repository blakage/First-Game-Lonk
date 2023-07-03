using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectControl : MonoBehaviour
{
    private Camera mainCamera;
    private ParticleSystem sandEffect;

    // Start is called before the first frame update
    void Start()
    {
        // Get references to the camera and SandEffect particle system
        mainCamera = Camera.main;
        sandEffect = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the position for the SandEffect particle system on the x-axis of the camera
        Vector3 screenPoint = new Vector3(Screen.width / 2f, mainCamera.WorldToScreenPoint(transform.position).y, mainCamera.nearClipPlane);
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(screenPoint);

        // Ignore changes in the y-axis of the camera
        worldPosition.y = transform.position.y;

        // Move the SandEffect to the calculated position
        sandEffect.transform.position = worldPosition;
    }
}
