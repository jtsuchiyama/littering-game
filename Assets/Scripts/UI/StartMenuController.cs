using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuController : MonoBehaviour
{
	private void Start() {
		// Player cannot move while start menu is open
		FindObjectOfType<PlayerMovement>().CanPlayerMove = false;
	}

	// Toggles the visibility for all children of the dialogue box
	private void SetVisibility(bool value)
	{
		foreach (Transform child in transform)
			child.gameObject.SetActive(value);
	}

	// Function to start the game on button click
	public void StartGame() {
		// Allow player to move
		FindObjectOfType<PlayerMovement>().CanPlayerMove = true;

		// Hide the start menu
		SetVisibility(false);
	}
}
