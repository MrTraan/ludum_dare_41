using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Task))]
public class CookingStation : MonoBehaviour {
	public Camera cam;
	public Task task;

	// Use this for initialization
	void Start () {
		task = GetComponent<Task>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!task.IsCompleted())
			task.Progress();
	}

	private void OnGUI()
	{
		var position = cam.WorldToScreenPoint(transform.position);
		position.y = Screen.height - position.y;
		task.DrawProgressBar(position);
	}
}
