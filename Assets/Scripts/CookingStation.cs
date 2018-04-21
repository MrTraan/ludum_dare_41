using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingStation : IStation {
	protected override void OnProduction()
	{
		GameManager.ressourceManager.AddGold(10);
	}

	public override void HandleOrder(Order o)
	{
	}
}
