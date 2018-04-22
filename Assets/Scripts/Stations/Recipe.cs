using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
	public class Ingredient
	{
		public Ingredient(eResource r, int a)
		{
			resource = r;
			amount = a;
		}
		public eResource resource;
		public int amount;
	}

	public List<Ingredient> ingredients = new List<Ingredient>();
	public string name;
	public int id;
}
