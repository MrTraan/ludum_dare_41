using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UITools : MonoBehaviour
{

  public Animation blackBackground;
  public GameObject text;

  public void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      blackBackground.Play();
      text.SetActive(false);
      GetComponent<AudioSource>().Play();
      StartCoroutine("WaitFadeOut");
    }

  }
  public void NextScene()
  {
    // Debug.Log("Next Scene");
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  IEnumerator WaitFadeOut()
  {
    yield return new WaitForSeconds(2);
    NextScene();
  }
}
