using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelGuage : MonoBehaviour {
	[SerializeField]
	private BalloonInputControl player;
	[SerializeField]
	private int fuel;
	[SerializeField]
	private int maxFuel = 100;

	[SerializeField]
	private Transform gauge;

	void Start()
	{
		//player = transform.parent.gameObject.GetComponent<BalloonInputControl>();
		fuel = player.GetFuel();
		UpdateRotation();
	}

	void Update()
	{
		fuel = player.musicFuel;
		UpdateRotation();
	}

	void UpdateRotation()
	{
		var rot = gauge.rotation;
		rot.eulerAngles = new Vector3(0f, 0f, -180f * (1f - (float)fuel / (float)maxFuel));
		gauge.rotation = rot;
	}
}
