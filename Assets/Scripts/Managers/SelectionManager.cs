using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
  private bool isSelecting = false;
  private Vector3 mousePosition1;
  private bool mouseIsOver = false;

  private Dictionary<int, ISelectable> selectables = new Dictionary<int, ISelectable>();

  public void AddSelectable(ISelectable selectable)
  {
    selectables.Add(selectable.gameObject.GetInstanceID(), selectable);
  }

  public void RemoveSelectable(ISelectable selectable)
  {
    selectables.Remove(selectable.gameObject.GetInstanceID());
  }

  void Update()
  {
    // If we press the left mouse button, save mouse location and begin selection
    if (Input.GetMouseButtonDown(0))
    {
      isSelecting = true;
      mousePosition1 = Input.mousePosition;
    }

    // If we let go of the left mouse button, end selection
    if (Input.GetMouseButtonUp(0))
    {
      bool hasCookSelected = false;
      List<int> underSelection = new List<int>();

      foreach (var s in selectables.Values)
      {
        if (IsWithinSelectionBounds(s.gameObject))
        {
          if (s.gameObject.tag == "Cook")
            hasCookSelected = true;
          underSelection.Add(s.gameObject.GetInstanceID());
        }
      }

      int underMouse = UnitUnderMouseId();
      if (underMouse != 0)
      {
        if (selectables[underMouse].gameObject.tag == "Cook")
          hasCookSelected = true;
        underSelection.Add(underMouse);
      }

      if (!Input.GetKey(KeyCode.LeftShift) && underSelection.Count > 0)
        DeselectAll();

      foreach (int id in underSelection)
      {
        if (hasCookSelected)
        {
          if (selectables[id].gameObject.tag != "Cook")
            selectables[id].isSelected = false;
          else
            selectables[id].isSelected = true;
        }
        else
        {
          selectables[id].isSelected = true;
          break;
        }
      }

      if (hasCookSelected)
      {
        AudioSource audio = AudioManager.instance.GetComponent<AudioSource>();
        audio.clip = AudioManager.instance.GetRandomTalk();
        audio.Play();
      }

      isSelecting = false;
      GameManager.uiManager.UpdateOrderPanel(GetCurrentOrderPanel());
    }
    GameManager.uiManager.UpdateTaskPanel(GetCurrentTaskLayout());
  }

  void OnGUI()
  {
    if (isSelecting)
    {
      // Create a rect from both mouse positions
      var rect = Utils.GetScreenRect(mousePosition1, Input.mousePosition);
      Utils.DrawScreenRectFill(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
      Utils.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f), 2);
    }
  }

  public bool IsWithinSelectionBounds(GameObject gameObject)
  {
    if (!isSelecting)
      return false;

    var camera = Camera.main;
    var viewportBounds =
      Utils.GetViewportBounds(camera, mousePosition1, Input.mousePosition);

    return viewportBounds.Contains(
      camera.WorldToViewportPoint(gameObject.transform.position));
  }

  public void SelectUnitByClick()
  {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit))
    {
      if (IsTagSelectable(hit.transform.tag))
        hit.transform.gameObject.GetComponent<ISelectable>().isSelected = true;
    }
  }

  public int UnitUnderMouseId()
  {
    if (mouseIsOver)
      return 0;

    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit))
    {
      if (IsTagSelectable(hit.transform.tag))
        return hit.transform.gameObject.GetInstanceID();
    }
    return 0;
  }

  private bool IsTagSelectable(string tag)
  {
    if (tag == "Cook" || tag == "Station" || tag == "Truck" || tag == "OrderStation")
      return true;
    return false;
  }

  public void DispatchOrder(Order o)
  {
    foreach (var s in selectables.Values)
    {
      if (s.isSelected)
        s.HandleOrder(o);
    }
  }

  public void DeselectAll()
  {
    foreach (var s in selectables.Values)
      s.isSelected = false;
  }

  public Order[] GetCurrentOrderPanel()
  {
    foreach (var s in selectables.Values)
    {
      if (s.isSelected)
        return s.GetOrderPanel();
    }
    return (new Order[0]);
  }

  public TaskLayout GetCurrentTaskLayout()
  {
    foreach (var s in selectables.Values)
    {
      if (s.isSelected && s.tag == "Cook")
        return ChefSelectionLayout();
      if (s.isSelected)
        return s.GetTaskLayout();
    }
    return (ISelectable.defaultLayout);
  }

  public TaskLayout ChefSelectionLayout()
  {
    TaskLayout layout = new TaskLayout();
    layout.type = eTaskLayoutType.MULTI_SELECTION;

    int chefCount = 0;
    foreach (var s in selectables.Values)
    {
      if (s.isSelected && s.tag == "Cook")
        chefCount++;
    }

    layout.pictograms = new Sprite[chefCount];
    int i = 0;
    foreach (var s in selectables.Values)
    {
      if (s.isSelected && s.tag == "Cook")
      {
        layout.pictograms[i] = s.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
        i++;
      }
    }
    return layout;
  }

  public void DispatchOrderButtonClick(int id)
  {
    Order[] orders = GetCurrentOrderPanel();
    if (id >= orders.Length)
      return;
    DispatchOrder(orders[id]);
  }

  public void MouseOverEnter()
  {
    Debug.Log("Enter");
    mouseIsOver = true;
  }

  public void MouseOverExit()
  {
    Debug.Log("Leave");
    mouseIsOver = false;
  }
}
