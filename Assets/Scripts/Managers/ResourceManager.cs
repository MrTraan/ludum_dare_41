using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eResource
{
	CHICKEN,
	STEAK,
	FISH,
	CAROT,
	PEAS,
	POTATOES,

	T_CHICKEN,
	T_STEAK,
	T_FISH,
	T_CAROT,
	T_PEAS,
	T_POTATOES,

	GOLD,
};

public class ResourceManager : MonoBehaviour
{
	public int startingGold = 0;

	public int startingSteak = 0;
	public int startingFish = 0;
	public int startingChicken = 0;
	public int startingCarot = 0;
	public int startingPea = 0;
	public int startingPotato = 0;

	public int startingTSteak = 0;
	public int startingTFish = 0;
	public int startingTChicken = 0;
	public int startingTCarot = 0;
	public int startingTPea = 0;
	public int startingTPotato = 0;

	[SerializeField]
	private Dictionary<eResource, int> stock = new Dictionary<eResource, int>();

	private void Start()
	{
		stock[eResource.GOLD] = startingGold;
		stock[eResource.CHICKEN] = startingChicken;
		stock[eResource.STEAK] = startingSteak;
		stock[eResource.FISH] = startingFish;
		stock[eResource.PEAS] = startingPea;
		stock[eResource.CAROT] = startingCarot;
		stock[eResource.POTATOES] = startingPotato;

		stock[eResource.T_CHICKEN] = startingTChicken;
		stock[eResource.T_STEAK] = startingTSteak;
		stock[eResource.T_FISH] = startingTFish;
		stock[eResource.T_PEAS] = startingTPea;
		stock[eResource.T_CAROT] = startingTCarot;
		stock[eResource.T_POTATOES] = startingTPotato;
	}

	public int Get(eResource r)
	{
		return stock[r];
	}

	public int Add(eResource r, int amount)
	{
		stock[r] += amount;
		return stock[r];
	}

	public bool Consume(eResource r, int amount)
	{
		if (stock[r] >= amount)
		{
			stock[r] -= amount;
			return true;
		}
		return false;
	}

	public bool ConsumeForRecipe(Recipe recipe)
	{
		foreach (var i in recipe.ingredients)
		{
			if (stock[i.resource] < i.amount)
			{
				// Not enough ressource for this recipe
				return false;
			}
		}
		foreach (var i in recipe.ingredients)
			stock[i.resource] -= i.amount;
		return true;
	}

	public bool HasResourcesForRecipe(Recipe recipe)
	{
		foreach (var i in recipe.ingredients)
		{
			if (stock[i.resource] < i.amount)
				return false;
		}
		return true;
	}

	public bool HasResourcesForRecipe(int id)
	{
		return HasResourcesForRecipe(GameManager.recipeManager.GetRecipeById(id));
	}
}
