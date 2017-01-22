using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonInputControl : MonoBehaviour {
	[SerializeField]
	private int musicFuel = 10;
	[SerializeField]
	private float musicFuelUsageRate = 1f;

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

    [SerializeField]
    private ParticleSystem LiftParticles;
    [SerializeField]
    private ParticleSystem DragParticles;
    [SerializeField]
    private ParticleSystem ForwardParticles;
    [SerializeField]
    private ParticleSystem BackwardParticles;

    Dictionary<AudioSource, float> sfxDests = new Dictionary<AudioSource, float>();

	// Use this for initialization
	void Start () {
        sfxDests [LiftSFX] = 0f;
        sfxDests [DragSFX] = 0f;
        sfxDests [ForwardSFX] = 0f;
        sfxDests [BackwardSFX] = 0f;
	}

    void FixedUpdate()
    {
        LerpSounds ();
    }
	
	// Update is called once per frame
	void Update () {
		if (musicFuel > 0)
		{
			if (Input.GetAxis("Lift") > 0f)
			{
				Lift();
			}
			else {
				NoLift();
			}
			if (Input.GetAxis("Drag") > 0f)
			{
				Drag();
			}
			else {
				NoDrag();
			}
			if (Input.GetAxis("Accelerate") > 0f)
			{
				Forward();
			}
			else {
				NoForward();
			}
			if (Input.GetAxis("DeAccelerate") > 0f)
			{
				Backward();
			}
			else {
				NoBackward();
			}
		}

		if (IsInvoking("StartUsingFuel")) 
		{
			if (!(Input.GetAxis("Lift") > 0f) && !(Input.GetAxis("Drag") > 0f) && !(Input.GetAxis("Accelerate") > 0f) && !(Input.GetAxis("DeAccelerate") > 0f))
			{
				CancelInvoke("StartUsingFuel");
			}
		}

    }

    void Lift() {
		if (!IsInvoking("StartUsingFuel") )
		{
			InvokeRepeating("StartUsingFuel", 0f, musicFuelUsageRate);
		}
        GetComponent<Rigidbody2D> ().AddForce (Vector2.up * lift);
        StartFX (LiftSFX, LiftParticles);
    }

    void NoLift() {
        StopFX (LiftSFX, LiftParticles);
    }

    void Drag() {
		if (!IsInvoking("StartUsingFuel"))
		{
			InvokeRepeating("StartUsingFuel", 0f, musicFuelUsageRate);
		}
        GetComponent<Rigidbody2D> ().AddForce (Vector2.down * drag);
        StartFX (DragSFX, DragParticles);
    }

    void NoDrag() {
        StopFX (DragSFX, DragParticles);
    }

    void Forward() {
		if (!IsInvoking("StartUsingFuel"))
		{
			InvokeRepeating("StartUsingFuel", 0f, musicFuelUsageRate);
		}
        GetComponent<Rigidbody2D> ().AddForce (Vector2.right * forward);
        StartFX (ForwardSFX, ForwardParticles);
    }

    void NoForward() {
        StopFX (ForwardSFX, ForwardParticles);
    }

    void Backward() {
		if (!IsInvoking("StartUsingFuel"))
		{
			InvokeRepeating("StartUsingFuel", 0f, musicFuelUsageRate);
		}
        GetComponent<Rigidbody2D> ().AddForce (Vector2.left * backward);
        StartFX (BackwardSFX, BackwardParticles);
    }

    void NoBackward() {
        StopFX (BackwardSFX, BackwardParticles);
    }

    void StartFX(AudioSource source, ParticleSystem ps)
    {
        if (source) {
            LerpSound (source, 1f);
        }
        if (ps) {
            ps.gameObject.SetActive(true);
        }
    }
    void StopFX(AudioSource source, ParticleSystem ps)
    {
        if (source) {
            LerpSound (source, 0f);
        }

        if (ps) {
            ps.gameObject.SetActive(false);
        }
    }

    void LerpSound(AudioSource source, float dest)
    {
        sfxDests[source] = dest;
    }

    void LerpSounds() {
        foreach (KeyValuePair<AudioSource, float> kv in sfxDests) {
            kv.Key.volume = kv.Key.volume + (kv.Value - kv.Key.volume) * .95f;
        }
    }

	void StartUsingFuel()
	{
		musicFuel--;
	}

	public void AddFuel(int amountToAdd)
	{
		musicFuel += amountToAdd;
	}
}
