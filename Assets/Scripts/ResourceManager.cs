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
	[SerializeField]
	private Dictionary<eResource, int> stock = new Dictionary<eResource, int>();

	private void Start()
	{
		stock[eResource.GOLD] = 0;
		stock[eResource.VEGETABLES] = 0;
		stock[eResource.MEAT] = 1000;
		
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
