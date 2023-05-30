using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementTest
{
	[UnityTest]
    // Tests that the play can move in game
    public IEnumerator PlayerCanMove()
    {
        // Instantiate test objects
        var gameObject1 = new GameObject();
        var playerMovement = gameObject1.AddComponent<PlayerMovement>();

        yield return null;

        Assert.AreEqual(expected: true, actual: playerMovement.CanPlayerMove);
    }
	
    [UnityTest]
    // Tests that the player can move right
    public IEnumerator PlayerMoveRightTest()
    {
        // Instantiate test objects
        var gameObject1 = new GameObject();
        var playerMovement = gameObject1.AddComponent<PlayerMovement>();
		
		playerMovement.SetGrounded(true);
		
		//Move the player
        playerMovement.Move(1f, 0f);

        yield return new WaitForSeconds(0.5f);

        Assert.AreEqual(new Vector2(5, 0), playerMovement.transform.position);
		
    }
    [UnityTest]
    // Tests that the player can move left
    public IEnumerator PlayerMoveleft()
    {
        // Instantiate test objects
        var gameObject1 = new GameObject();
        var playerMovement = gameObject1.AddComponent<PlayerMovement>();

        playerMovement.SetGrounded(true);

		//Move the player
        playerMovement.Move(-1f, 0f);

        yield return new WaitForSeconds(0.5f);

        Assert.AreEqual(expected: true, actual: playerMovement.MovingLeft());
    }
    [UnityTest]
    // Tests that the player can jump
    public IEnumerator PlayerJump()
    {
        // Instantiate test objects
        var gameObject1 = new GameObject();
        var playerMovement = gameObject1.AddComponent<PlayerMovement>();
		
		playerMovement.SetGrounded(true);
		
		//Move the player
        playerMovement.Move(0f, 1f);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(expected: true, actual: playerMovement.MovingUp());
    }
    [UnityTest]
    // Tests that the player cannot move downwards
    public IEnumerator PlayerMovedown()
    {
        // Instantiate test objects
        var gameObject1 = new GameObject();
        var playerMovement = gameObject1.AddComponent<PlayerMovement>();

		//Move the player
        playerMovement.Move(1f, -1f);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(expected: true, actual: playerMovement.NotMovingDown());
    }
    [UnityTest]
    // Tests that the player flips left when moving left after moving right
    public IEnumerator PlayerFlipLeft()
    {
        // Instantiate test objects
        var gameObject1 = new GameObject();
        var playerMovement = gameObject1.AddComponent<PlayerMovement>();

		//Move the player to use the flip method
        playerMovement.Move(1f, 0f);
        playerMovement.Move(-1f, 0f);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(expected: false, actual: playerMovement._isFacingRight);
    }
    [UnityTest]
    // Tests that the player flips right when moving right after moving left
    public IEnumerator PlayerFlipRight()
    {
        // Instantiate test objects
        var gameObject1 = new GameObject();
        var playerMovement = gameObject1.AddComponent<PlayerMovement>();

		//Move the player to use the flip method
        playerMovement.Move(-1f, 0f);
        playerMovement.Move(1f, 0f);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(expected: true, actual: playerMovement._isFacingRight);
    }
    [UnityTest]
    // Tests that the player is grounded
    public IEnumerator PlayerGrounded()
    {
        // Instantiate test objects
        var gameObject1 = new GameObject();
		gameObject1.AddComponent<BoxCollider>();
        var playerMovement = gameObject1.AddComponent<PlayerMovement>();
		
		var groundObject = new GameObject();
		groundObject.AddComponent<BoxCollider>();
		
		
		//Use the method to check if the player is on the ground
        playerMovement.GroundedCheck();

        yield return null;

        Assert.AreEqual(expected: true, actual: playerMovement._isGrounded);
    }
    [UnityTest]
    // Tests that the player cannot jump while already jumping
    public IEnumerator PlayerCannotDoubleJump()
    {
        // Instantiate test objects
        var gameObject1 = new GameObject();
        var playerMovement = gameObject1.AddComponent<PlayerMovement>();

        playerMovement.Move(0f, 1f);
        playerMovement.Move(0f, 1f);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(expected: false, actual: playerMovement._isGrounded);
    }
}