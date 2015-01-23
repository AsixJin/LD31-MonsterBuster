using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

    public AudioSource audio;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.M) && audio.mute)
        {
            audio.mute = false;
        }
        else if (Input.GetKeyDown(KeyCode.M) && !audio.mute)
        {
            audio.mute = true;
        }
	}
}
