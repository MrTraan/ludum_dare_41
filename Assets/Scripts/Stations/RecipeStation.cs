using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeStation : IStation
{
	private List<Recipe> cookingStack = new List<Recipe>();

	protected override void Update()
	{
		base.Update();
		if (task.running && task.IsCompleted())
		{
			Debug.Log("We completed recipe " + cookingStack[0].name);
			cookingStack.RemoveAt(0);
			task.Reset();
		}
		else if (task.running)
		{
			task.Progress(currentWorkers * 1.0f);
		}
		if (!task.running && currentWorkers > 0 && cookingStack.Count > 0)
			task.Begin();
	}

	static Order[] myOrders = {
		new Order { type = eOrderType.COOK_RECIPE, recipeId = 0 },
		new Order { type = eOrderType.COOK_RECIPE, recipeId = 1 },
		new Order { type = eOrderType.COOK_RECIPE, recipeId = 2 },
	};

	public override Order[] GetOrderPanel()
	{
		return myOrders;
	}

	public override void HandleOrder(Order o)
	{
		if (o.type == eOrderType.COOK_RECIPE)
		{
			Recipe recipe = GameManager.recipeManager.GetRecipeById(o.recipeId);

			if (!GameManager.resourceManager.ConsumeForRecipe(recipe))
			{
				// Not enough resource for this recipe
				return;
			}
			else
			{
				cookingStack.Add(recipe);
			}
		}
	}
}
