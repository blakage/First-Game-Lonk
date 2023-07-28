using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartControl : MonoBehaviour
{
    public static GameObject[] hearts; // An array to hold references to the heart GameObjects
    private Color clearColor = new Color(1f, 1f, 1f, 0f); // The fully clear (transparent) color of the hearts

    void Start()
    {
        // Initialize the heartRenderers list with the SpriteRenderers of the hearts
        hearts = new GameObject[4];
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = GameObject.Find("Heart" + (i + 1));
            if (hearts[i] == null)
            {
                Debug.LogError("Heart " + (i + 1) + " not found in the scene.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Call this function to update the heart opacities based on the creature's health
    public static void UpdateHeartOpacities(int health)
    {
       // Loop through the heart GameObjects to update their opacity
        for (int i = 0; i < hearts.Length; i++)
        {
            // Calculate the target opacity based on the player's health
            float targetOpacity = (health > i) ? 1f : 0f;
            // Update the opacity of the heart
            SpriteRenderer spriteRenderer = hearts[i].GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                Color heartColor = spriteRenderer.color;
                heartColor.a = targetOpacity;
                spriteRenderer.color = heartColor;
            }
        }
    }
}
