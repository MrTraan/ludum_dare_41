using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum eTaskLayoutType {
	DEFAULT,
	TASK_STACK,
	MULTI_SELECTION,
	TRUCK_ORDER,
};

public struct TaskLayout
{
	public eTaskLayoutType type;
	public float completion;
	public Sprite[] pictograms;
};

public class UIManager : MonoBehaviour
{
	public Text chickenAmount;
	public Text steakAmount;
	public Text fishAmount;
	public Text peasAmount;
	public Text carotAmount;
	public Text potatoAmount;

	public Button[] orderButtons;

	public GameObject multiSelectionLayout;
	public GameObject taskStackLayout;
	public GameObject truckOrderLayout;

	public Image[] taskStackButtons;
	public Slider taskStackCompletion;

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

	public void UpdateTaskPanel(TaskLayout layout)
	{
		if (layout.type == eTaskLayoutType.TASK_STACK)
		{
			taskStackLayout.SetActive(true);
			multiSelectionLayout.SetActive(false);
			truckOrderLayout.SetActive(false);

			for (int i = 0; i < layout.pictograms.Length && i < taskStackButtons.Length; i++)
			{
				taskStackButtons[i].enabled = true;
				taskStackButtons[i].sprite = layout.pictograms[i];
			}
			for (int i = layout.pictograms.Length; i < taskStackButtons.Length; i++)
				taskStackButtons[i].enabled = false;

			taskStackCompletion.value = layout.completion / 100.0f;
		}

		if (layout.type == eTaskLayoutType.DEFAULT)
		{
			multiSelectionLayout.SetActive(false);
			taskStackLayout.SetActive(false);
			truckOrderLayout.SetActive(false);
		}
	}

	public void UpdateOrderPanel(Order[] orders)
	{
		for (int i = 0; i < orders.Length; i++)
		{
			orderButtons[i].interactable = true;
		}
		for (int i = orders.Length; i < 9; i++)
		{
			orderButtons[i].interactable = false;
		}
	}
}
