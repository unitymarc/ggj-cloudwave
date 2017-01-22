using System;
using UnityEngine;
using System.Collections.Generic;


public class SmokeCollision : MonoBehaviour
{
    ParticleSystem ps;

    // these lists are used to contain the particles which match
    // the trigger conditions each frame.
    List<ParticleSystem.Particle> inside = new List<ParticleSystem.Particle>();


    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
    }


    void OnParticleTrigger()
    {
        // get the particles which matched the trigger conditions this frame
        int numInside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);

        if (numInside > 0) {
            Debug.Log (ps.trigger.GetCollider (0).gameObject.name);
            Debug.Log ("Take smoke damage");
        }
    }




}


