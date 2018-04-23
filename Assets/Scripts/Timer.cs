using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
  private Text timerLabel;

  private float time;

  void Start()
  {
    timerLabel = GetComponent<Text>();
  }

  void Update()
  {
    time += Time.deltaTime;

    var minutes = time / 60;
    var seconds = time % 60;
    var fraction = (time * 100) % 100;

    timerLabel.text = string.Format("{0:00} : {1:00}", minutes, seconds);
  }

  public string GetCurrentTime()
  {
    var minutes = time / 60;
    var seconds = time % 60;
    var fraction = (time * 100) % 100;

    return string.Format("{0:00} : {1:00}", minutes, seconds);
  }
}
