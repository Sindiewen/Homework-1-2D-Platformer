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

	public int numOfCoins;		// Stores how many coins the block holds before it's deemed empty


	public void spawnCoin()
	{

		// Function Variables
		float yPos = transform.position.y; 	// Stores Y corordinate of the blocks original location
		float xPos = transform.position.x;	// Stores X cororfinate of the blocks original location


		// If there are coins attached to this block that are spawnable
		if (numOfCoins > 0)
		{
		// Spawns a coin above the current block	
		Instantiate(coin, new Vector2(xPos, yPos + 1), Quaternion.identity);
		
		// Decraments num of Coins down by 1
		numOfCoins--;
		}
		else 	// If theres no more coins attached to this block
		{
			Debug.Log("No coin to spawn");
			return;	// Do nothing
		}

		//yield return new WaitForSeconds(0.4f);
	}

}
