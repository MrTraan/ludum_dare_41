using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformStation : IStation
{
	public eResource inputResource = eResource.GOLD;
	public int inputAmount = 1;
	public eResource outpoutResource = eResource.CHICKEN;
	public int outputAmount = 1;

	public Sprite[] spritePerWorker;

	private SpriteRenderer sr;

	public override void HandleOrder(Order o)
	{
	}

	protected override void Start()
	{
		base.Start();
		AttributeIcon();
		sr = transform.GetChild(1).GetComponent<SpriteRenderer>();
		if (spritePerWorker.Length < maxWorkers)
			Debug.LogWarning("Warning ! Missing sprites for transform station");
	}

	protected override void Update()
	{
		base.Update();
		if (task.running && task.IsCompleted())
		{
			GameManager.resourceManager.Add(outpoutResource, outputAmount);
			task.Reset();
		}
		else if (task.running)
		{
			task.Progress(currentWorkers * 1.0f);
		}
		if (!task.running && currentWorkers > 0 && GameManager.resourceManager.Consume(inputResource, inputAmount))
		{
			task.Begin();
			sr.sprite = spritePerWorker[currentWorkers];
		}
		else if (!task.running)
		{
			sr.sprite = spritePerWorker[0];
		}

	}

	public override void OnNewWorker()
	{
		sr.sprite = spritePerWorker[currentWorkers];
	}

	public override void OnLoseWorker()
	{
		sr.sprite = spritePerWorker[currentWorkers];
	}

	private void AttributeIcon()
	{
		SpriteRenderer[] sr = GetComponentsInChildren<SpriteRenderer>();

		foreach (SpriteRenderer item in sr)
		{
			if (item.name == "Icon")
			{
				item.sprite = GameManager.pictoManager.GetTransformed((int)outpoutResource);
			}
		}
	}
}
