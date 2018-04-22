using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictoManager : MonoBehaviour {
	[SerializeField]
	private Sprite defaultSprite;
	[SerializeField]
	private Sprite[] pictograms;

	public int offsetRecipes = 0;

	public Sprite Get(int id)
	{
		if (id > pictograms.Length)
			return defaultSprite;
		return pictograms[id];
	}

	public Sprite GetRecipe(int recipeId)
	{
		int id = recipeId + offsetRecipes;
		if (id > pictograms.Length)
			return defaultSprite;
		return pictograms[id];
	}
}
