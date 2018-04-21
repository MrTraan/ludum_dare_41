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
	void Update()
	{
		if (isSelected)
			transform.localScale = new Vector3(1, 1.5f, 1);
		else
			transform.localScale = new Vector3(1, 1.0f, 1);
	}

	public abstract void HandleOrder(Order o);
}
