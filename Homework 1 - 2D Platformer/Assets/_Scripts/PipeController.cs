using UnityEngine;
using System.Collections;

public class PipeController : MonoBehaviour 
{

	// Public Variables
	public Transform destLocation;
	public Transform Player;

	public bool portOnCollide 			= false;

	// Private Variables
	private bool IsPlayerStandingOn 	= false;


	void OnTriggerEnter2D (Collider2D col)
	{
		IsPlayerStandingOn = true;

		if(portOnCollide)
		{
			Player.transform.position = destLocation.transform.position;
		}
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
				Player.transform.position = destLocation.transform.position;
			}

		}
	}

}


