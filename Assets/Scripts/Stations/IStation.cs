using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Task))]
abstract public class IStation : ISelectable
{
	public Task task;
	public Camera cam;

	private Slider slider;

	public int maxWorkers = 1;
	[SerializeField]
	protected int currentWorkers = 0;

	protected override void Start()
	{
		base.Start();
		cam = Camera.main;
		task = GetComponent<Task>();
		slider = GetComponentInChildren<Slider>();
	}

	protected override void Update()
	{
		base.Update();
		if (task.running)
		{
			slider.gameObject.SetActive(true);
			slider.value = task.completion / 100;
		}
		else
		{
			slider.gameObject.SetActive(false);
		}
	}

	protected virtual void OnGUI()
	{
		// if (task.running)
		// {
		// 	var position = cam.WorldToScreenPoint(transform.position);
		// 	position.y = Screen.height - position.y;
		// 	task.DrawProgressBar(position);
		// }
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
