using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movable : MonoBehaviour
{
  public float notMovingTreshold = 0.1f;
  private NavMeshAgent agent;
  private Animator animator;
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
    animator.SetBool("IsMoving", true);
    SetFacingDirection(dir);
  }

  private void CheckMovement()
  {
    float velocity = agent.velocity.magnitude;
    if (velocity < notMovingTreshold)
      animator.SetBool("IsMoving", false);
  }

  private void SetFacingDirection(Vector3 dir)
  {
    float angle = Vector3.SignedAngle(dir, Vector3.forward, Vector3.up);
    Debug.Log(angle);
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
