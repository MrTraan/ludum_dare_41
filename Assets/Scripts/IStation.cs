using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Task))]
abstract public class IStation : ISelectable {
	public Task task;
	public Camera cam;

	public int maxWorkers = 0;
	[SerializeField]
	private int currentWorkers = 0;

	// Use this for initialization
	protected override void Start () {
		base.Start();
		cam = Camera.main;
		task = GetComponent<Task>();
	}
	
	protected virtual void Update () {
		if (!task.IsCompleted())
			// Each worker has 1 work force for now
			task.Progress(currentWorkers * 1.0f);
		else
		{
			OnProduction();
			task.Reset();
		}
	}

	protected virtual void OnGUI()
	{
		if (task.completion > 0.0f && task.completion < 100.0f)
		{
			var position = cam.WorldToScreenPoint(transform.position);
			position.y = Screen.height - position.y;
			task.DrawProgressBar(position);
		}
	}

	// returns false if station is full
	public virtual bool AssignWorker()
	{
		if (currentWorkers < maxWorkers)
		{
			currentWorkers++;
			return true;
		}
		return false;
	}

	public virtual void RemoveWorker()
	{
		currentWorkers -= 1;
		if (currentWorkers < 0)
			currentWorkers = 0;
	}

	protected virtual void OnProduction() { }

}
