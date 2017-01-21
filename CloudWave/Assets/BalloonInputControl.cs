using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonInputControl : MonoBehaviour {

    public float lift;
    public float drag;
    public float forward;
    public float backward;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis ("Lift") > 0f) {
            Lift ();
        }
        if (Input.GetAxis ("Drag") > 0f) {
            Drag ();
        }
        if (Input.GetAxis ("Accelerate") > 0f) {
            Forward ();
        }
        if (Input.GetAxis ("DeAccelerate") > 0f) {
            Backward ();
        }
    }

    void Lift() {
        GetComponent<Rigidbody2D> ().AddForce (Vector2.up * lift);
    }

    void Drag() {
        GetComponent<Rigidbody2D> ().AddForce (Vector2.down * drag);
    }

    void Forward() {
        GetComponent<Rigidbody2D> ().AddForce (Vector2.right * forward);
    }

    void Backward() {
        GetComponent<Rigidbody2D> ().AddForce (Vector2.left * backward);
    }
}
