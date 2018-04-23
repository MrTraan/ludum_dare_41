using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UITools : MonoBehaviour
{

  public void NextScene()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Debug.Log("Next Scene");
      // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
  }
}
