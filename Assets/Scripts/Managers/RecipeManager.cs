using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour {
	private Recipe[] recipes;

	// Use this for initialization
	void Start () {
		recipes = new Recipe[1];

		recipes[0] = new Recipe();
		recipes[0].ingredients.Add(new Recipe.Ingredient(eResource.MEAT, 10));
		recipes[0].ingredients.Add(new Recipe.Ingredient(eResource.VEGETABLES, 10));
		recipes[0].name = "Pasta";
		recipes[0].id = 0;
	}
	
	public Recipe[] GetRecipes()
	{
		return recipes;
	}

	public Recipe GetRecipeById(int id)
	{
		return recipes[id];
	}
}
