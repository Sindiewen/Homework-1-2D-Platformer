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

public class BrickController : QuestionBlockController 
{
	// Public Variables

	public bool canSpawnCoin = true;		// Stores check to see if an object can spawn a coin


	// If the player successfully collides, and hatted the block
	void OnCollisionEnter2D(Collision2D col)
	{

		// If the block has successfully been "hatted" by the player
		// Will allow block to move up by a fraction of the transform
		if (col.gameObject.CompareTag("Player"))
		{

			Debug.Log("collide");
			// Calls the block wiggle function to wiggle the box as a coroutine
			// This allows the function to wait a certain time before a statement executes
			StartCoroutine(blockWiggle());
		}
	}


	// Coroutine function -- Allows the function to wait inside the function call
	IEnumerator blockWiggle()
	{
		// Function Variables
		float yPos = transform.position.y; 	// Stores Y corordinate of the blocks original location
		float xPos = transform.position.x;	// Stores X cororfinate of the blocks original location



		// If the block can spawn a coin and it's current value is greater than 0
			// Move the block up a fraction of a unity
			// Spawn a coin in that location
			// Wait a fraction of a realtime second
			// Sets the coin's clone to false
			// Moves the block to it's original location
		if (canSpawnCoin && numOfCoins > 0)
		{

			// Moves block up a fraction of a Unity unit
			this.transform.position = new Vector2(xPos, yPos + 0.2f);

			// Spawns a coin above the block
			spawnCoin();

			// Waits a fraction of a second before the next statement gets called
			yield return new WaitForSeconds(0.08f);

			// Disables cloned coin object
			clone.SetActive(false);

			// Returns the box to it's original location
			this.transform.position = new Vector2(xPos, yPos);

		}


	}


}
