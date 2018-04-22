using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

  public static AudioManager instance { get; private set; }

  void Awake()
  {
    instance = this;
  }
}
