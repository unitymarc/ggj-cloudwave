using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestParticleCollision : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    public float speedMod = 1f;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        if (part == null || collisionEvents == null) {
            return;
        }
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

        if (numCollisionEvents > 0) {
            Vector3 pos = collisionEvents[0].intersection;
            Vector3 force = collisionEvents[0].velocity * speedMod;
            rb.AddForce(force);
        }




//        int i = 0;
//
//
//
//
//        while (i < numCollisionEvents)
//        {
//            if (rb)
//            {
//                Vector3 pos = collisionEvents[i].intersection;
//                Vector3 force = collisionEvents[i].velocity * speedMod;
//                rb.AddForce(force);
//            }
//            i++;
//        }
    }
}