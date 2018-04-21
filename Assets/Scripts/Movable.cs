using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movable : MonoBehaviour
{
  private NavMeshAgent agent;
  private Animator animator;
  public bool hasReachedPosition = true;
  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    animator = GetComponentInChildren<Animator>();
  }

  void Update()
  {
    transform.forward = Vector3.forward;
    CheckMovement();
  }

  public void MoveTo(Vector3 position)
  {
    agent.SetDestination(position);
    Vector3 dir = transform.position - position;
    SetFacingDirection(dir);
    hasReachedPosition = false;
  }

  private void CheckMovement()
  {
    if (!agent.pathPending)
    {
      if (agent.remainingDistance <= agent.stoppingDistance)
      {
        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
        {
          animator.SetInteger("FacingDirection", 4);
          hasReachedPosition = true;
        }
      }
    }
  }

  private void SetFacingDirection(Vector3 dir)
  {
    float angle = Vector3.SignedAngle(dir, Vector3.forward, Vector3.up);
    if (angle > -135 && angle < -45)
      animator.SetInteger("FacingDirection", 0);
    else if (angle > -45 && angle < 45)
      animator.SetInteger("FacingDirection", 1);
    else if (angle > 45 && angle < 135)
      animator.SetInteger("FacingDirection", 2);
    else
      animator.SetInteger("FacingDirection", 3);
  }
}
