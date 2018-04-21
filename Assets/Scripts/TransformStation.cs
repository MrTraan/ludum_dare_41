using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformStation : IStation {
	public eResource inputResource = eResource.GOLD;
	public int inputAmount = 10;
	public eResource outpoutResource = eResource.MEAT;
	public int outputAmount = 10;

	protected override void OnProduction()
	{
		GameManager.resourceManager.Add(outpoutResource, outputAmount);
	}

	public override void HandleOrder(Order o)
	{
	}

	protected override void Update()
	{
		base.Update();
		if (!task.running && currentWorkers > 0 && GameManager.resourceManager.Consume(inputResource, inputAmount))
			task.Begin();
	}
}
