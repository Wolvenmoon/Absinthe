using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public bool paused = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (paused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}
}
