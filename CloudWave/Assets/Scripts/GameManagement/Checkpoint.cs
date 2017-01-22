using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
	private int checkpointId = -1;
	private bool alreadyReached = false;
    void Start()
	{
		checkpointId = GameManager.instance.RegisterCheckpoint(this);
    } 

    void OnTriggerEnter2D(Collider2D col)
	{
		if (!alreadyReached && col.transform.tag == "Player")
		{
			GameManager.instance.PlayerReachedNewCheckpoint(checkpointId);
			alreadyReached = true;
        }
    }
}
