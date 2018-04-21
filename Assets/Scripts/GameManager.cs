using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectionManager))]
public class GameManager : MonoBehaviour
{
	public static GameManager instance { get; private set; }

	public static SelectionManager selectionManager { get; private set; }

	void Awake()
	{
		instance = this;
		selectionManager = GetComponent<SelectionManager>();
	}

	private void Update()
	{
		if (Input.GetMouseButtonUp(1)) {
			Order o;
			o.type = eOrderType.MOVE;
			o.direction = Camera.main.ScreenToViewportPoint(Input.mousePosition);
			selectionManager.DispatchOrder(o);
		}
	}


}
