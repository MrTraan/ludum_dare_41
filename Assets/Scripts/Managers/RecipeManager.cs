using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
  private Recipe[] recipes;

  // Use this for initialization
  void Start()
  {
    recipes = new Recipe[3];

    recipes[0] = new Recipe();
    recipes[0].ingredients.Add(new Recipe.Ingredient(eResource.STEAK, 10));
    recipes[0].ingredients.Add(new Recipe.Ingredient(eResource.FISH, 10));
    recipes[0].name = "Pasta";
    recipes[0].id = 0;

    recipes[1] = new Recipe();
    recipes[1].ingredients.Add(new Recipe.Ingredient(eResource.STEAK, 20));
    recipes[1].ingredients.Add(new Recipe.Ingredient(eResource.FISH, 10));
    recipes[1].name = "Boeuf Bourguignon";
    recipes[1].id = 1;

    recipes[2] = new Recipe();
    recipes[2].ingredients.Add(new Recipe.Ingredient(eResource.STEAK, 10));
    recipes[2].ingredients.Add(new Recipe.Ingredient(eResource.FISH, 20));
    recipes[2].name = "Beef & Broccoli";
    recipes[2].id = 2;
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
