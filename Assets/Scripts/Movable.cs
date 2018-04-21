using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movable : MonoBehaviour
{
  private NavMeshAgent agent;
  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
  }

  public void MoveTo(Vector3 position)
  {
    agent.SetDestination(position);
  }
}
