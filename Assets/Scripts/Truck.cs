using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{

  private Dictionary<eResource, int> stock = new Dictionary<eResource, int>();

  private void GetOrder()
  {
    stock = GameManager.resourceManager.GetOrder();
  }
}
