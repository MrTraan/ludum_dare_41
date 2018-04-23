using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eOrderType
{
	NONE,
	MOVE,
	WORK,
	COOK_RECIPE,
	ORDER,
	SEND_TRUCK,
};

public struct Order
{
	public eOrderType type;
	public Vector3 position;
	public IStation station;
	public int recipeId;
	public eResource resource;
	public int cost;
}
