using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndScript : MonoBehaviour {
    public string winScene;
    public GameObject player;
    // Use this for initialization
	void Start () {
        
            player = GameObject.FindGameObjectWithTag("Player");   
	              }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(winScene);
    }
}
