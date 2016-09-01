﻿/*
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
	public GameObject player;		// Stores reference to the player GameObject

	public float pauseTime = 1.0f;	// Sets how long the plant should pause before doing anything else
	public float riseHeight;		// Sets how high the plant will rise

	// Private Variables

	private float origX;			// Stores the original position of the plant X
	private float origY;			// Stores the original position of the plant Y

	private CircleCollider2D circleCol;				// Stores refrerence to the CircleCollider2D

	// Starts at the first frame of the game
	void Start()
	{
		circleCol = gameObject.GetComponent<CircleCollider2D>();	// Gets the circle collider2D Component

		origX = transform.position.x;	// Stores the original position of the plant X
		origY = transform.position.y;	// Stores the original position of the plant Y
	}

	// When the player enters the trigger
	void OnTriggerEnter2D(Collider2D col)
	{
		// Disables the circle collider 2D component
		circleCol.radius = 0.2f;

		// Changes the offset of the collider box
		circleCol.offset = new Vector2(0, -20);

		// Starts coroutine to shoot player
		StartCoroutine(ShootPlayer());
	}


	// Shoots the player when they arrive in the trigger radius
	IEnumerator ShootPlayer()
	{
		// Function Variables
		float yPos = transform.position.y;	// Stores y corordinate of Plant's original position
		float xPos = transform.position.x;	// Stores x corordinate of Plant's original position

		//Moves plant upwards
		this.transform.position = new Vector2 (xPos, yPos + riseHeight);

		// Wait a certain ammount of time before the next statement gets called
		yield return new WaitForSeconds(pauseTime);

		// Moves the plant down back into the pipe
		this.transform.position = new Vector2 (origX, origY);

		// returns collider offset to the original location
		circleCol.offset = new Vector2(0, 0);

		// Wait a certain amount of time before the next statement gets called
		yield return new WaitForSeconds(pauseTime);

		// Returns collider radius to the original location
		circleCol.radius = 10.0f;
	}	


}