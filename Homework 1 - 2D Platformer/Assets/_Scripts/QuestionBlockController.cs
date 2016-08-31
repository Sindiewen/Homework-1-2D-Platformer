/*
 * @author 	Rachel Vancleave
 * @date 	8/30/16
 * @class	CS/214 U
 * 
 * This script instantiates a certain ammount of coins untill
 * it is seemed "Empty"
 * 
 **/

using UnityEngine;
using System.Collections;

public class QuestionBlockController : MonoBehaviour 
{

	// Public Variables 
	public GameObject coin;		// Stores a reference to a coin GameObject

	public GameObject DisabledBlock;

	public int numOfCoins;		// Stores how many coins the block holds before it's deemed empty

	// Protected Variables
	protected GameObject clone;

	// Private Variables
	private Animator anim;

	private SpriteRenderer spriteR;



	void Start()
	{
		anim = GetComponent<Animator>();
		spriteR = GetComponent<SpriteRenderer>();

		anim.enabled = true;
		
	}


	public void spawnCoin()
	{

		// Function Variables
		float yPos = transform.position.y; 	// Stores Y corordinate of the blocks original location
		float xPos = transform.position.x;	// Stores X cororfinate of the blocks original location


		// If there are coins attached to this block that are spawnable
		if (numOfCoins > 0)
		{
			// Spawns a coin above the current block	
			clone = Instantiate(coin, new Vector2(xPos, yPos + 1), Quaternion.identity) as GameObject;
		
			// Decraments num of Coins down by 1
			numOfCoins--;

			// If the ammount of coins inside the block is == to 0
				// Turn the block's animation off, defaulting to the "disabled state"
			if (numOfCoins == 0)
			{
				spriteR.enabled = false;
				DisabledBlock.SetActive(true);
			}
		}

		// If theres no more coins attached to this block
			// Do nothing
		else 	
		{
			// Prints to the console...
			Debug.Log("No coin to spawn");

			// Ensures the nothing happens
			return;	// Do nothing

		}
	}

}
