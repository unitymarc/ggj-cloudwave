using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera2D : MonoBehaviour {


    public Transform target;
    public float followSpeed = .9f;


	void Start () {
		
	}

	void FixedUpdate () {
        Vector3 v3 = transform.position;
        Vector3 targetV3 = target.transform.position;
        v3.x = v3.x + ((targetV3.x - v3.x)) * followSpeed;
        transform.position = v3;
	}
}
