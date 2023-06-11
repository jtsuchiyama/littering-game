using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public PlayerData playerData;

    private int coin_counter = 0;

    private void Update() {
        if (Input.GetKeyDown("space"))
            coin_counter = 9;
    }

    // Helper function for incrementing the internal coin counter
    public void IncrementCounter() {
        coin_counter++;
    }

    // Update the player data counter with the internal counter
    public void UpdateCounter() {
        playerData.coin_counter = coin_counter;
    }

    public int GetInternalCounter() { 
        return coin_counter;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        // If collide with coin
        if (col.gameObject.name.Contains("Coin"))
        {
            // Increment the coin counter
            IncrementCounter();

            // Call update function for the pollution filter
            FindObjectOfType<PollutionFilterController>().UpdateFilter(coin_counter);

            // If the player collects half the coins, then give them a period of invisibility
            if (coin_counter == playerData.total_coins / 2)
                StartCoroutine(FindObjectOfType<PlayerHealth>().IFrameLogic());

            // Destroy the coin
            Destroy(col.gameObject);
        }
    }
}
