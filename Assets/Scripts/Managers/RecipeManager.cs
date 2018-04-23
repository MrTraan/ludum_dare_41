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

  void Start()
  {
    recipes = new Recipe[3];

    recipes[0] = new Recipe();
    recipes[0].ingredients.Add(new Recipe.Ingredient(eResource.STEAK, 1));
    recipes[0].ingredients.Add(new Recipe.Ingredient(eResource.FISH, 1));
    recipes[0].name = "Pasta";
    recipes[0].id = 0;

    recipes[1] = new Recipe();
    recipes[1].ingredients.Add(new Recipe.Ingredient(eResource.STEAK, 2));
    recipes[1].ingredients.Add(new Recipe.Ingredient(eResource.FISH, 1));
    recipes[1].name = "Boeuf Bourguignon";
    recipes[1].id = 1;

    recipes[2] = new Recipe();
    recipes[2].ingredients.Add(new Recipe.Ingredient(eResource.STEAK, 1));
    recipes[2].ingredients.Add(new Recipe.Ingredient(eResource.FISH, 2));
    recipes[2].name = "Beef & Broccoli";
    recipes[2].id = 2;

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
        commands.Remove(item);
        return;
      }
    }
    Debug.Log("You have done a useless recipe!");
  }

  IEnumerator AddCommand(float t)
  {
    yield return new WaitForSeconds(t);
    commands.Add(recipes[Random.Range(0, recipes.Length)]);
    // Debug.Log("Add recipes: " + t);
    if (commands.Count < stackMax)
      StartCoroutine("AddCommand", Random.Range(rythmeMin, rythmeMax));
    else
      maxStackReached = true;
    // Debug.Log(commands.Count);
  }
}
