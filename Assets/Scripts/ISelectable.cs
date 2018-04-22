using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ISelectable : MonoBehaviour
{
	public bool isSelected = false;

	// Use this for initialization
	virtual protected void Start()
	{
		GameManager.selectionManager.AddSelectable(this);
	}

	virtual protected void OnDestroy()
	{
		if (GameManager.selectionManager)
			GameManager.selectionManager.RemoveSelectable(this);
	}

	// Update is called once per frame
	virtual protected void Update()
	{
	}

	virtual public Order[] GetOrderPanel()
	{
		return new Order[0];
	}

	public static TaskLayout defaultLayout = new TaskLayout { type = eTaskLayoutType.DEFAULT };

	virtual public TaskLayout GetTaskLayout()
	{
		return defaultLayout;
	}

	public abstract void HandleOrder(Order o);
}
