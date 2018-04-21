using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public float panSpeed = 20.0f;
	public float panBorderThickness = 10.0f;

	void Update () {
		Vector3 pos = transform.position;

		if (Input.mousePosition.z >= Screen.height - panBorderThickness)
			pos.y += panSpeed * Time.deltaTime;
		if (Input.mousePosition.y <= panBorderThickness)
			pos.y -= panSpeed * Time.deltaTime;
		if (Input.mousePosition.x >= Screen.width - panBorderThickness)
			pos.x += panSpeed * Time.deltaTime;
		if (Input.mousePosition.x <= panBorderThickness)
			pos.x -= panSpeed * Time.deltaTime;

		transform.position = pos;
		
	}
}
