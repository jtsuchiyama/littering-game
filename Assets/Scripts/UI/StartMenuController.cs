using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuController : MonoBehaviour
{
	public bool CanPlayerMoveNow;

	public PlayerData playerData;

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
		CanPlayerMoveNow = FindObjectOfType<PlayerMovement>().CanPlayerMove;

		// Reset the death counter
		playerData.death_counter = 0;

		// Hide the start menu
		SetVisibility(false);
	}
}
