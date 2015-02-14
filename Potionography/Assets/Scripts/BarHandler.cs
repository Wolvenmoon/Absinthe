using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarHandler : MonoBehaviour {
	public Player player;
	public Vector3 offset;
	public Vector2 size;

	private float maxHP;
	private float minHP;

	private float currHP;

	public Image healthImg;
	public Text healthText;
	// Use this for initialization
	void Start () {
		maxHP = GetMaxValue();
		currHP = GetCurrentValue();
		minHP = GetMinValue ();
		healthText.text = " " + currHP;
	}
	
	// Update is called once per frame
	void Update () {
		if (currHP != GetCurrentValue()) {
			currHP = GetCurrentValue();
			healthText.text = " " + currHP;
			healthImg.fillAmount = mapValues (currHP, minHP, maxHP, 0, 1);
			SetColor ();
		}
	}



	// All the following methods are created in the case I want to generalize this thing. If I want to generalize this, it'll be easy.

	void SetColor()
	{
		if (currHP > (maxHP + minHP)/2)
		{
			healthImg.color = new Color32((byte) mapValues (currHP,(maxHP + minHP)/2, maxHP, 255, 0), 255, 0 , 255);
		}
		else
		{
			healthImg.color = new Color32(255, (byte) mapValues (currHP, minHP, (maxHP + minHP)/2, 0, 255), 0 , 255);
		}
	}

	// Yeah get the current health!
	float GetCurrentValue()
	{
		return player.health;
	}

	// Gets min value of bar
	float GetMinValue()
	{
		return player.minHealth;
	}

	// Gets max value of bar
	float GetMaxValue()
	{
		return player.maxHealth;
	}

	// Default value of bar. Kind of irrelevant.
	double GetInitValue()
	{
		return GetMaxValue ();
	}

	// Linear mapping bullshit
	private float mapValues(float x, float xMin, float xMax, float outMin, float outMax)
	{
		return (x - xMin) * (outMax - outMin) / (xMax - xMin) + outMin;
	}

}
