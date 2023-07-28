using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
   public GameObject projectile;
    public creature target;
    private GameObject creature; // Reference to the creature object
    public int bossHealthPoints = 10;

    [Header("Shooting control")]
    public float shootingDuration = 4f;
    public float shootingInterval = 0.5f;
    public float cooldownDuration = 3f;
    private bool isShooting = false;

    [Header("Following stuff")]
    public float followSpeed = 10f; // Speed at which the boss follows the creature
    public float damping = 0.5f; // Damping factor for the boss's movement
     public float offsetRange = 1.0f; // Maximum offset range for the boss's movement

     [Header("refrences")]
      SpriteRenderer sr;
      public SpriteRenderer spriteRenderer;

     [Header("Audio")]
    private AudioSource soundEffect;

    void Start()
    {
        StartCoroutine(ShootRoutine());
         // Find the game object with the name "CoinAudio"
        GameObject bossAudio = GameObject.Find("BossHit");
        if (bossAudio != null)
        {
            soundEffect = bossAudio.GetComponent<AudioSource>();
        }
    }

    private void Awake()
    {
        creature = GameObject.FindGameObjectWithTag("creature"); // Find the creature object based on its tag
        sr = GetComponent<SpriteRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(creature != null){
            FollowCreature(); // Follow the creature object on the x-axis
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        projectile playerProjectile = other.GetComponent<projectile>();
        if (playerProjectile != null)
        {
            // Handle the collision with the BossProjectile here
            // For example, reduce health, play sound, or perform any other action
            Debug.Log("Hit by PlayerProjectile!");
            bossHealthPoints--;
            PlaySoundEffect();
            StartCoroutine(ChangeColorCoroutine());

        }
    }

    private IEnumerator ChangeColorCoroutine()
    {
            // Store the original color
        Color originalColor = Color.white;

        // Change the color to red
        sr.color = Color.red;

        // Transition back to the original color over time
        float elapsedTime = 0f;
        float transitionDuration = 0.5f; // Adjust the duration as needed

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            sr.color = Color.Lerp(Color.red, originalColor, elapsedTime / transitionDuration);
            yield return null;
        }

        // Ensure the color is set to the original color
        sr.color = originalColor;
    }

    void PlaySoundEffect()
    {
        soundEffect.Play(); // Play the sound effect
    }
}
