using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eOrderType
{
  MOVE,
};

public struct Order
{
  public eOrderType type;
  public Vector3 position;
}
