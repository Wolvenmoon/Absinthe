using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory2 : MonoBehaviour {
	
	// Use this for initialization
	private RectTransform inventoryRect;
	
	private float invWidth, invHeight;
	
	public int slots;
	public int rows;
	
	public float slotPaddingLeft, slotPaddingTop;
	public float slotSize;
	public GameObject slotPrefab; // use slot prefab!
	private List<GameObject> slotLS;
	
	private int emptySlot;

	void Start ()
	{
		CreateLayout ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	private void CreateLayout()
	{
		slotLS = new List<GameObject> ();

		emptySlot = slots;

		invWidth = (slots / rows) * (slotSize + slotPaddingLeft) + slotPaddingLeft;
		invHeight = rows * (slotSize + slotPaddingTop) + slotPaddingTop;
		
		inventoryRect = GetComponent <RectTransform> ();
		
		inventoryRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, invHeight);
		inventoryRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, invWidth);
		
		int cols = slots / rows;
		
		for (int y = 0; y < rows; y++)
		{
			for (int x = 0; x < cols; x++)
			{
				GameObject newSlot = (GameObject) Instantiate (slotPrefab);
				RectTransform slotRect = newSlot.GetComponent<RectTransform>();
				newSlot.name = "Slot";
				newSlot.transform.SetParent (this.transform.parent);
				slotRect.localPosition = inventoryRect.localPosition + new Vector3(slotPaddingLeft * (x + 1) + (slotSize * x),
				                                                                   -slotPaddingTop * (y + 1) - (slotSize * y));
				slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
				slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);
				slotRect.localScale = new Vector3(1,1,1);

				slotLS.Add (newSlot);
				
			}
		}
	}

	public bool AddItem(Item item)
	{
		if (item.maxSize == 1)
		{
			return PlaceEmpty (item);
		}
		else
		{
			foreach (GameObject slot in slotLS)
			{
				Slot tmp = slot.GetComponent<Slot>();
				if (!tmp.IsEmpty)
				{
					if (tmp.CurrentItem.type == item.type && tmp.IsAvilable)
					{
						tmp.AddItem (item);
						return true;
					}
				}
			}
			return PlaceEmpty (item);
		}
	}

	private bool PlaceEmpty(Item item)
	{
		if (emptySlot > 0)
		{
			foreach (GameObject slot in slotLS)
			{
				Slot tmp = slot.GetComponent<Slot>();
				if (tmp.IsEmpty)
				{
					tmp.AddItem (item);
					emptySlot--;
					return true;
				}
			}
		}
		return false;
	}
}
