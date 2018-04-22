using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

  public Text gold;
  public Text vegetables;
  public Text meat;

  public GameObject recipePanel;
  private GameObject currentPanel;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    int goldAmount = GameManager.resourceManager.Get(eResource.GOLD);
    gold.text = "Gold: " + goldAmount.ToString();
    int meatAmount = GameManager.resourceManager.Get(eResource.MEAT);
    meat.text = "Meat: " + meatAmount.ToString();
    int vegetablesAmount = GameManager.resourceManager.Get(eResource.VEGETABLES);
    vegetables.text = "Vegetables: " + vegetablesAmount.ToString();
  }

  public void ShowPanel(GameObject panel)
  {
    if (panel != currentPanel)
      return;

    currentPanel.SetActive(false);
    currentPanel = panel;
    currentPanel.SetActive(true);
    // panel.SetActive(true);
  }

  public void HidePanel()
  {
    if (currentPanel)
      currentPanel.SetActive(false);
    currentPanel = null;
  }


}
