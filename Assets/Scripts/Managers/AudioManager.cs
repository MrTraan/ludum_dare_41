﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

  public AudioClip[] talks;
  public static AudioManager instance { get; private set; }

  void Awake()
  {
    instance = this;
  }

  public AudioClip GetRandomTalk()
  {
    int r = Random.Range(0, talks.Length);
    return talks[r];
  }
}
