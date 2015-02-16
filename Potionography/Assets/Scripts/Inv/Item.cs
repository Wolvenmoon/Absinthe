using UnityEngine;
using System.Collections;

public enum ItemType {MANA, HEALTH};

public class Item : MonoBehaviour
{
	public ItemType type;
	public Sprite spriteNeutral;
	public Sprite spriteHighlighted;
	public int maxSize;

	public void Use()
	{
		switch (type)
		{
		case ItemType.MANA:
			Debug.Log ("Mana potion used!");
			break;
		case ItemType.HEALTH:
			Debug.Log ("Health potion used!");
			break;
		}
	}
}
