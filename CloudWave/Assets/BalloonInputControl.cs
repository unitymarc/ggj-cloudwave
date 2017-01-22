using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonInputControl : MonoBehaviour {

    public float lift;
    public float drag;
    public float forward;
    public float backward;


    [SerializeField]
    private AudioSource LiftSFX;
    [SerializeField]
    private AudioSource DragSFX;
    [SerializeField]
    private AudioSource ForwardSFX;
    [SerializeField]
    private AudioSource BackwardSFX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis ("Lift") > 0f) {
            Lift ();
        } else {
            NoLift ();
        }
        if (Input.GetAxis ("Drag") > 0f) {
            Drag ();
        } else {
            NoDrag ();
        }
        if (Input.GetAxis ("Accelerate") > 0f) {
            Forward ();
        } else {
            NoForward ();
        }
        if (Input.GetAxis ("DeAccelerate") > 0f) {
            Backward ();
        } else {
            NoBackward ();
        }
    }

    void Lift() {
        GetComponent<Rigidbody2D> ().AddForce (Vector2.up * lift);
        StartFX (LiftSFX);
    }

    void NoLift() {
        StopFX (LiftSFX);
    }

    void Drag() {
        GetComponent<Rigidbody2D> ().AddForce (Vector2.down * drag);
        StartFX (DragSFX);
    }

    void NoDrag() {
        StopFX (DragSFX);
    }

    void Forward() {
        GetComponent<Rigidbody2D> ().AddForce (Vector2.right * forward);
        StartFX (ForwardSFX);
    }

    void NoForward() {
        StopFX (ForwardSFX);
    }

    void Backward() {
        GetComponent<Rigidbody2D> ().AddForce (Vector2.left * backward);
        StartFX (BackwardSFX);
    }

    void NoBackward() {
        StopFX (BackwardSFX);
    }

    void StartFX(AudioSource source)
    {
        if (source) {
            source.volume = 1f;
        }
    }
    void StopFX(AudioSource source)
    {
        if (source)
            source.volume = 0f;
    }
}
