using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Obstacles
{
	WHALE,
	SHARK,
	BOBBER
}

public class Obstalce : MonoBehaviour
{
	public Obstacles type;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Crab"))
		{
			switch (type)
			{
				case Obstacles.WHALE:

					break;
				case Obstacles.SHARK:

					break;
				case Obstacles.BOBBER:

					break;
			}
		}
	}
}