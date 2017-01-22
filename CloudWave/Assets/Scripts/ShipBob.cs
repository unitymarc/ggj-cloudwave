using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBob : MonoBehaviour {

    public float cycleTime = 2.5f;
    public float cycleMagnitude = 6f;

    float time;
    float halfCycleMagnitude;

    void Start()
    {
        time = 0f;
        halfCycleMagnitude = cycleMagnitude * .5f;
    }

    void Update()
    {
        time += Time.deltaTime;
        Vector3 rot = transform.rotation.eulerAngles;
        rot.z = (Mathf.Sin (time) * cycleMagnitude) - halfCycleMagnitude;
        transform.rotation = Quaternion.Euler (rot);
    }
}
