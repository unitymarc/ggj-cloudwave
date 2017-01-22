using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private List<Checkpoint> checkpoints = new List<Checkpoint>();
	private int currentCheckpoint = 0;
	public static GameManager instance;

	private GameObject player;
	private int playerCanariesAtCheckpoint = 3;
	private int playerFuelAtCheckpoint = 10;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		player = GameObject.FindGameObjectWithTag("Player");
		UpdatePlayerVals();
	}

	private void UpdatePlayerVals()
	{
		playerCanariesAtCheckpoint = player.GetComponent<ShipHealthController>().GetCanaries();
		playerFuelAtCheckpoint = player.GetComponent<BalloonInputControl>().GetFuel();
	}

	public int RegisterCheckpoint(Checkpoint checkpointToReg)
	{
		int checkpointId = checkpoints.Count;
		checkpoints.Add(checkpointToReg);
		return checkpointId;
	}

	public void PlayerReachedNewCheckpoint(int checkpointId)
	{
		currentCheckpoint = checkpointId;
		UpdatePlayerVals();
	}

	public void PlayerDied()
	{
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		player.GetComponent<ShipHealthController>().SetCanaries(playerCanariesAtCheckpoint);
		player.GetComponent<BalloonInputControl>().SetFuel(playerFuelAtCheckpoint);
		player.transform.position = new Vector3(checkpoints[currentCheckpoint].transform.position.x, 0f, 0f);
	}
}
