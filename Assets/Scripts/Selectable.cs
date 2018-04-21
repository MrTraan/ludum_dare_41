using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour {
	public bool isSelected = false;

	// Use this for initialization
	void Start () {
		GameManager.selectionManager.AddSelectable(this);
	}

	private void OnDestroy()
	{
		if (GameManager.selectionManager)
			GameManager.selectionManager.RemoveSelectable(this);
	}

	// Update is called once per frame
	void Update () {
		if (isSelected)
			transform.localScale = new Vector3(1, 1.5f, 1);
		else
			transform.localScale = new Vector3(1, 1.0f, 1);
	}

	public void HandleOrder(Order o)
	{
		Debug.Log("Ignoring order");
	}

}
