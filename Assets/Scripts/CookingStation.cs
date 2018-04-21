using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingStation : IStation {
	protected override void OnProduction()
	{
		GameManager.resourceManager.Add(eResource.GOLD, 10);
	}

	public override void HandleOrder(Order o)
	{
	}

	protected override void Update()
	{
		base.Update();
		if (!task.running && currentWorkers > 0 && GameManager.resourceManager.Consume(eResource.MEAT, 10))
			task.Begin();
	}
}
