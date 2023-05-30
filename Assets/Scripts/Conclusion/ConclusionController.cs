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
        string string_1 = "Trash Collected: " + playerData.coin_counter + " / " + playerData.total_coins;

        // Sentence 1
        StartCoroutine(TypeSentence(string_1));

        // Delay after typed
        yield return new WaitForSeconds(4f);

        string string_2 = "Think about how your actions in-game had an active effect of the environment!";

        // Sentence 1
        StartCoroutine(TypeSentence(string_2));

        // Delay after typed
        yield return new WaitForSeconds(5f);

        string string_3 = "Each decision you make in your life can have a small, but meaninful effect on the environment today!";

        // Sentence 1
        StartCoroutine(TypeSentence(string_3));

        // Delay after typed
        yield return new WaitForSeconds(7f);

        string string_4 = "Thank you for playing! - David, Jake, Lauren";

        // Sentence 1
        StartCoroutine(TypeSentence(string_4));

        // Delay after typed
        yield return new WaitForSeconds(6f);

        // Load the title screen
        SceneManager.LoadScene("Level");
    }

    // Coroutine for typing a string in the dialogue box
    IEnumerator TypeSentence(string sentence)
    {
        conclusion_text.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            conclusion_text.text += letter;
            yield return new WaitForSeconds(_typingDelay);
        }
    }
}
