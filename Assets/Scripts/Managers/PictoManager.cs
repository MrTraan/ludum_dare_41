using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictoManager : MonoBehaviour
{
	[SerializeField]
	private Sprite defaultSprite;
	[SerializeField]
	private Sprite[] recipe;
	[SerializeField]
	private Sprite[] resourceIcon;

	public Sprite GetRecipe(int id)
	{
		if (id > recipe.Length)
			return defaultSprite;
		return recipe[id];
	}
	public Sprite GetTransformed(int id)
	{
		if (id > resourceIcon.Length)
			return defaultSprite;
		return resourceIcon[id];
	}

	public Sprite GetResource(eResource resource)
	{
		int id = (int)resource;
		if (id > resourceIcon.Length)
			return defaultSprite;
		return resourceIcon[id];
	}
}
