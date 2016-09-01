/*
 * @author 	Rachel Vancleave
 * @date 	9/1/16
 * @class	CS/214 U
 * 
 * This script rotates the coins that are in the game scene.
 **/

using UnityEngine;
using System.Collections;

public class CoinRotaor : MonoBehaviour 
{

	// Private Variables
	public Vector3 rotate = new Vector2 (0f, 15); // Stores a vector 2 for rotating the coin object

	void FixedUpdate()
	{

		// Rotates the coin smoothly every frame
		// Time.Delta time ensures the rotation is framerate indipendent
		transform.Rotate(rotate * Time.deltaTime);

	}


}
