using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    public static GameManager manager;

    private void Start()
    {
        if(manager == null)
        {
            manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        }
    } 

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            //TODO: Send checkpoint even to game manager
        }
    }
}
