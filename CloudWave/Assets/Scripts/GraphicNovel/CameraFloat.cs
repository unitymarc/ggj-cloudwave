using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFloat : MonoBehaviour {
	
    public float cycleTime = 2.5f;
    public float cycleHeight = 1f;

    Vector3 basePos;
    float time;
    float halfCycleHeight;

    void Start()
    {
        basePos = transform.position;
        time = 0f;
        halfCycleHeight = cycleHeight * .5f;
    }

    void Update()
    {
        time += Time.deltaTime;
        Vector3 v3 = basePos;
        basePos.y = (Mathf.Sin (time) * cycleHeight) - halfCycleHeight;
        transform.position = v3;
    }
}
