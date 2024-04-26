using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchScreenController : MonoBehaviour
{

  public GameObject ui;

  // Start is called before the first frame update
  void Start()
  {
    ShowUI();
  }

  // Update is called once per frame
  void Update()
  {
  }

  public void HideUI()
  {
 Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    ui.SetActive(false);
       

  }

  public void ShowUI()
  {
    ui.SetActive(true);
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
  }

   public void PressButton()
  {
    Debug.Log("press button");
    HideUI();
  }
}
