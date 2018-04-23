using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movable))]
public class Chef : ISelectable
{
	private bool assigned = false;
	private IStation assigneStation;
	private IStation targetStation;

	private Movable movable;
	[SerializeField]
	private eOrderType lastOrder = eOrderType.NONE;
	private Animator animator;

	protected override void Start()
	{
		base.Start();
		movable = GetComponent<Movable>();
		animator = GetComponentInChildren<Animator>();
	}

	protected override void Update()
	{
		base.Update();
		if (lastOrder == eOrderType.WORK && movable.hasReachedPosition)
		{
			if (targetStation.AssignWorker())
			{
				assigned = true;
				animator.SetTrigger("StartWork");
				assigneStation = targetStation;
			}
			lastOrder = eOrderType.NONE;
		}

	}

	public override void HandleOrder(Order o)
	{
		lastOrder = o.type;
		if (o.type == eOrderType.MOVE)
		{
			if (assigned)
			{
				assigned = false;
				assigneStation.RemoveWorker();
				animator.SetTrigger("StopWork");
			}
			movable.MoveTo(o.position);
		}

		if (o.type == eOrderType.WORK)
		{
			if (assigned)
			{
				assigned = false;
				assigneStation.RemoveWorker();
			}
			movable.MoveTo(o.position);
			targetStation = o.station;
		}
	}
}
