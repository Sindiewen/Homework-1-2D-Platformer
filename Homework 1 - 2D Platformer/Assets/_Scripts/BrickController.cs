/*
 * @author 	Rachel Vancleave
 * @date 	8/30/16
 * @class	CS/214 U
 * 
 * This script allows the blocks connect to it to move up and simulate a 
 * wiggle to indicate you've interacted with the block.
 * 
 * Uses a coroutine to allow the function to wait a certain ammount of time before
 * the next line gets called.
 * 
 **/


using UnityEngine;
using System.Collections;

public class BrickController : MonoBehaviour 
{

	public Transform hatCheck;		// Stores a reference to the HatCHeck gameobject

	public bool hatted = false;	// Stores a bool to check if the player "Hats" the block"

	void Update()
	{
		// Raycast checks to see if the player "Hatted" the block
		hatted = Physics2D.Linecast(transform.position, hatCheck.position , 1 << LayerMask.NameToLayer("Ground"));
	}



	void OnCollisionEnter2D(Collision2D col)
	{

		// If the block has successfully been "hatted" by the player
		// Will allow block to move up by a fraction of the transform
		if (hatted == true)
		{
			// Calls the block wiggle function to wiggle the box as a coroutine
			// This allows the function to wait a certain time before a statement executes
			StartCoroutine(blockWiggle());

			// Ensures the coroutine will not run contiuously
			hatted = false;
		}


	}



	// Coroutine function -- Allows the function to wait inside the function call
	IEnumerator blockWiggle()
	{
		// Function Variables
		float yPos = transform.position.y; 	// Stores Y corordinate of the blocks original location
		float xPos = transform.position.x;	// Stores X cororfinate of the blocks original location

		// Moves block up a fraction of a Unity unit
		this.transform.position = new Vector2(xPos, yPos + 0.2f);

		// Waits a fraction of a second before the next statement gets called
		yield return new WaitForSeconds(0.08f);

		// Returns the box to it's original location
		this.transform.position = new Vector2(xPos, yPos);
	}


}
