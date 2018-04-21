using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Task))]
abstract public class IStation : MonoBehaviour {
	public Task task;
	public Camera cam;

	public int maxWorkers = 0;
	[SerializeField]
	private int currentWorkers = 0;

	// Use this for initialization
	virtual protected void Start () {
		cam = Camera.main;
		task = GetComponent<Task>();
	}
	
	virtual protected void Update () {
		if (!task.IsCompleted())
			// Each worker has 1 work force for now
			task.Progress(currentWorkers * 1.0f);
	}

	virtual protected void OnGUI()
	{
		if (task.completion > 0.0f && task.completion < 100.0f)
		{
			var position = cam.WorldToScreenPoint(transform.position);
			position.y = Screen.height - position.y;
			task.DrawProgressBar(position);
		}
	}

	// returns false if station is full
	virtual public bool AssignWorker()
	{
		if (currentWorkers < maxWorkers)
		{
			currentWorkers++;
			return true;
		}
		return false;
	}

	virtual public void RemoveWorker()
	{
		currentWorkers -= 1;
		if (currentWorkers < 0)
			currentWorkers = 0;
	}

}
