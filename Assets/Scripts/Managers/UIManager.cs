using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public Text chickenAmount;

	void Start()
	{

	}

	void Update()
	{
		chickenAmount.text = GameManager.resourceManager.Get(eResource.CHICKEN).ToString();
	}

	public void OrderButtonClick(int id)
	{
		GameManager.selectionManager.DispatchOrderButtonClick(id);
	}

}
