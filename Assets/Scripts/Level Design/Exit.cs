using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    // Scene change to conclusion
    void OnCollisionEnter2D(Collision2D col)
    {
        // Check for player collision
        if (col.gameObject.GetComponent<PlayerMovement>())
            SceneManager.LoadScene("Conclusion");
    }
}
