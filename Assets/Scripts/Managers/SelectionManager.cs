using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
	private bool isSelecting = false;
	private Vector3 mousePosition1;

	private Dictionary<int, ISelectable> selectables = new Dictionary<int, ISelectable>();

	public void AddSelectable(ISelectable selectable)
	{
		selectables.Add(selectable.GetInstanceID(), selectable);
	}

	public void RemoveSelectable(ISelectable selectable)
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
				else if (!Input.GetKey(KeyCode.LeftShift))
					s.isSelected = false;
			}
			SelectUnitByClick();
			isSelecting = false;

			bool hasCookSelected = false;
			foreach (var s in selectables.Values)
			{
				if (s.gameObject.tag == "Cook" && s.isSelected)
				{
					hasCookSelected = true;
					break;
				}
			}

			if (hasCookSelected)
			{
				foreach (var s in selectables.Values)
				{
					if (s.gameObject.tag != "Cook")
						s.isSelected = false;
				}
			}

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
		if (Physics.Raycast(ray, out hit))
		{
			if (IsTagSelectable(hit.transform.tag))
				hit.transform.gameObject.GetComponent<ISelectable>().isSelected = true;
		}
	}

	private bool IsTagSelectable(string tag)
	{
		if (tag == "Cook" || tag == "Station")
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
