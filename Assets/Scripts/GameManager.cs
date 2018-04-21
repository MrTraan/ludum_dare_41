using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectionManager))]
public class GameManager : MonoBehaviour
{
	public static GameManager instance { get; private set; }

	public static SelectionManager selectionManager { get; private set; }

	void Awake()
	{
		instance = this;
		selectionManager = GetComponent<SelectionManager>();
	}

}
