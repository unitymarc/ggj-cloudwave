using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private List<Checkpoint> checkpoints = new List<Checkpoint>();
	private int currentCheckpoint = 0;
	public static GameManager instance;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
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
	}
}
