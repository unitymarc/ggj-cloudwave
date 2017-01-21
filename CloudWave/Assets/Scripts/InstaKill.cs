using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKill : MonoBehaviour {


	void OnCollisionEnter2D (Collision2D col) {
		if (col.transform.tag == "Player") {
			col.gameObject.GetComponent<ShipHealthController>().InstaKill();
		}
	} 
}
