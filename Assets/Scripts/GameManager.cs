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
		if (Input.GetMouseButtonUp(1))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Order o = new Order();
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.tag == "Station")
				{
					o.type = eOrderType.WORK;
					o.position = hit.point;
					o.station = hit.transform.gameObject.GetComponent<IStation>();
					selectionManager.DispatchOrder(o);
				}
				else
				{
					o.type = eOrderType.MOVE;
					o.position = hit.point;
					selectionManager.DispatchOrder(o);
				}
			}
		}
	}

}
