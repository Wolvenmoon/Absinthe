using UnityEngine;
using System.Collections;

public class HarmfulObstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.gameObject.tag == "Player") {
			print ("WE HAVE ACHIEVED DAMAGE");
			var player = hit.gameObject.GetComponent<Player> ();
			player.Damage (10f);
		}
	}
}
