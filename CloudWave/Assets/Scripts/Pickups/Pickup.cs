using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
	[SerializeField]
	protected int amount = 1;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.transform.tag == "Player")
		{
			Consume(col);
		}
	}

	protected virtual void Consume(Collider2D col)
	{

	}
}
