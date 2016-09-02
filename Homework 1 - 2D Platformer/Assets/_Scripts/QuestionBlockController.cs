/*
 * @author 	Rachel Vancleave
 * @date 	8/30/16
 * @class	CS/214 U
 * 
 * This script instantiates a certain ammount of coins untill
 * it is deemed "Empty"
 * 
 * When the numOfCoins is 0, It will disable the blocks sprite renderer and
 * enables the "disabled block" object so the player is unable to interact with the block
 * 
 **/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestionBlockController : MonoBehaviour 
{

	// Public Variables 
	public GameObject coin;				// Stores a reference to a coin GameObject
	public GameObject DisabledBlock;	// Stores a reference to the disabled block of this object

	public int numOfCoins;				// Stores how many coins the block holds before it's deemed empty

	public bool canSpawnCoin;			// Stores check to see if the block can spawn a coin

	public PlayerMovement movement;		// Stores a reference to the player movement script

	//public float coinJumpForce;			// Stores a float value to the coin jump force

	// Private Variables			

	private GameObject clone;			// Stores reference to the cloned object		
	 
	private SpriteRenderer spriteR;		// Stores reference to the Sprite Renderer component


	// Gets called at the start of the scene
	void Start()
	{
		spriteR = 	GetComponent<SpriteRenderer>();		// Gets the sprite renderer component
		coin = GetComponent<GameObject>();
	}
		

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
			Debug.Log("Wiggling block");

			// Moves block up a fraction of a Unity unit
			this.transform.position = new Vector2(xPos, yPos + 0.2f);


			// Spawns a coin above the block
			spawnCoin();

			// Calls the movement variables script to call the setCoinText() function
			movement.setCoinText();

			// Waits a fraction of a second before the next statement gets called
			yield return new WaitForSeconds(0.08f);

			// Destroyes cloned coin object
			DestroyObject(clone);

			// Returns the box to it's original location
			this.transform.position = new Vector2(xPos, yPos);

		}


	}






	// Spawns a coin above the box gameObject and wiggles box signifying the user
	// collided with it.
	void spawnCoin()
	{

		// Function Variables
		float yPos = transform.position.y; 	// Stores Y corordinate of the blocks original location
		float xPos = transform.position.x;	// Stores X cororfinate of the blocks original location
	
		Vector3 startPos = clone.transform.position;

		clone = (GameObject)Instantiate(coin, startPos, Quaternion.identity) as GameObject;
		clone.rigidbody2D; // = transform.GetComponent<rigidbody2D>().velocity;


		/*
		// forward firing start location

		Vector3 start = transform.position;
		start += transform.forward.normalized * 10;

		if (weapons[0] == Arsenal.Spin)
		{
			GameObject obj = (GameObject)Instantiate(Prefab[0], start, transform.rotation);
			obj.rigidbody.velocity = transform.rigidbody.velocity;
		}
		 
		 * */

		// If there are coins attached to this block that are spawnable
		if (numOfCoins > 0)
		{
			Debug.Log("Spawning Coin");
			// Spawns a coin above the current block	
			clone = Instantiate(coin, new Vector2(xPos, yPos + 1), Quaternion.identity) as GameObject;

			// Decraments num of Coins down by 1
			numOfCoins--;


			// If the ammount of coins inside the block is == to 0
				// Turns off the current game object's sprite renderer
				// Enables the "Disabled Block" object
			if (numOfCoins == 0)
			{
				// Disables the attached sprite renderer
				spriteR.enabled = false;

				// Enables the gameObject to take place as the "Disabled block"
				DisabledBlock.SetActive(true);
			}
		}
	}


}
