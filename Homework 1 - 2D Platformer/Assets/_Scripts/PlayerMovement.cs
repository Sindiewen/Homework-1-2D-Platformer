/*
 * @author 	Rachel Vancleave
 * @date 	8/30/16
 * @class	CS/214 U
 * 
 * This script is used for player movement on a 2D plane.
 * Moves the player on the X and Y axis.
 * 
 * This uses the Unity Input manager:
 * 	- Pressing left takes the player's velocity and moves it negativley
 * 	- Pressing right takes the player's velocity and moves it positivley
 * 
 * 
 * This flips the sprite on the X axis when moving left and right
 * 
 **/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{

	// Public Variables -- Viewable and Editable in the Inspector

	// Public variables that are hidden in the inspector
	[HideInInspector] public bool facingRight 	= true;		// Is the player facing right?
	[HideInInspector] public bool jump			= false;	// if spacebar has been pressed


	public float speed		= 0;
	public float jumpForce	= 1000f;	// How much force the player will be moved upwards

	public Transform groundCheck;		// Uses the transform (just below the player) to check if the player is grounded


	// Private variables -- 

	private bool grounded = false; 		// Stores if the player is currently on the ground

	private Animator anim;				// Stores component reference to the Animator component

	private Rigidbody2D rb2D;			// Stores component reference to the Rigidbody2D component

	private float moveVelocity = 0f;			// Stores the players current movement Velocity


	// When the game initally starts, this function will be called
	void Awake()
	{
		anim = GetComponent<Animator>();	// Stores component reference to the Animator component
		rb2D = GetComponent<Rigidbody2D>();	// Stores component reference to the Rigidbody2D Component 
	}

	// Calls every frame
	void Update()
	{	
		// Raycast/Linecast returns a bool.
			// Checks if player is currently on the ground.
			// From transform.position, to groundCheck.position, Raycasts and checks if they're colliding
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));


		// If the player is grounded and the jump button has been pressed...
		if (Input.GetButtonDown("Jump") && grounded)
		{
			// The player is jumping, set to true
			jump = true;
		}
	}
		


	// Do ALL Physics Code in Fixed Update
	// Physics loop
	void FixedUpdate()
	{

		// Player Movement left and Right
		// Unity Input Manager: 
			// Horizontal Movement: Left  - 'a', "Left Arrow", "left" 
			// Horizontal Movement: Right - 'd', "Right Arrow", "Right"
		if (Input.GetKey("left") || Input.GetKey("a"))
		{
			// Animates the player's sprite to a walking animation
			anim.SetFloat("Speed", 1.5f);	

			if (facingRight)
			{
				flip();
			}

			// Player is not facing right
			facingRight = false;

			// Move player
			moveVelocity = -speed;
		}
		if (Input.GetKey("right") || Input.GetKey("d"))
		{
			// Animates the player's sprite to a walking animation
			anim.SetFloat("Speed", 1.5f);

			if (!facingRight)
			{
				flip();
			}

			// Player is now facing right
			facingRight = true;

			// Move player
			moveVelocity = speed;
		}





		// If the player either presses left or right
			// Stops player in their current position
			// Stops their run animation
		if(Input.GetKeyUp("left") || Input.GetKeyUp("right"))
		{
			// Stops player where they're currently standing
			//moveVelocity = 0f;

			// Sets animation state to idle
			anim.SetFloat("Speed", 0f);

		}


		// Moves player either Left or Right depending on movement velocity
			// Player falling velocity is what the rigid body currently is
		rb2D.velocity = new Vector2 (moveVelocity, rb2D.velocity.y);



		moveVelocity = 0f;
		//anim.SetFloat("Speed", 0f);


		// If the user jumps (jump == true)
		// Set burst of force moving upwards
		if (jump)
		{
			// Plays the jump animation
			anim.SetTrigger("Jump");

			// Moves the player velocity upwards by Jump force
			rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);

			// Sets jump to false, ensures the player cannot double jump.
			jump = false;
		}

	}
		


	// Flips the sprite around if player moves left or right
	private void flip()
	{
		// Player is not facing right
		facingRight = !facingRight;

		// Stores the player's local scale
		Vector3 theScale = transform.localScale;

		// Multiplys the player's scale (the x axis of the sprite) by -1 thus flipping it
		// Negative * Positive == Negative
		// Negative * Negative == Positive
		theScale.x *= -1;

		// Flips the sprite by multiplying
		transform.localScale = theScale; 
	}



		




}