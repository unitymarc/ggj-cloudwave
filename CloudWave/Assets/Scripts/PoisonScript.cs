using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonScript : MonoBehaviour {
	public ParticleSystem part;
	public List<ParticleCollisionEvent> collisionEvents;
	[SerializeField]
	private float poisonTickRate = 1.0f;
	[SerializeField]
	private int poisonDamagePerTick = 1;

	void Start()
	{
		part = GetComponent<ParticleSystem>();
		collisionEvents = new List<ParticleCollisionEvent>();
	}

	void OnParticleCollision(GameObject other)
	{
		if (part == null || collisionEvents == null)
		{
			return;
		}
		if (other.transform.tag == "Player")
		{
			int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

			if (numCollisionEvents > 0)
			{

			}
		}
	}

	/*     Not needed since it's not using particles
	 * 


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
	}*/
}
