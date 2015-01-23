using UnityEngine;
using System.Collections;

public class ButtonDisable : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
#if UNITY_ANDROID
        this.gameObject.SetActive(true);
#else
        this.gameObject.SetActive(false);
#endif
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
