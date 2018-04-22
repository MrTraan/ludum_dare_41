using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectionManager))]
[RequireComponent(typeof(ResourceManager))]
[RequireComponent(typeof(RecipeManager))]
public class GameManager : MonoBehaviour
{
	public static GameManager instance { get; private set; }

	public static SelectionManager selectionManager { get; private set; }

	public static ResourceManager resourceManager { get; private set; }

	public static RecipeManager recipeManager { get; private set; }

	void Awake()
	{
		instance = this;
		selectionManager = GetComponent<SelectionManager>();
		resourceManager = GetComponent<ResourceManager>();
		recipeManager = GetComponent<RecipeManager>();
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
				else if (hit.transform.tag == "Truck")
				{
					if (hit.transform.gameObject.GetComponent<Truck>().state == Truck.eState.UNLOADING)
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
