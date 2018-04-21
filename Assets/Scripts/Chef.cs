using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movable))]
public class Chef : ISelectable {
	private bool assigned = false;
	private IStation station;

	private Movable movable;

	protected override void Start()
	{
		base.Start();
		movable = GetComponent<Movable>();
	}


	public override void HandleOrder(Order o)
	{
		
		if (o.type == eOrderType.MOVE)
		{
			if (assigned)
			{
				station.RemoveWorker();
			}
			movable.MoveTo(o.position);
		}

		if (o.type == eOrderType.WORK)
		{
			if (assigned)
			{
				station.RemoveWorker();
			}
			if (o.station.AssignWorker())
			{
				assigned = true;
				station = o.station;
			}
			movable.MoveTo(o.position);
		}
	}
}
