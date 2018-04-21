using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text gold;
	public Text vegetables;
	public Text meat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int goldAmount = GameManager.resourceManager.Get(eResource.GOLD);
		gold.text = "Gold: " + goldAmount.ToString();
		int meatAmount = GameManager.resourceManager.Get(eResource.MEAT);
		meat.text = "Meat: " + meatAmount.ToString();
		int vegetablesAmount = GameManager.resourceManager.Get(eResource.VEGETABLES);
		vegetables.text = "Vegetables: " + vegetablesAmount.ToString();
	}
}
