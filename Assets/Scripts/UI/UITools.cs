using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UITools : MonoBehaviour
{

  public enum eScene
  {
    SPLASH,
    TUTO
  }

  public eScene scene = eScene.SPLASH;
  public Animation blackBackground;
  public GameObject text;

  public GameObject[] slides;
  private int currentSlide;

  public void Start()
  {
    currentSlide = 0;
    for (int i = 1; i < slides.Length; i++)
      slides[i].SetActive(false);
  }

  public void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      if (scene == eScene.SPLASH)
      {
        blackBackground.Play();
        text.SetActive(false);
        GetComponent<AudioSource>().Play();
        StartCoroutine("NextScene");
      }
      else if (scene == eScene.TUTO && currentSlide < slides.Length - 1)
      {
        slides[currentSlide].SetActive(false);
        currentSlide++;
        slides[currentSlide].SetActive(true);
      }
      else
      {
        blackBackground.Play();
        text.SetActive(false);
        // GetComponent<AudioSource>().Play();
        StartCoroutine("NextScene");
      }
    }

  }

  IEnumerator NextScene()
  {
    yield return new WaitForSeconds(2);
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
}
