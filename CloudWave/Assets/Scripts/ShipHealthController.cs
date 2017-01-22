using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealthController : MonoBehaviour {
	[SerializeField]
	private int numberOfCanaries = 3;
	public GameObject canaryPrefab;
    [SerializeField]
    private List<CanaryMotion> canaries = new List<CanaryMotion>();

    [SerializeField]
    private float xOffsetMin = -6f;
    [SerializeField]
    private float xOffsetMax = -4f;
    [SerializeField]
    private float yOffsetMin = -2f;
    [SerializeField]
    private float yOffsetMax = 2f;

    void Awake()
	{
		for (int i = 0; i < numberOfCanaries; i++)
		{
			SpawnCanary();
		}
	}

	private void SpawnCanary()
	{
		Vector3 offset = new Vector3(UnityEngine.Random.Range(xOffsetMin, xOffsetMax), UnityEngine.Random.Range(yOffsetMin, yOffsetMax));
		var canary = (Instantiate(canaryPrefab, offset, Quaternion.identity) as GameObject).GetComponent<CanaryMotion>();
		canary.follow = transform;
		canary.offset = offset;
		canaries.Add(canary);
	}

	private void KillCanary()
	{
		var canaryToKill = canaries[canaries.Count - 1];
		canaries.Remove(canaryToKill);
		canaryToKill.Kill();
	}

	public void RemoveCanary () {
		numberOfCanaries--;
		KillCanary();
		if(numberOfCanaries <= 0) {
			InstaKill();
		}
	}

	public int GetCanaries()
	{
		return numberOfCanaries;
	}

	public void SetCanaries(int canaries)
	{
		numberOfCanaries = canaries;
	}

	public void AddCanary () {
		numberOfCanaries++;
		SpawnCanary();
	}

	public void AddCanary(int amount)
	{
		numberOfCanaries += amount;
		for (int i = 0; i < amount; i++)
		{
			SpawnCanary();
		}
	}

	public void InstaKill () {
		GameManager.instance.PlayerDied();
		if (numberOfCanaries > 0)
		{
			for (int i = 0; i < canaries.Count; i++)
			{
				KillCanary();
			}
		}
		//GameObject.Destroy(gameObject);
	}
}
