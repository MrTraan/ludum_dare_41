using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Task))]
abstract public class IStation : ISelectable
{
	public Task task;
	public Camera cam;

	// public Sprite[] icons;

	public int maxWorkers = 1;
	[SerializeField]
	protected int currentWorkers = 0;

	// Use this for initialization
	protected override void Start()
	{
		base.Start();
		cam = Camera.main;
		task = GetComponent<Task>();
	}

	protected virtual void OnGUI()
	{
		if (task.running)
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
			OnNewWorker();
			return true;
		}
		return false;
	}

	public virtual void OnNewWorker() { }
	public virtual void OnLoseWorker() { }

	public virtual void RemoveWorker()
	{
		currentWorkers -= 1;
		if (currentWorkers < 0)
			currentWorkers = 0;
		OnLoseWorker();
	}
}
