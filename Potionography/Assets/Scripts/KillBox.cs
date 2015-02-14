using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
		//print ("spam");
	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.gameObject.tag == "Player") {
			print ("WE HAVE ACHIEVED DEATH ALL HAIL THE GLOW CLOUD : RESPAWNING! ");
			var player = hit.gameObject.GetComponent<Player> ();
			player.Kill ();
		} else if (hit.gameObject.tag == "Potion") {
			print ("Destroying a potion that hit a kill block!");
			Destroy (hit.gameObject);
		}
	}

}
