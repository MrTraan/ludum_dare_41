using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderStation : ISelectable
{
	private Dictionary<eResource, int> orderedResources = new Dictionary<eResource, int>();

	protected override void Start()
	{
		base.Start();
		Reset();
	}

	static Order[] orders = {
	new Order { type = eOrderType.ORDER, resource = eResource.FISH, cost = 10 },
	new Order { type = eOrderType.ORDER, resource = eResource.STEAK, cost = 10 },
	new Order { type = eOrderType.ORDER, resource = eResource.CHICKEN, cost = 10 },
	new Order { type = eOrderType.ORDER, resource = eResource.PEAS, cost = 10 },
	new Order { type = eOrderType.ORDER, resource = eResource.CAROT, cost = 10 },
	new Order { type = eOrderType.ORDER, resource = eResource.POTATOES, cost = 10 },
  };

	public override void HandleOrder(Order o)
	{
		if (o.type == eOrderType.ORDER)
		{
			if (GameManager.resourceManager.Consume(eResource.GOLD, o.cost))
				orderedResources[o.resource]++;
		}
	}

	public override TaskLayout GetTaskLayout()
	{
		TaskLayout layout = new TaskLayout();
		layout.type = eTaskLayoutType.TRUCK_ORDER;
		layout.truckOrder = orderedResources;

		return layout;
	}

	public override Order[] GetOrderPanel()
	{
		return orders;
	}

	public Dictionary<eResource, int> GetOrderedResources()
	{
		return orderedResources;
	}

	public void Reset()
	{
		orderedResources[eResource.FISH] = 0;
		orderedResources[eResource.STEAK] = 0;
		orderedResources[eResource.CHICKEN] = 0;
		orderedResources[eResource.PEAS] = 0;
		orderedResources[eResource.CAROT] = 0;
		orderedResources[eResource.POTATOES] = 0;
	}
}
