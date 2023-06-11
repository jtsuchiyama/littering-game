using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public PlayerData playerData;

    // Variables for handling the i-frames
    private float _iframeDuration = 10f;
    private bool _isIframe;
    private int _iframeCounter;
    private int _iframeToggle = 7;

    private SpriteRenderer sprite;

    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        // Check if the player is in i-frame or not
        if (_isIframe)
            IFrameSpriteToggle();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // If collide with spike and not in i-frame
        if (col.gameObject.name.Contains("Spike") && !_isIframe)
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

    // Handles sprite toggling logic when in i-frame
    private void IFrameSpriteToggle()
    {
        // Toggle the sprite if counter at the value
        if (_iframeCounter == _iframeToggle)
        {
            _iframeCounter = 0;

            // Toggle the sprite
            Color color = sprite.color;
            if (sprite.color.b == 0)
                sprite.color = new Color(1, 1, 1, 1);
            else
                sprite.color = new Color(1, 0.9f, 0, 1);
        }

        // Else, increment the counter
        else
            _iframeCounter++;
    }

    // Handles the duration of the i-frame
    public IEnumerator IFrameLogic() {
        // Set the player's i-frame state to true
        _isIframe = true;

        // I-frame duration
        yield return new WaitForSeconds(_iframeDuration);

        // Set the player's i-frame state to false
        _isIframe = false;

        // Restore sprite coloring
        Color color = sprite.color;
        sprite.color = new Color(1, 1, 1, 1);
    }
}
