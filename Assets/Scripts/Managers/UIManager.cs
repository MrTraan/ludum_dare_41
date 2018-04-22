using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public Text chickenAmount;
	public Text steakAmount;
	public Text fishAmount;
	public Text peasAmount;
	public Text carotAmount;
	public Text potatoAmount;

	public Button[] orderButtons;

	void Start()
	{

	}

	void Update()
	{
		chickenAmount.text = GameManager.resourceManager.Get(eResource.CHICKEN).ToString();
		steakAmount.text = GameManager.resourceManager.Get(eResource.STEAK).ToString();
		fishAmount.text = GameManager.resourceManager.Get(eResource.FISH).ToString();
		peasAmount.text = GameManager.resourceManager.Get(eResource.PEAS).ToString();
		carotAmount.text = GameManager.resourceManager.Get(eResource.CAROT).ToString();
		potatoAmount.text = GameManager.resourceManager.Get(eResource.POTATOES).ToString();
	}

	public void OrderButtonClick(int id)
	{
		GameManager.selectionManager.DispatchOrderButtonClick(id);
	}

	public void UpdateOrderPanel(Order[] orders)
	{
		for (int i = 0; i < orders.Length; i++)
		{
			orderButtons[i].GetComponent<Image>().color = Color.white;
		}
		for (int i = orders.Length; i < 9; i++)
		{
			orderButtons[i].GetComponent<Image>().color = Color.red;
		}

	}

}
