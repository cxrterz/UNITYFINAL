using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapchat : MonoBehaviour, IInteractable
{
  public string InteractionPrompt => "(E) Take Snapchat";

  public bool Interact(Interactor interactor)
  {
      var inventory = interactor.GetComponent<Inventory>();
      
      if (inventory == null)
      {
          Debug.LogWarning("Interactor doesn't have Inventory component!");
          return false;
      }

      if (!inventory.HasSnapchat)
      {
          inventory.HasSnapchat = true;
          Debug.Log("Took Snapchat");
          Destroy(gameObject);
          return true;
      }
      
      Debug.Log("You already have Snapchat");
      return false;
  }
}
