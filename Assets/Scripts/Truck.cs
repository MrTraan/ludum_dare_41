using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{

  private enum eState
  {
    TRAVEL,
    UNLOADING,
  }

  public float travelTime = 30;
  private eState state = eState.TRAVEL;
  private Dictionary<eResource, int> stock = new Dictionary<eResource, int>();
  private float denre = 100;
  private Animator animator;

  public void Start()
  {
    StartCoroutine("Travel");
    animator = GetComponent<Animator>();
  }

  public void Update()
  {
    Debug.Log(state);
    if (state == eState.UNLOADING && CheckEmptyness())
    {
      state = eState.TRAVEL;
      StartCoroutine("Travel");
      animator.SetTrigger("Leave");
    }
    else if (state == eState.UNLOADING)
    {
      denre -= 0.5f;
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
  }

  IEnumerator Travel()
  {
    yield return new WaitForSeconds(travelTime);
    GetOrder();
    state = eState.UNLOADING;
    animator.SetTrigger("Arrive");
  }

}
