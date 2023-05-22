using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	// Queue to hold all the dialogue senteces that need to be played
    private Queue<string> _sentences;

	// Public reference for text objects in dialogue box
	public Text speakerText;
	public Text dialogueText;

	// Typing delay for text box
	private float _typingDelay = 0.02f;

	// Boolean to check if in dialogue or not
	private bool _inDialogue;

	// Public reference for dialogue
	public Dialogue startDialogue;
    private void Start()
    {
		// Clear all dialogues
		EndDialogue();

		// Instantiate the queue
		_sentences = new Queue<string>();

		// Run dialogue immediately at scene start
		StartDialogue(startDialogue);
    }


	// Check to continue dialogue
	private void Update() {
		if (_inDialogue && Input.GetKeyDown(KeyCode.Space)) {
			DisplayNextSentence();
		}
	}

	// Loads the dialogue into the queue and starts the dialogue
	public void StartDialogue(Dialogue dialogue)
	{
		_inDialogue = true;

		SetVisibility(true);

		speakerText.text = dialogue.speaker;

		_sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			_sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	// Displays the next sentence in the dialogue box
	public void DisplayNextSentence()
	{
		if (_sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = _sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	// Coroutine for typing a string in the dialogue box
	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return new WaitForSeconds(_typingDelay);
		}
	}

	// Toggles the visibility for all children of the dialogue box
	private void SetVisibility(bool value)
	{
		foreach (Transform child in transform)
			child.gameObject.SetActive(value);
	}

	// Function for all procedures that occur when dialogue is stopped
	void EndDialogue()
	{
		_inDialogue = false;

		SetVisibility(false);
	}
}