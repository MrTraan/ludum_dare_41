using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformStation : IStation
{
	public eResource inputResource = eResource.GOLD;
	public int inputAmount = 10;
	public eResource outpoutResource = eResource.MEAT;
	public int outputAmount = 10;

	public override void HandleOrder(Order o)
	{
	}

	protected override void Update()
	{
		base.Update();
		if (task.running && task.IsCompleted())
		{
			GameManager.resourceManager.Add(outpoutResource, outputAmount);
			task.Reset();
		}
		else if (task.running)
		{
			task.Progress(currentWorkers * 1.0f);
		}
		if (!task.running && currentWorkers > 0 && GameManager.resourceManager.Consume(inputResource, inputAmount))
			task.Begin();
	}
}
