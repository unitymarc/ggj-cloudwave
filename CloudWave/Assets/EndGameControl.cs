using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameControl : MonoBehaviour {

    public AudioSource endSound;
    public Vector3 landingSpot;

    GameObject ship;

    private bool gameOver = false;


    void Update()
    {
        if (gameOver && ship)
        {
            ship.transform.position = Vector3.Slerp (ship.transform.position, transform.position + landingSpot, Time.deltaTime * 3f);
            ship.transform.localScale = Vector3.Slerp (ship.transform.localScale, Vector3.zero, Time.deltaTime * 3f);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            ship = other.gameObject;
            GameSuccess ();
        }
    }

    void GameSuccess()
    {
        gameOver = true;
        endSound.Play ();

        ship.GetComponent<BalloonInputControl> ().enabled = false;
        ship.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
        ship.GetComponent<Rigidbody2D> ().gravityScale = 0f;
    }
}
