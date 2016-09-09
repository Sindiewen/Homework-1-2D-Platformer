/*
 * @author 	Rachel Vancleave
 * @date 	9/1/16
 * @class	CS/214 U
 * 
 * This script contols the piranha plants in the game scene.
 * 
 * When the player enters the trigger radius, the plant will rise out of the pipe,
 * wait there for a user selectd amount of time, and go back into the pipe.
 * 
 * If the player touches the plant as it's outside the pipe, the player will
 * lose all their coins.
 **/

using UnityEngine;
using System.Collections;

public class PiranhaPlantController : MonoBehaviour 
{

	// Public Variables
	//public GameObject player;		// Stores reference to the player GameObject

	public float pauseTime = 1.0f;	// Sets how long the plant should pause before doing anything else
	public float riseHeight;		// Sets how high the plant will rise 

	public GameObject plantSuspendTrigger;

	// Private Variables

	private float origX;			// Stores the original position of the plant X
	private float origY;			// Stores the original position of the plant Y

	private CircleCollider2D circleCol;				// Stores refrerence to the CircleCollider2D

	// Starts at the first frame of the game
	void Start()
	{
		circleCol = gameObject.GetComponent<CircleCollider2D>();	// Gets the circle collider2D Component

		//plantSuspend = false; 			// The plant is not suspended

		origX = transform.position.x;	// Stores the original position of the plant X
		origY = transform.position.y;	// Stores the original position of the plant Y
	}

	// When the player enters the trigger
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			
			// Disables the circle collider 2D component
			circleCol.radius = 0.2f;
		
			// Changes the offset of the collider box
			circleCol.offset = new Vector2(0, -20);

			// Starts coroutine to collide and interact with the player
			StartCoroutine(riseFromPipe());
		}


	}


	// The plant rises from the pipe
		// Uses a coroutine to specify how long the plant will rise out of the pipe too attack the player
	IEnumerator riseFromPipe()
	{
		// Function Variables
		float yPos = transform.position.y;	// Stores y corordinate of Plant's original position
		float xPos = transform.position.x;	// Stores x corordinate of Plant's original position

		Vector2 newPos = new Vector2(xPos, yPos + riseHeight);

		float lerpTime = 0.0f;

		// Wait a certain ammount of time before the next statement gets called
		yield return new WaitForSeconds(pauseTime * 0.5f);

		// Disables the trigger to suspend the plant
		plantSuspendTrigger.SetActive(false);

		//Moves plant upwards
		//this.transform.position = new Vector2 (xPos, yPos + riseHeight);
		Vector2.Lerp(transform.position, newPos, lerpTime);
			// v =  time.deltatime * rate (time/distance)
			// float rateD = 1.0f / t

		// Wait a certain ammount of time before the next statement gets called
		yield return new WaitForSeconds(pauseTime);

		// Moves the plant down back into the pipe
		this.transform.position = new Vector2 (origX, origY);

		// returns collider offset to the original location
		circleCol.offset = new Vector2(0, 0);

		// Wait a certain amount of time before the next statement gets called
		yield return new WaitForSeconds(pauseTime);

		// Re-enables the trigger to suspend the plant
		plantSuspendTrigger.SetActive(true);

		// Returns collider radius to the original location
		circleCol.radius = 10.0f;

		yield return new WaitForSeconds(0.5f);


	}	
}
