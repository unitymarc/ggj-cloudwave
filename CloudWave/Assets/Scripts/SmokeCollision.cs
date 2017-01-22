using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SmokeCollision : MonoBehaviour
{
    ParticleSystem ps;

    // these lists are used to contain the particles which match
    // the trigger conditions each frame.
    List<ParticleSystem.Particle> inside = new List<ParticleSystem.Particle>();
	[SerializeField]
	private float poisonTickRate = 1.0f;
	[SerializeField]
	private int poisonDamagePerTick = 1;

    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
		ps.trigger.SetCollider(0, GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());
    }


    void OnParticleTrigger()
    {
		if (ps == null)
		{
			return;
		}
        // get the particles which matched the trigger conditions this frame
        int numInside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);

		if (numInside > 0)
		{
			StartCoroutine("StartPoison");
		}
		else {
			StopCoroutine("StartPoison");
		}
    }


	IEnumerator StartPoison()
	{
		ps.trigger.GetCollider(0).gameObject.GetComponent<ShipHealthController>().RemoveCanary();
		yield return new WaitForSeconds(poisonTickRate);
		StartCoroutine("StartPoison");
	}

}


