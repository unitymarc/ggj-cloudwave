using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanaryPickup : Pickup {

	protected override void Consume(Collider2D col)
	{
		col.gameObject.GetComponent<ShipHealthController>().AddCanary(amount);
	}
}
