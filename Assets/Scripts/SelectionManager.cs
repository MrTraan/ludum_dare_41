using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
	private bool isSelecting = false;
	private Vector3 mousePosition1;

	private Dictionary<int, Selectable> selectables = new Dictionary<int, Selectable>();

	public void AddSelectable(Selectable selectable)
	{
		selectables.Add(selectable.GetInstanceID(), selectable);
	}

	public void RemoveSelectable(Selectable selectable)
	{
		selectables.Remove(selectable.GetInstanceID());
	}

	void Update()
	{
		// If we press the left mouse button, save mouse location and begin selection
		if (Input.GetMouseButtonDown(0))
		{
			SelectUnitByClick();
			isSelecting = true;
			mousePosition1 = Input.mousePosition;
		}

		// If we let go of the left mouse button, end selection
		if (Input.GetMouseButtonUp(0))
		{
			foreach (var s in selectables.Values)
			{
				if (IsWithinSelectionBounds(s.gameObject))
					s.isSelected = true;
				else
					s.isSelected = false;
			}
			SelectUnitByClick();
			isSelecting = false;
		}
	}

	void OnGUI()
	{
		if (isSelecting)
		{
			// Create a rect from both mouse positions
			var rect = Utils.GetScreenRect(mousePosition1, Input.mousePosition);
			Utils.DrawScreenRectFill(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
			Utils.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f), 2);
		}
	}

	public bool IsWithinSelectionBounds(GameObject gameObject)
	{
		if (!isSelecting)
			return false;

		var camera = Camera.main;
		var viewportBounds =
			Utils.GetViewportBounds(camera, mousePosition1, Input.mousePosition);

		return viewportBounds.Contains(
			camera.WorldToViewportPoint(gameObject.transform.position));
	}

	public void SelectUnitByClick()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100, LayerMask.NameToLayer("Terrain")))
		{
			if (IsTagSelectable(hit.transform.tag))
				hit.transform.gameObject.GetComponent<Selectable>().isSelected = true;
		}
	}

	private bool IsTagSelectable(string tag)
	{
		if (tag == "Cook")
			return true;
		return false;
	}

	public void DispatchOrder(Order o)
	{
		foreach (var s in selectables.Values)
		{
			if (s.isSelected)
				s.HandleOrder(o);
		}
	}
}
