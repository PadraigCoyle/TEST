using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableScript2 : MonoBehaviour
{

	public TMP_Text goText; 
	public TMP_Text conText;

	// Use this for initialization
	void Awake()
	{
		conText.text = "";
		goText.text = "";
	}

	/*This continuously checks for collision with the player and if it occurs, the collectible is unloaded and 
    DecrementCollectibles function is run */
	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.tag == "Player")
		{
			Destroy(gameObject);
			conText.text = "Congradulations! You finished!";
			goText.text = "Head Back!";
		}
	}
}