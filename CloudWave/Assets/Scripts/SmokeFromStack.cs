using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeFromStack : MonoBehaviour {
	private Rigidbody2D rb;
	[SerializeField]
	private float expandTime = 2.0f;
	private float timeToFinish = 0.0f;
	[SerializeField]
	private float howManyTimesToExpand = 3.0f;
	private Material mat;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		mat = gameObject.GetComponent<Renderer>().material;
		rb.AddForce(new Vector2(-16, 64));
		timeToFinish = Time.time + expandTime;
	}
	
	void Update () {
		if (Time.time < timeToFinish) {
			float scale = Mathf.Abs((((timeToFinish - Time.time)/expandTime) - 1)) * howManyTimesToExpand;
			transform.localScale = new Vector3(1.5f + scale, 1f + scale, 1f + scale);
			var color = mat.color;
			color.a = 1 - scale;
			mat.color = color;
		}
		else {
			GameObject.Destroy(this.gameObject);
		}
	}
}
