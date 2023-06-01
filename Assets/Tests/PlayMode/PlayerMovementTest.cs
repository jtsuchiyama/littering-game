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

        var gameObject2 = new GameObject();
        var playMenu = gameObject2.AddComponent<StartMenuController>();
		
		//Start the game = make it so the player can move
		playMenu.StartGame();
		
        yield return null;

        Assert.AreEqual(expected: true, actual: playMenu.CanPlayerMoveNow);
    }
	
    [UnityTest]
    // Tests that the player can move right
    public IEnumerator PlayerMoveRightTest()
    {
        // Instantiate test objects
        var gameObject1 = new GameObject();
        gameObject1.AddComponent<Rigidbody2D>();
        var player = gameObject1.AddComponent<PlayerMovement>();
		player.SetGrounded(true);
		
		player.Start();
		
		//Move the player
        player.Move(1f, 0f);

        yield return new WaitForSeconds(0.5f);

        Assert.IsTrue(player.transform.position.x > 0);
		
    }
    [UnityTest]
    // Tests that the player can move left
    public IEnumerator PlayerMoveleft()
    {
        // Instantiate test objects
        var gameObject1 = new GameObject();
        gameObject1.AddComponent<Rigidbody2D>();
        var player = gameObject1.AddComponent<PlayerMovement>();
		
		player.SetGrounded(true);
		player.Start();

		//Move the player
        player.Move(-1f, 0f);

        yield return new WaitForSeconds(0.5f);

        Assert.IsTrue(player.transform.position.x < 0);
    }
    [UnityTest]
    // Tests that the player can jump
    public IEnumerator PlayerJump()
    {
        // Instantiate test objects
        var gameObject1 = new GameObject();
        gameObject1.AddComponent<Rigidbody2D>();
        var player = gameObject1.AddComponent<PlayerMovement>();
		
		player.SetGrounded(true);
		player.Start();
		
		//Move the player
        player.Move(0f, 1f);

        yield return new WaitForSeconds(0.1f);

        Assert.IsTrue(player.transform.position.y > 0);
    }
    [UnityTest]
    // Tests that the player cannot move downwards
    public IEnumerator PlayerMovedown()
    {
        // Instantiate test objects
        var gameObject1 = new GameObject();
        gameObject1.AddComponent<Rigidbody2D>();
        var player = gameObject1.AddComponent<PlayerMovement>();
		
		player.SetGrounded(true);
		player.Start();
		
		player.Move(0f, -1f);

        yield return new WaitForSeconds(0.1f);

        Assert.IsTrue(player.transform.position.y < 0);
    }
    [UnityTest]
    // Tests that the player flips left when moving left after moving right
    public IEnumerator PlayerFlipLeft()
    {
        // Instantiate test objects
        var gameObject1 = new GameObject();
        gameObject1.AddComponent<Rigidbody2D>();
        var player = gameObject1.AddComponent<PlayerMovement>();
		
		player.SetGrounded(true);
		player.Start();

		//Move the player to use the flip method
        player.Move(1f, 0f);
        player.Move(-1f, 0f);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(expected: false, actual: player._isFacingRight);
    }
    [UnityTest]
    // Tests that the player flips right when moving right after moving left
    public IEnumerator PlayerFlipRight()
    {
        // Instantiate test objects
        var gameObject1 = new GameObject();
        gameObject1.AddComponent<Rigidbody2D>();
        var player = gameObject1.AddComponent<PlayerMovement>();
		
		player.SetGrounded(true);
		player.Start();

		//Move the player to use the flip method
        player.Move(-1f, 0f);
        player.Move(1f, 0f);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(expected: true, actual: player._isFacingRight);
    }
    [UnityTest]
    // Tests that the player can move in air
    public IEnumerator PlayerMoveUpAndHorizontal()
    {
        // Instantiate test objects
        var gameObject1 = new GameObject();
        gameObject1.AddComponent<Rigidbody2D>();
        var player = gameObject1.AddComponent<PlayerMovement>();
		
		player.SetGrounded(true);
		player.Start();
		
		//Move the player
        player.Move(1f, 1f);

        yield return new WaitForSeconds(0.1f);
		
		//Checks that the player actually moved
        Assert.IsTrue(player.transform.position.y > 0);
		Assert.IsTrue(player.transform.position.x > 0);
    }
    [UnityTest]
    // Tests that the player cannot jump while already jumping
    public IEnumerator PlayerCannotDoubleJump()
    {
        // Instantiate test objects
        var gameObject1 = new GameObject();
        gameObject1.AddComponent<Rigidbody2D>();
        var player = gameObject1.AddComponent<PlayerMovement>();
		
		player.SetGrounded(true);
		player.Start();

        player.Move(0f, 1f);
        player.Move(0f, 1f);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(expected: false, actual: player._isGrounded);
    }
}