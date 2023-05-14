using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        // If collide with spike
        if (col.gameObject.name.Contains("Spike"))
        {
            SceneManager.LoadScene("Level");
        }
    }
}
