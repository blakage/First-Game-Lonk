using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creature : MonoBehaviour
{
    [Header("Config")]
    public int healthPoints = 11;
    public float speed = 6.0f;
    public float jumpForce = 35f;
    public string creatureName = "Lonk";

    [Header("Projectiles")]
    public GameObject projectile;

    [Header("refrences")]
    SpriteRenderer sr;
    Rigidbody2D rb;
    AnimationStateChanger animationStateChanger;

    public SpriteRenderer spriteRenderer;

    bool isJumping;
    bool isAttacking = false;

    [Header("Audio")]
    private AudioSource soundEffect;



    void Awake()
    {
        Debug.Log("awake called");
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animationStateChanger = GetComponent<AnimationStateChanger>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Find the game object with the name "CoinAudio"
        GameObject playerHit = GameObject.Find("PlayerHitSound");
        if (playerHit != null)
        {
            soundEffect = playerHit.GetComponent<AudioSource>();
        }
    }


    public void Move(Vector3 direction)
    {
        //transform.position += direction * speed * Time.deltaTime;
        direction *= speed;
        direction.y+=rb.velocity.y;
        //rb.MovePosition(transform.position+(direction * Time.fixedDeltaTime));
        rb.velocity = direction; //if u want to push 
        

        if (direction.x > 0)
            spriteRenderer.flipX = false;
        else if (direction.x < 0)
            spriteRenderer.flipX = true;

        if(isAttacking){
            return;
        }
        
        if(direction == Vector3.zero){
            animationStateChanger.ChangeAnimationState("idle");
        }else{
            animationStateChanger.ChangeAnimationState("Walking",1);
        }
        
    }

    public void RandomizeColor()
    {
        sr.color = new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));
    }

    public void LaunchProjectile()
    {
        if(isAttacking){
            return;
        }
        isAttacking = true;
        animationStateChanger.ChangeAnimationState("Sword",5);
        Vector3 spawnPosition = transform.position + new Vector3(0f, 1f, 0f); // Adjust the y value as needed
        GameObject newProjectile = Instantiate(projectile, spawnPosition, Quaternion.identity);
        newProjectile.GetComponent<projectile>().LaunchProjectile(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        StartCoroutine(LaunchProjectileRoutine());
        IEnumerator LaunchProjectileRoutine(){
            yield return new WaitForSeconds(.3f);
            isAttacking = false;
            animationStateChanger.ChangeAnimationState("idle");
        }
    }

    public void Jump()
    {
        if(!isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
        // Add an upward force to the Rigidbody component
        //rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }   
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.otherCollider.GetType()==typeof(EdgeCollider2D)){
            Debug.Log("Collision!");
            isJumping = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        BossProjectile bossProjectile = other.GetComponent<BossProjectile>();
        if (bossProjectile != null)
        {
            // Handle the collision with the BossProjectile here
            // For example, reduce health, play sound, or perform any other action
            Debug.Log("Hit by BossProjectile!");
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
