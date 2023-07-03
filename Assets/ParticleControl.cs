using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    private Camera mainCamera;
    private ParticleSystem SandStorm;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        SandStorm = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the position for the SandStorm effect on the x-axis of the camera
        Vector3 screenPoint = new Vector3(Screen.width, mainCamera.WorldToScreenPoint(transform.position).y, mainCamera.nearClipPlane);
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(screenPoint);

        // Ignore changes in the y-axis of the camera
        worldPosition.y = transform.position.y;

        // Move the SandStorm to the calculated position
        SandStorm.transform.position = worldPosition;
    }
}
