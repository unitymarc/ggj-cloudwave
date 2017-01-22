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
    public float maxspeed = 1;
    public float dragValue = 1;


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

    [SerializeField]
    private GameObject LiftGO;
    [SerializeField]
    private GameObject DragGO;
    [SerializeField]
    private GameObject ForwardGO;
    [SerializeField]
    private GameObject BackwardGO;

    List<GameObject> instrumentAnimList = new List<GameObject>();

    Dictionary<AudioSource, float> sfxDests = new Dictionary<AudioSource, float>();

	public int GetFuel()
	{
		return musicFuel;
	}

	public void SetFuel(int fuel)
	{
		musicFuel = fuel;
	}

	// Use this for initialization
	void Start () {
        sfxDests [LiftSFX] = 0f;
        sfxDests [DragSFX] = 0f;
        sfxDests [ForwardSFX] = 0f;
        sfxDests [BackwardSFX] = 0f;

        InvokeRepeating ("AnimateInstruments", .1f, .05f);
	}

    void FixedUpdate()
    {
        LerpSounds ();
        Vector2 v2 = GetComponent<Rigidbody2D>().velocity;
        v2.x *= dragValue;
        GetComponent<Rigidbody2D>().velocity = v2;
    }

    // Update is called once per frame
    void Update () {
		if (musicFuel > 0)
		{
			if (Input.GetAxis("Lift") > 0f && Input.GetAxis("Lift") < 10f)
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
			if (Input.GetAxis("Accelerate") > 0f && Input.GetAxis("Accelerate") < 2f)
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
        StartFX (LiftSFX, LiftParticles, LiftGO);
    }

    void NoLift() {
        StopFX (LiftSFX, LiftParticles, LiftGO);
    }

    void Drag() {
		if (!IsInvoking("StartUsingFuel"))
		{
			InvokeRepeating("StartUsingFuel", 0f, musicFuelUsageRate);
		}
        GetComponent<Rigidbody2D> ().AddForce (Vector2.down * drag);
        StartFX (DragSFX, DragParticles, DragGO);
    }

    void NoDrag() {
        StopFX (DragSFX, DragParticles, DragGO);
    }

    void Forward() {
		if (!IsInvoking("StartUsingFuel"))
		{
			InvokeRepeating("StartUsingFuel", 0f, musicFuelUsageRate);
		}
       
      var currentVelocity =GetComponent<Rigidbody2D>().velocity;

        if (currentVelocity.x < maxspeed)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * forward);
        }
        else
            currentVelocity.x = maxspeed;
        StartFX (ForwardSFX, ForwardParticles, ForwardGO);
    }

    void NoForward() {
        StopFX (ForwardSFX, ForwardParticles, ForwardGO);
    }

    void Backward() {
		if (!IsInvoking("StartUsingFuel"))
		{
			InvokeRepeating("StartUsingFuel", 0f, musicFuelUsageRate);
		}
        var currentVelocity = GetComponent<Rigidbody2D>().velocity;

        if (currentVelocity.x > -maxspeed)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * backward);
        }
        else
            currentVelocity.x = -maxspeed; 
        StartFX (BackwardSFX, BackwardParticles, BackwardGO);
    }

    void NoBackward() {
        StopFX (BackwardSFX, BackwardParticles, BackwardGO);
    }

    void StartFX(AudioSource source, ParticleSystem ps, GameObject go)
    {
        if (go && !instrumentAnimList.Contains (go)) {
            instrumentAnimList.Add (go);
        }

        if (source) {
            LerpSound (source, 1f);
        }
        if (ps) {
            ps.gameObject.SetActive(true);
        }
    }
    void StopFX(AudioSource source, ParticleSystem ps, GameObject go)
    {
        if (go && instrumentAnimList.Contains (go)) {
            go.SetActive (false);
            instrumentAnimList.Remove (go);
        }

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

    void AnimateInstruments()
    {
        foreach (GameObject go in instrumentAnimList) {
            if (go.activeSelf) {
                go.SetActive (false);
            } else {
                go.SetActive (true);
            }
        }
    }
}
