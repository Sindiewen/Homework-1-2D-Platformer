using UnityEngine;
using System.Collections;

public class PipeController : MonoBehaviour 
{

	// Public Variables
	public Transform destLocation;
	public Transform Player;

	private bool IsPlayerStandingOn = false;


	// Private Variables

	void OnTriggerEnter2D (Collider2D col)
	{
		IsPlayerStandingOn = true;
	}

	void OnTriggerExit2D (Collider2D col)
	{
		IsPlayerStandingOn = false;
	}

	void Update()
	{
		if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
		{
			if(IsPlayerStandingOn)
			{
				Debug.Log("Teleport Initiated");
				//GameObject.Find("Player").GetComponent<Transform>().Translate(5,5);
				//TODO: Teleport player to the destination pipe
				// xpos and ypos are placeholders, repalce with destination pipe
				Player.transform.position = destLocation.transform.position;
			}

		}
	}

}


