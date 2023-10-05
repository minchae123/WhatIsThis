using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Obstacles
{
	WHALE,
	SHARK,
	BOBBER
}

public class Obstacle : MonoBehaviour
{
	public Obstacles type;

	private WhaleShark whaleshark;
	private Bobber bobber;

	private void Awake()
	{
		switch (type)
		{
			case Obstacles.WHALE:
			case Obstacles.SHARK:
				whaleshark = GetComponentInChildren<WhaleShark>();
				break;
			case Obstacles.BOBBER:
				bobber = GetComponent<Bobber>();
				break;
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Crab"))
		{
			switch (type)
			{
				case Obstacles.WHALE:
				case Obstacles.SHARK:
					whaleshark.Yam();
					Destroy(collision.gameObject);
					break;
				case Obstacles.BOBBER:
					bobber.ResetPos();
					collision.gameObject.transform.parent = transform;
					Destroy(collision.GetComponent<Dragger>());
					break;
			}
		}
	}
}