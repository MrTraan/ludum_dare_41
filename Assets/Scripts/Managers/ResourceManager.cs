using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eResource
{
	GOLD,
	VEGETABLES,
	MEAT,
};

public class ResourceManager : MonoBehaviour
{
	public int startingGold = 0;
	public int startingVegetables = 0;
	public int startingMeat = 0;
	[SerializeField]
	private Dictionary<eResource, int> stock = new Dictionary<eResource, int>();

	private void Start()
	{
		stock[eResource.GOLD] = startingGold;
		stock[eResource.VEGETABLES] = startingVegetables;
		stock[eResource.MEAT] = startingMeat;
		
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
}
