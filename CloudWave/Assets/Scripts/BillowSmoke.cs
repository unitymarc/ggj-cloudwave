using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillowSmoke : MonoBehaviour {
	
	/*     Not needed since it's not using particles
	 * 
    [SerializeField]
	private float billowTickRate = 1.0f;

	public GameObject poisonCloud;
	public Transform poisonSpawnPoint;

	void Start () { 
		StartCoroutine("StartPoison");
	}

	IEnumerator StartPoison () {
		yield return new WaitForSeconds(billowTickRate);
		Billow();
		StartCoroutine("StartPoison");
	}

	void Billow () {
		Instantiate(poisonCloud, poisonSpawnPoint.position, Quaternion.identity);
	}*/
}
