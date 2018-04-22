using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderStation : ISelectable
{
  private Dictionary<eResource, int> orderedResources = new Dictionary<eResource, int>();

  protected override void Start()
  {
    base.Start();
    Reset();
  }

  static Order[] orders = {
    new Order { type = eOrderType.ORDER, resource = eResource.FISH, cost = 10 },
    new Order { type = eOrderType.ORDER, resource = eResource.STEAK, cost = 10 },
  };

  public override void HandleOrder(Order o)
  {
    if (o.type == eOrderType.ORDER)
    {
      if (GameManager.resourceManager.Consume(eResource.GOLD, o.cost))
        orderedResources[o.resource]++;
    }
  }

  public override Order[] GetOrderPanel()
  {
    return orders;
  }

  public Dictionary<eResource, int> GetOrderedResources()
  {
    return orderedResources;
  }

  public void Reset()
  {
    orderedResources[eResource.FISH] = 0;
    orderedResources[eResource.STEAK] = 0;
  }
}
