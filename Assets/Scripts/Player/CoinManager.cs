using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public PlayerData playerData;

    private int coin_counter = 0;

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

            // Destroy the coin
            Destroy(col.gameObject);
        }
    }
}
