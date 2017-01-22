using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealthController : MonoBehaviour {
	[SerializeField]
	private int numberOfCanaries = 3;

	public void RemoveCanary () {
		numberOfCanaries--;
		if(numberOfCanaries <= 0) {
			InstaKill();
		}
	}

	public void AddCanary () {
		numberOfCanaries++;
	}

	public void AddCanary(int amount)
	{
		numberOfCanaries += amount;
	}

	public void InstaKill () {
		GameObject.Destroy(gameObject);
	}
}
