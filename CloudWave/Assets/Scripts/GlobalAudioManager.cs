using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAudioManager : MonoBehaviour {

    static GlobalAudioManager _instance;
    public AudioSource Crash;
    public AudioSource Poison;

    public static GlobalAudioManager Instance
    {
        get
        {
            return _instance;
        }
    }


    void Start () {
        _instance = this;
    }

    public void PlaySound(string name)
    {
        if (name == "Crash") {
            Crash.Play ();
        } else if (name == "Poison") {
            if (Poison.isPlaying == false) {
                Poison.Play ();
            }
        }
    }

    public void StopSound(string name)
    {
        if (name == "Poison") {
            if (Poison.isPlaying) {
                Poison.Stop ();
            }
        }
    }
}
