using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanaryMotion : MonoBehaviour {
    public Transform follow;
    public Vector3 offset;
    public AudioSource audio;

	void Start () {
		
	}

	void Update () {
        Vector2 v2 = Vector2.Lerp (transform.position, follow.position + offset, Time.deltaTime);
        transform.position = v2;
	}

    public void Kill()
    {
        GetComponent<Animator> ().SetTrigger ("Dead");
        audio.Play ();
        GetComponent<Rigidbody2D> ().gravityScale = 1f;
		StartCoroutine("StartDestroyTimer");
    }

	IEnumerator StartDestroyTimer()
	{
		yield return new WaitForSeconds(5f);
		GameObject.Destroy(this.gameObject);
	}
}
