using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
  private Recipe[] recipes;
  public float rythmeMin = 3;
  public float rythmeMax = 6;
  public int stackMax = 4;

  private List<Recipe> commands = new List<Recipe>();
  private bool maxStackReached = false;

  public int recipeDoneCount = 0;

  void Start()
  {
    recipes = new Recipe[9];

    recipes[0] = new Recipe();
    recipes[0].ingredients.Add(new Recipe.Ingredient(eResource.T_CAROT, 1));
    recipes[0].ingredients.Add(new Recipe.Ingredient(eResource.T_PEAS, 1));
    recipes[0].name = "Carrots & Peas";
    recipes[0].id = 0;

    recipes[1] = new Recipe();
    recipes[1].ingredients.Add(new Recipe.Ingredient(eResource.T_FISH, 1));
    recipes[1].ingredients.Add(new Recipe.Ingredient(eResource.T_CAROT, 1));
    recipes[1].name = "Carrots & Fish";
    recipes[1].id = 1;

    recipes[2] = new Recipe();
    recipes[2].ingredients.Add(new Recipe.Ingredient(eResource.T_FISH, 1));
    recipes[2].ingredients.Add(new Recipe.Ingredient(eResource.T_POTATOES, 1));
    recipes[2].name = "Fish & Chips";
    recipes[2].id = 2;

    recipes[3] = new Recipe();
    recipes[3].ingredients.Add(new Recipe.Ingredient(eResource.T_FISH, 1));
    recipes[3].ingredients.Add(new Recipe.Ingredient(eResource.T_PEAS, 1));
    recipes[3].name = "Fish & Peas";
    recipes[3].id = 3;

    recipes[4] = new Recipe();
    recipes[4].ingredients.Add(new Recipe.Ingredient(eResource.T_CHICKEN, 1));
    recipes[4].ingredients.Add(new Recipe.Ingredient(eResource.T_CAROT, 1));
    recipes[4].name = "Chicken & Carrots";
    recipes[4].id = 4;

    recipes[5] = new Recipe();
    recipes[5].ingredients.Add(new Recipe.Ingredient(eResource.T_CHICKEN, 1));
    recipes[5].ingredients.Add(new Recipe.Ingredient(eResource.T_POTATOES, 1));
    recipes[5].name = "Chicken & Fries";
    recipes[5].id = 5;

    recipes[6] = new Recipe();
    recipes[6].ingredients.Add(new Recipe.Ingredient(eResource.T_CHICKEN, 1));
    recipes[6].ingredients.Add(new Recipe.Ingredient(eResource.T_PEAS, 1));
    recipes[6].name = "Chicken & Peas";
    recipes[6].id = 6;

    recipes[7] = new Recipe();
    recipes[7].ingredients.Add(new Recipe.Ingredient(eResource.T_STEAK, 1));
    recipes[7].ingredients.Add(new Recipe.Ingredient(eResource.T_CAROT, 1));
    recipes[7].name = "Steak & Carrots";
    recipes[7].id = 7;

    recipes[8] = new Recipe();
    recipes[8].ingredients.Add(new Recipe.Ingredient(eResource.T_STEAK, 1));
    recipes[8].ingredients.Add(new Recipe.Ingredient(eResource.T_POTATOES, 1));
    recipes[8].name = "Steak & Fries";
    recipes[8].id = 8;

    //recipes[9] = new Recipe();
    //recipes[9].ingredients.Add(new Recipe.Ingredient(eResource.T_STEAK, 1));
    //recipes[9].ingredients.Add(new Recipe.Ingredient(eResource.T_PEAS, 1));
    //recipes[9].name = "Steak & Peas";
    //recipes[9].id = 9;

    StartCoroutine("AddCommand", Random.Range(rythmeMin, rythmeMax));
  }

  void Update()
  {
    if (maxStackReached && commands.Count < stackMax)
    {
      StartCoroutine("AddCommand", Random.Range(rythmeMin, rythmeMax));
      maxStackReached = false;
    }
  }

  public Recipe[] GetRecipes()
  {
    return recipes;
  }

  public Recipe GetRecipeById(int id)
  {
    return recipes[id];
  }

  public void ServeRecipe(Recipe recipe)
  {
    foreach (Recipe item in commands)
    {
      if (item.id == recipe.id)
      {
        GameManager.resourceManager.Add(eResource.GOLD, 30);
        commands.Remove(item);
        recipeDoneCount++;
        GameManager.uiManager.UpdateRecipeCount(recipeDoneCount);
        if (recipeDoneCount == GameManager.recipeTarget)
          GameManager.Win();
        return;
      }
    }
  }

  public List<Recipe> GetCurrentCommandList()
  {
    return commands;
  }

  IEnumerator AddCommand(float t)
  {
    yield return new WaitForSeconds(t);
    commands.Add(recipes[Random.Range(0, recipes.Length)]);
    if (commands.Count < stackMax)
      StartCoroutine("AddCommand", Random.Range(rythmeMin, rythmeMax));
    else
      maxStackReached = true;
  }
}
