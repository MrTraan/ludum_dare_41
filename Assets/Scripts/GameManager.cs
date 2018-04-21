using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterSelection))]
public class GameManager : MonoBehaviour
{
	public static GameManager instance { get; private set; }

	public static CharacterSelection selectionManager { get; private set; }

	void Awake()
	{
		instance = this;
		selectionManager = GetComponent<CharacterSelection>();
	}

}
