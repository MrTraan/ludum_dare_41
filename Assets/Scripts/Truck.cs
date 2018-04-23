using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : IStation
{

	public enum eState
	{
		TRAVEL,
		UNLOADING,
		EMPTY,
	}

	public eState state = eState.EMPTY;
	public float travelTime = 30;

	private Animator animator;
	private Dictionary<eResource, int> stock = new Dictionary<eResource, int>();

	protected override void Start()
	{
		base.Start();
		animator = GetComponentInChildren<Animator>();
		animator.SetTrigger("Arrive");
	}

	protected override void Update()
	{
		base.Update();


		if (state == eState.UNLOADING && task.IsCompleted())
		{
			foreach (var command in stock)
				GameManager.resourceManager.Add(command.Key, command.Value);
			task.Reset();
			state = eState.EMPTY;
			Reset();
		}
		else if (state == eState.UNLOADING)
		{
			task.Progress(currentWorkers * 1.0f);
		}
	}

	public void GoShopping(Dictionary<eResource, int> shoppingList)
	{
		stock = new Dictionary<eResource, int>(shoppingList);
		StartCoroutine("Travel");
		animator = GetComponentInChildren<Animator>();
	}

	public override TaskLayout GetTaskLayout()
	{
		TaskLayout layout = new TaskLayout();
		layout.type = eTaskLayoutType.TRUCK_ORDER;
		layout.truckOrder = stock;

		return layout;
	}


	IEnumerator Travel()
	{
		animator.SetTrigger("Leave");
		state = eState.TRAVEL;

		yield return new WaitForSeconds(travelTime);

		state = eState.UNLOADING;
		animator.SetTrigger("Arrive");
		task.Begin();
	}

	public override void HandleOrder(Order o)
	{
	}

	public void Reset()
	{
		stock[eResource.FISH] = 0;
		stock[eResource.STEAK] = 0;
		stock[eResource.CHICKEN] = 0;
		stock[eResource.PEAS] = 0;
		stock[eResource.CAROT] = 0;
		stock[eResource.POTATOES] = 0;
	}
}
