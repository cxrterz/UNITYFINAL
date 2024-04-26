using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instagram : MonoBehaviour, IInteractable
{
  public string InteractionPrompt => "Install Instagram"; // Update prompt text

  public bool Interact(Interactor interactor)
  {
      var inventory = interactor.GetComponent<Inventory>();
      
      if (inventory == null)
      {
          Debug.LogWarning("Interactor doesn't have Inventory component!");
          return false;
      }

      if (!inventory.HasInstagram)
      {
          inventory.HasInstagram = true;
          Debug.Log("Installed Instagram!");
          Destroy(gameObject); // Destroy Instagram object on pickup
          return true;
      }
      
      Debug.Log("You already have Instagram installed.");
      return false;
  }
}
