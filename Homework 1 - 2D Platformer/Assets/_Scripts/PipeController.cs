/*
 * @author 	Rachel Vancleave
 * @date 	8/31/16
 * @class	CS/214 U
 * 
 *
 * This Script allows the player to teleport to a new location when interacting with a seleced Teleport
 * Warp Pipe.
 * 
 * If player is stanring on an upward facing pipe, it will move the player downward into the pipe
 * and teleport them to the set Destination transform object.
 * 
 * If the Pipe is inverted, downward facing, when the player jumps into the pipe trigger, it will promptly move
 * the player upward into the pipe and teleport them into the destination pipe
 * 
 **/

using UnityEngine;
using System.Collections;

public class PipeController : MonoBehaviour 
{

	// Public Variables
	public Transform destLocation;			// Stores the Destination location
	public Transform Player;				// Stores Reference to the player GameObject

	public GameObject PipeCollider;			// Stores reference to the BoxCollider2D Component

	public bool portOnCollide 			= false;	// If the player will teleport when colliding with the pipe trigger

	// Private Variables
	private bool IsPlayerStandingOn 	= false;	// If the player is standing on the pipe


	void Start()
	{
		// Gets and stored the BoxCOllider2D Component 
		//PipeCollider = GetComponent<BoxCollider2D>();
	}

	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.gameObject.CompareTag("Player"))
		{
			// If player is standing on the GameObjects Trigger
			IsPlayerStandingOn = true;

			// If PortOnCollide is true
			// Immediately teleport player to the destination
			// (Generally use this for downward facing pipes
			if(portOnCollide)
			{
				// Starts InvertedPlayerTeleport coroutine
				StartCoroutine(invertedPlayerTeleport());
			}
		}


	}

	// If player exits the GameObjects trigger
	void OnTriggerExit2D (Collider2D col)
	{
		// Player is not standing on the pipe
		IsPlayerStandingOn = false;
	}

	// Is called every Frame
	void Update()
	{
		// If the player presses 'down' or 's' on the keyboard,
		if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
		{
			// If the player is standing on the pipe itself,
			if(IsPlayerStandingOn)
			{
				// Starts teleport coroutine
					// Moves player downward and teleports them promptly
				StartCoroutine(PlayerTeleport());
			}

		}
	}
		
	// Coroutine function -- Allows the function to wait inside the function call
	// Teleports player to the destination GameObject
		// Stores players current position
		// moves them downwards into the pipe
		// Teleports them to the destination pipe
	IEnumerator PlayerTeleport()
	{
		// Function Variables
		//float yPos = transform.position.y; 	// Stores Y corordinate of the blocks original location
		//float xPos = transform.position.x;	// Stores X cororfinate of the blocks original location

		// Disables the collider object so the player can pass through the object
		PipeCollider.SetActive(false);

		// Moves the player downward by current position - 20 on the Y axis
		//this.transform.position = new Vector2(xPos, yPos - 20f);

		// Waits a fraction of a second before the next statement gets called
		yield return new WaitForSeconds(0.5f);

		// Re-enables the collider object
		PipeCollider.SetActive(true);

		// Teleports the player
		Player.transform.position = destLocation.transform.position;


	}


	IEnumerator invertedPlayerTeleport()
	{
		// Function Variables
		//float yPos = transform.position.y; 	// Stores Y corordinate of the blocks original location
		//float xPos = transform.position.x;	// Stores X cororfinate of the blocks original location

		// Disables the collider object so the player can pass through the object
		PipeCollider.SetActive(false);

		// Moves the player downward by current position - 20 on the Y axis
		//this.transform.position = new Vector2(xPos, yPos + 20f);

		// Waits a fraction of a second before the next statement gets called
		yield return new WaitForSeconds(0.5f);

		// Re-enables the collider Object
		PipeCollider.SetActive(true);

		// Teleports the player
		Player.transform.position = destLocation.transform.position;




	}

}


