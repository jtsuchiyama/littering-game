using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConclusionController : MonoBehaviour
{
    // Typing delay for text box
    private float _typingDelay = 0.03f;

    public PlayerData playerData;

    public Text conclusion_text;

    void Start() {
        StartCoroutine(RunCutscene());
    }

    // Runs cutscene with delay
    private IEnumerator RunCutscene() {
        // Calculate the percentage of trash collected
        float trash_percentage = (float)playerData.coin_counter / (float)playerData.total_coins;

        string string_1 = "Trash Collected: " + playerData.coin_counter + " / " + playerData.total_coins;

        // Sentence 1
        StartCoroutine(TypeSentence(string_1, Color.black));

        // Delay after typed
        yield return new WaitForSeconds(4f);

        // Checking for which ending the player gets
        if (trash_percentage < 0.33f)
        {
            string string_2bad = "You might not have noticed, but your actions in game had an active effect on the environment...";
            StartCoroutine(TypeSentence(string_2bad, Color.red));

            // Delay after typed
            yield return new WaitForSeconds(7f);
        }

        else if (trash_percentage < 0.66f)
        {
            string string_2neutral = "Good job! You have begun to notice how your actions in-game had an active effect on the environment.";
            StartCoroutine(TypeSentence(string_2neutral, Color.black));

            // Delay after typed
            yield return new WaitForSeconds(7f);
        }

        else {
            string string_2good = "Amazing job! You understand how your actions in-game had an active effect of the environment!";
            StartCoroutine(TypeSentence(string_2good, Color.green));

            // Delay after typed
            yield return new WaitForSeconds(7f);
        }

        string string_3 = "Similarly, each small decision you make in your life can have a small, but meaninful effect on the environment today!";

        // Sentence 3
        StartCoroutine(TypeSentence(string_3, Color.black));

        // Delay after typed
        yield return new WaitForSeconds(7f);

        string string_4 = "Continue to replay the game to explore the different ways you can impact the environment!";

        // Sentence 4
        StartCoroutine(TypeSentence(string_4, Color.black));

        // Delay after typed
        yield return new WaitForSeconds(5f);

        string string_5 = "Thank you for playing! - David, Jake, Lauren";

        // Sentence 5
        StartCoroutine(TypeSentence(string_5, Color.black));

        // Delay after typed
        yield return new WaitForSeconds(6f);

        // Load the title screen
        SceneManager.LoadScene("Level");
    }

    // Coroutine for typing a string in the dialogue box
    IEnumerator TypeSentence(string sentence, Color color)
    {
        conclusion_text.text = "";
        conclusion_text.color = color;
        foreach (char letter in sentence.ToCharArray())
        {
            conclusion_text.text += letter;
            yield return new WaitForSeconds(_typingDelay);
        }
    }
}
