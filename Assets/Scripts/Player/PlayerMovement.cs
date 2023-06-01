using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// For reference
	public Rigidbody2D _rb;

	// Player orientation boolean
	public bool _isFacingRight;

	// Player grounded boolean; ensures the player cannot jump if they are not grounded
	public bool _isGrounded;

	// Ground check variables
	[SerializeField] private Transform _groundCheck;
	const float _groundedRadius = .2f;
	[SerializeField] private LayerMask _groundMask;

	// Player movement multiplers
	private float horizontal_multiplier = 10f;
	private float horizontal_control_multiplier = 0.5f;
	private float vertical_multiplier = 400f;

	// Boolean to check if the player is allowed to move
	public bool CanPlayerMove;
	//public bool MovingRight;

    public void Start()
    {
		_rb = GetComponent<Rigidbody2D>();
    }

    // Handle all movement in FixedUpdate
    public void FixedUpdate()
    {
		if (CanPlayerMove) {
			// Check if the player is grounded
			GroundedCheck();

			// Get the keyboard inputs for directions
			float horizontalDirection = Input.GetAxis("Horizontal");
			float verticalDirection = Input.GetAxis("Vertical");

			// Move player
			Move(horizontalDirection, verticalDirection);
		}
    }
	

	// Move the player
	public void Move(float horizontalDirection, float verticalDirection) {
		// Mid-air horizontal control multiplier
		float mid_air_multiplier = 1;
		if (!_isGrounded)
			mid_air_multiplier = horizontal_control_multiplier;

		// Move horizontally
		_rb.velocity = new Vector2(horizontalDirection * horizontal_multiplier * mid_air_multiplier, _rb.velocity.y);

		// Move vertically
		if (_isGrounded) {
			// Add the vertical force
			_rb.AddForce(new Vector2(0f, verticalDirection * vertical_multiplier));

			// Update the grounded boolean
			_isGrounded = false;
		}
			

		// If the input is moving the player right and the player is facing left, then correct the character orientation
		if (horizontalDirection > 0 && !_isFacingRight)
		{
			Flip();
			//MovingRight = true;
		}

		// Otherwise if the input is moving the player left and the player is facing right, then correct the character orientation
		else if (horizontalDirection < 0 && _isFacingRight)
		{
			Flip();
			//MovingRight = false;
		}
	}
	
	
	public void SetGrounded(bool groundBool)
	{
		_isGrounded = groundBool;
	}
	

	// Flips the player sprite
	private void Flip()
	{
		// Switch the player orientation boolean
		_isFacingRight = !_isFacingRight;

		// Multiply the player's x local scale by -1 to flip player
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	// Checks if the player is grounded and updates the _isGrounded boolean appropriately
	public void GroundedCheck() {
		_isGrounded = false;

		// Check if the player is touching the ground
		Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, _groundedRadius, _groundMask);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				_isGrounded = true;
				break;
			}
		}
	}
}
