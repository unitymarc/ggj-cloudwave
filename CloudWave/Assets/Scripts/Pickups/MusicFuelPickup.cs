using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFuelPickup : Pickup {

	protected override void Consume(Collider2D col)
	{
		col.gameObject.GetComponent<BalloonInputControl>().AddFuel(amount);
		base.Consume(col);
	}
}
