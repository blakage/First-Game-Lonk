using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
   public GameObject projectile;
    public creature target;
    private GameObject creature; // Reference to the creature object

    [Header("Shooting control")]
    public float shootingDuration = 4f;
    public float shootingInterval = 0.5f;
    public float cooldownDuration = 3f;
    private bool isShooting = false;

    [Header("Following stuff")]
    public float followSpeed = 10f; // Speed at which the boss follows the creature
    public float damping = 0.5f; // Damping factor for the boss's movement
     public float offsetRange = 1.0f; // Maximum offset range for the boss's movement

    void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    private void Awake()
    {
        creature = GameObject.FindGameObjectWithTag("creature"); // Find the creature object based on its tag
    }

    private void Update()
    {
        FollowCreature(); // Follow the creature object on the x-axis
    }

    private void FollowCreature()
    {
       // Calculate the target position
        Vector3 targetPosition = new Vector3(creature.transform.position.x, transform.position.y, transform.position.z);

        // Apply random offset to the target position
        float randomOffset = Random.Range(-offsetRange, offsetRange);
        targetPosition += new Vector3(randomOffset, 0f, 0f);

        // Smoothly move the boss towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            // Wait for cooldown duration
            yield return new WaitForSeconds(cooldownDuration);

            // Start shooting at the target
            isShooting = true;
            StartCoroutine(ShootingDurationRoutine());

            // Wait for shooting duration
            yield return new WaitForSeconds(shootingDuration);

            // Stop shooting
            isShooting = false;
        }
    }

    IEnumerator ShootingDurationRoutine()
    {
        while (isShooting)
        {
            // Shoot projectile
            ShootProjectile();

            // Wait for the shooting interval
            yield return new WaitForSeconds(shootingInterval);
        }
    }

    void ShootProjectile()
    {
        if (target == null)
            return;

        Vector3 targetPosition = target.transform.position;
        Vector3 spawnPosition = transform.position + new Vector3(0f, 0f, 0f); // Adjust the spawn position as needed
        GameObject newProjectile = Instantiate(projectile, spawnPosition, Quaternion.identity);
        newProjectile.GetComponent<BossProjectile>().LaunchProjectile(targetPosition);
    }
}
