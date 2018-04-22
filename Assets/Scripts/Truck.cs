using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : IStation
{

	public enum eState
	{
		TRAVEL,
		UNLOADING,
	}

	public float travelTime = 30;
	public eState state = eState.TRAVEL;
	private Dictionary<eResource, int> stock = new Dictionary<eResource, int>();
	private float denre = 100;
	private Animator animator;

	protected override void Start()
	{
		base.Start();
		StartCoroutine("Travel");
		animator = GetComponentInChildren<Animator>();
	}

	protected override void Update()
	{
		base.Update();


		if (state == eState.UNLOADING && CheckEmptyness())
		{
			task.Reset();
			state = eState.TRAVEL;
			StartCoroutine("Travel");
			animator.SetTrigger("Leave");
		}
		else if (state == eState.UNLOADING)
		{
			denre -= 0.1f * currentWorkers;
			task.completion = 100 - denre;
		}
	}

	private bool CheckEmptyness()
	{
		// foreach (var command in stock)
		// {
		//   if (command.Value != 0)
		//     return false;
		// }
		// return true;
		if (denre < 0)
			return true;
		return false;
	}

	private void GetOrder()
	{
		// stock = GameManager.resourceManager.GetOrder();
		denre = 100;
		task.Begin();
	}

	IEnumerator Travel()
	{
		yield return new WaitForSeconds(travelTime);
		GetOrder();
		state = eState.UNLOADING;
		animator.SetTrigger("Arrive");
	}

	public override void HandleOrder(Order o)
	{
	}
}
