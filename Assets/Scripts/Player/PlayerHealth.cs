using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public PlayerData playerData;

    private void OnTriggerEnter2D(Collider2D col)
    {
        // If collide with spike
        if (col.gameObject.name.Contains("Spike"))
        {
            Restart();
        }
    }

    // Function that handles player death
    public void Restart() {
        // Increment death counter
        playerData.death_counter++;

        // Restart the scene
        SceneManager.LoadScene("Level");
    }
}
