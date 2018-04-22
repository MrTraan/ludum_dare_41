using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eOrderType
{
	NONE,
	MOVE,
	WORK,
	COOK_RECIPE,
};

public class Order
{
	public eOrderType type;
	public Vector3 position;
	public IStation station;
	public int recipeId;

	public Order() { type = eOrderType.NONE; }

	public Order(eOrderType t, int id) { type = t; recipeId = id; }
}
