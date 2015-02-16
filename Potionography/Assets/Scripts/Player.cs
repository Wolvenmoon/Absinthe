using UnityEngine;
using System.Collections;
using System; // FOr date time. Like why can't I do System.DateTime.Now

public class Player : MonoBehaviour {
	// The Player is the script that actually does things other than move the player. So things that I actually want to follow usually.

	public Inventory2 inventory;

	// Bullet Variables
	private static Vector3 shootOffset = new Vector3(.5f, .5f, 0f); // Offset from player bullet is created
	private static Vector3 bulletInitVel = new Vector3(5f, 5f, 0f); // Initial velocity of bullet potion
	public GameObject potion; // potion that is copied to be shot around. Yahoo! May make static?


	public float health;
	[SerializeField] public float maxHealth = 100;
	[SerializeField] public float minHealth = 0;
	[SerializeField] public Transform spawnLoc; // Designates where spawn location is
	private UnitySampleAssets._2D.PlatformerCharacter2D platChar; // Points to script that moves character

	// Use this for initialization
	void Start ()
	{
		health = maxHealth;
		platChar = GetComponent<UnitySampleAssets._2D.PlatformerCharacter2D> ();
		transform.position = spawnLoc.position;
		platChar.TurnRight();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	private long CurrTime()
	{
		return System.DateTime.Now.Ticks / 10000; // Divide by 10,000 since DateTime increments Ticks by units of 100ns. I want ms.
	}
	private bool CanShoot()
	{
		return true;
		//return (CurrTime () - lastShotTime >= shootDelay);
	}

	public void Shoot()
	{
		if (CanShoot ()) {
			GameObject pot = (GameObject)Instantiate (potion, transform.position + shootOffset, new Quaternion ());
			pot.rigidbody2D.velocity = bulletInitVel;
		}
	}

	public void Kill()
	{
		health = 0; // you dead
		Respawn();
	}

	public void Damage(float dmg)
	{
		if (health > dmg) {
			health -= dmg;
		} else {
			Kill ();
		}
	}
	
	public void Respawn()
	{
		health = maxHealth;
		platChar.TurnRight();
		transform.position = spawnLoc.position; // GOTO spawn location
		//rigidbody2D.MovePosition(new Vector2(spawnLoc.position.x, spawnLoc.position.y)); // Seemed like a good idea to reset some forces on the rigid body
		//rigidbody2D.velocity = new Vector2(0,0);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		//print ("hitting " + other.tag + " : " + other.name);
		if (other.tag == "Item")
		{
			Debug.Log("Player found item! " + other.name);
			inventory.AddItem(other.GetComponent<Item>());
		}
	}
}

