using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceManager : MonoBehaviour {
	[SerializeField]
	private int gold = 0;

	public int GetGold()
	{
		return gold;
	}

	public void AddGold(int amount)
	{
		gold += amount;
	}

	public bool ComsumeGold(int amount)
	{
		if (gold < amount)
			return false;
		gold -= amount;
		return true;
	}
}
