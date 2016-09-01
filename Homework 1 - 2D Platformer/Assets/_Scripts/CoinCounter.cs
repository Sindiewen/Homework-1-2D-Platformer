using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinCounter : MonoBehaviour 
{

	// Somehow isolate the coin storage from this script

	public Text countText;				// Stores the Game object of the Text Object

	[HideInInspector] public int coinCount = 0;			// Stores how many coins the user picked up

	private int coinStorage = 0;


	public void setCountText()
	{
		coinStorage++;
		// Adds 1 to the coin text
		countText.text = "Coins : " + coinStorage.ToString();
	}

}
