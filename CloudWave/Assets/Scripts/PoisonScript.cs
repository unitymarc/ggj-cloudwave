using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonScript : MonoBehaviour {
	[SerializeField]
	private float poisonTickRate = 1.0f;
	[SerializeField]
	private int poisonDamagePerTick = 1;

	private ShipHealthController player;

	void OnTriggerEnter2D (Collider2D col) {
		if (col.transform.tag == "Player") {
			if(player == null) {
				player = col.gameObject.GetComponent<ShipHealthController>();
				StartCoroutine("StartPoison");
			}
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.transform.tag == "Player") {
			if (player != null) {
				player = null;
				StopCoroutine("StartPoison");
			}
		}
	}

	IEnumerator StartPoison() {
		player.RemoveCanary();
		yield return new WaitForSeconds(poisonTickRate);
		if(player != null) {
			StartCoroutine("StartPoison");
		}
	}
}
