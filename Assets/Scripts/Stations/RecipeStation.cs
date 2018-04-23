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
			GameManager.recipeManager.ServeRecipe(cookingStack[0]);
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
	new Order { type = eOrderType.COOK_RECIPE, recipeId = 3 },
	new Order { type = eOrderType.COOK_RECIPE, recipeId = 4 },
	new Order { type = eOrderType.COOK_RECIPE, recipeId = 5 },
	new Order { type = eOrderType.COOK_RECIPE, recipeId = 6 },
	new Order { type = eOrderType.COOK_RECIPE, recipeId = 7 },
	new Order { type = eOrderType.COOK_RECIPE, recipeId = 8 },
  };

	public override TaskLayout GetTaskLayout()
	{
		TaskLayout layout = new TaskLayout();
		layout.type = eTaskLayoutType.TASK_STACK;
		layout.completion = task.completion;

		layout.pictograms = new Sprite[cookingStack.Count];
		for (int i = 0; i < cookingStack.Count; i++)
			layout.pictograms[i] = GameManager.pictoManager.GetRecipe(cookingStack[i].id);

		return layout;
	}


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
				Debug.Log("Not enough resources for this recipe");
				return;
			}
			else
			{
				cookingStack.Add(recipe);
			}
		}
	}
}
