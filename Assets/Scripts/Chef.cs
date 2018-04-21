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

  protected override void Start()
  {
    base.Start();
    movable = GetComponent<Movable>();
  }

  protected override void Update()
  {
    base.Update();
    if (lastOrder == eOrderType.WORK && movable.hasReachedPosition)
    {
      if (targetStation.AssignWorker())
      {
        assigned = true;
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
        assigneStation.RemoveWorker();
      }
      movable.MoveTo(o.position);
    }

    if (o.type == eOrderType.WORK)
    {
      if (assigned)
      {
        assigneStation.RemoveWorker();
      }
      movable.MoveTo(o.position);
      targetStation = o.station;
    }
  }
}
