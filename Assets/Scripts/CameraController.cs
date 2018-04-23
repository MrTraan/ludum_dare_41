using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  public float panSpeed = 20.0f;
  public float panBorderThickness = 10.0f;

  public float leftBound = 0;
  public float rightBound = 0;
  public float topBound = 0;
  public float bottomBound = 0;

  void Update()
  {
    Vector3 pos = transform.position;



    if (Input.mousePosition.y >= Screen.height - panBorderThickness && pos.z < topBound)
      pos.z += panSpeed * Time.deltaTime;
    if (Input.mousePosition.y <= panBorderThickness && pos.z > bottomBound)
      pos.z -= panSpeed * Time.deltaTime;
    if (Input.mousePosition.x >= Screen.width - panBorderThickness && pos.x < rightBound)
      pos.x += panSpeed * Time.deltaTime;
    if (Input.mousePosition.x <= panBorderThickness && pos.x > leftBound)
      pos.x -= panSpeed * Time.deltaTime;

    transform.position = pos;

  }

}
