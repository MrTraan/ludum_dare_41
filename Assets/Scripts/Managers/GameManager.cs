using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectionManager))]
[RequireComponent(typeof(ResourceManager))]
[RequireComponent(typeof(RecipeManager))]
[RequireComponent(typeof(UIManager))]
[RequireComponent(typeof(PictoManager))]
public class GameManager : MonoBehaviour
{
  public static GameManager instance { get; private set; }

  public static SelectionManager selectionManager { get; private set; }

  public static ResourceManager resourceManager { get; private set; }

  public static RecipeManager recipeManager { get; private set; }

  public static UIManager uiManager { get; private set; }

  public static PictoManager pictoManager { get; private set; }

  public int recipeTarget = 30;

  void Awake()
  {
    instance = this;
    selectionManager = GetComponent<SelectionManager>();
    resourceManager = GetComponent<ResourceManager>();
    recipeManager = GetComponent<RecipeManager>();
    uiManager = GetComponent<UIManager>();
    pictoManager = GetComponent<PictoManager>();
  }

  private void Update()
  {
    int order = -1;

    if (Input.GetButtonDown("Order1"))
      order = 0;
    if (Input.GetButtonDown("Order2"))
      order = 1;
    if (Input.GetButtonDown("Order3"))
      order = 2;
    if (Input.GetButtonDown("Order4"))
      order = 3;
    if (Input.GetButtonDown("Order5"))
      order = 4;
    if (Input.GetButtonDown("Order6"))
      order = 5;
    if (Input.GetButtonDown("Order7"))
      order = 6;
    if (Input.GetButtonDown("Order8"))
      order = 7;
    if (Input.GetButtonDown("Order9"))
      order = 8;

    if (Input.GetKeyDown(KeyCode.Escape))
    {
      uiManager.SwitchMainMenu();
    }


    if (order != -1)
      selectionManager.DispatchOrderButtonClick(order);

    if (Input.GetMouseButtonUp(1))
    {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      Order o = new Order();
      if (Physics.Raycast(ray, out hit))
      {
        if (hit.transform.tag == "Station")
        {
          o.type = eOrderType.WORK;
          o.position = hit.point;
          o.station = hit.transform.gameObject.GetComponent<IStation>();
          selectionManager.DispatchOrder(o);
        }
        else if (hit.transform.tag == "Truck")
        {
          if (hit.transform.gameObject.GetComponent<Truck>().state == Truck.eState.UNLOADING)
          {
            o.type = eOrderType.WORK;
            o.position = hit.point;
            o.station = hit.transform.gameObject.GetComponent<IStation>();
            selectionManager.DispatchOrder(o);
          }
          else
          {
            o.type = eOrderType.MOVE;
            o.position = hit.point;
            selectionManager.DispatchOrder(o);
          }
        }
        else
        {
          o.type = eOrderType.MOVE;
          o.position = hit.point;
          selectionManager.DispatchOrder(o);
        }
      }
    }
  }

  public static void Win()
  {
    uiManager.DisplayWinMenu();
  }

}
