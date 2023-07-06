using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScoreIcon : MonoBehaviour
{
    private static GameObject[] coins;
    private static Color opaqueColor = new Color(1f, 1f, 1f, 1f);
    private static Color clearColor = new Color(1f, 1f, 1f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        InitializeCoins();
        ClearAllCoins();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCoinVisibility();
    }

    private void InitializeCoins()
    {
        coins = new GameObject[4];
        for (int i = 0; i < coins.Length; i++)
        {
            coins[i] = GameObject.Find("coin" + (i + 1));
            if (coins[i] == null)
            {
                Debug.LogError("Coin " + (i + 1) + " not found in the scene.");
            }
        }
    }

    private void ClearAllCoins()
    {
        foreach (GameObject coin in coins)
        {
            if (coin != null)
            {
                SpriteRenderer spriteRenderer = coin.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = clearColor;
                }
            }
        }
    }

    public static void UpdateCoinVisibility()
    {
        for (int i = 0; i < coins.Length; i++)
        {
            if (coins[i] != null)
            {
                SpriteRenderer spriteRenderer = coins[i].GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = Coin.score >= i + 1 ? opaqueColor : clearColor;
                }
            }
        }
    }
}
