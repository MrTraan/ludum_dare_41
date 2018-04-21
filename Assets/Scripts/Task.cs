using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour {
	public float completion = 0;
	public float step = 0.1f;
	public bool running = false;

	public float progressBarWidth = 20.0f;
	public float progressBarHeight = 5.0f;
	public float progressBarBorderSize = 2.0f;
	public Color progressBarColor = Color.green;
	public Color progressBarBorderColor = Color.blue;

	public void Progress(float modifier = 1)
	{
		completion += step * modifier;
		if (completion > 100.0f)
			completion = 100.0f;
	}

	public void Begin()
	{
		completion = 0;
		running = true;
	}

	public void Reset()
	{
		completion = 0;
		running = false;
	}

	public bool IsCompleted()
	{
		return completion >= 100.0f;
	}

	public void DrawProgressBar(Vector3 position)
	{
		Utils.DrawScreenRect(new Rect(
			position.x - progressBarBorderSize, position.y - progressBarBorderSize,
			progressBarWidth + 2 * progressBarBorderSize, progressBarHeight + 2 * progressBarBorderSize),
			progressBarBorderColor, progressBarBorderSize);
		Utils.DrawScreenRectFill(new Rect(position.x, position.y,
			progressBarWidth * (completion / 100), progressBarHeight),
			progressBarColor);
	}
}
