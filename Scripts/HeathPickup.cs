using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathPickup : MonoBehaviour
{
	
	public Player player;
	public int HealthtoAdd;
	public bool isColliding;



	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Debug.Log("collided");
			if (isColliding)
				return;
			else
			{
				isColliding = true;
				player.Heal(HealthtoAdd);
				Destroy(gameObject);
			}

		}
	}

	void Update()
	{
		isColliding = false;
	}
}
