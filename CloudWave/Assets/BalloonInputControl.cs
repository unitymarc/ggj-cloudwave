using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonInputControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis ("Lift") > 0f) {
            Lift ();
        }
	}

    void Lift() {
        GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 20f);
    }
}
