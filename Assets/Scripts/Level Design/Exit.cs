using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private Vector3 _startingPosition;

    void Start() {
        // Note the starting position for movement effect of arrow
        _startingPosition = transform.position;
    }

    // Update function to move the arrow left and right
    void Update()
    {
        if (transform.rotation.z == 0 || transform.rotation.z == 180)
            transform.position = _startingPosition + (Vector3.right * (Mathf.Cos(Time.time * 5f) * 0.1f));
        else
            transform.position = _startingPosition + (Vector3.up * (Mathf.Cos(Time.time * 5f) * 0.1f));
    }

    // Scene change to conclusion
    void OnCollisionEnter2D(Collision2D col)
    {
        // Check for player collision
        if (col.gameObject.GetComponent<PlayerMovement>())
            LoadConclusion();
    }

    public void LoadConclusion() {
        // Update player's coin counter once they finished the game
        FindObjectOfType<CoinManager>().UpdateCounter();

        // Load new scene
        SceneManager.LoadScene("Conclusion");
    }
}
