using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef : ISelectable {
	private bool assigned = false;
	private IStation station;

	public override void HandleOrder(Order o)
	{
		if (GetComponent<Movable>() && o.type == eOrderType.MOVE)
		{
			if (assigned)
			{
				station.RemoveWorker();
			}
			GetComponent<Movable>().MoveTo(o.position);
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
			GetComponent<Movable>().MoveTo(o.position);
		}
	}
}
