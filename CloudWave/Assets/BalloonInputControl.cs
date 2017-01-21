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
        if (Input.GetAxis ("Lift") < 0f) {
            Drag ();
        }
        if (Input.GetAxis ("X-Axis") > 0f) {
            Forward ();
        }
        if (Input.GetAxis ("X-Axis") < 0f) {
            Backward ();
        }
    }

    void Lift() {
        GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 20f);
    }

    void Drag() {
        GetComponent<Rigidbody2D> ().AddForce (Vector2.down * 10f);
    }

    void Forward() {
        GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 20f);
    }

    void Backward() {
        GetComponent<Rigidbody2D> ().AddForce (Vector2.left * 10f);
    }
}
