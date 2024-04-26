using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour, IInteractable
{
  public string InteractionPrompt => "Pick Up Phone";

  public bool Interact(Interactor interactor)
  {
      var inventory = interactor.GetComponent<Inventory>();
      
      if (inventory == null)
      {
          Debug.LogWarning("Interactor doesn't have Inventory component!");
          return false;
      }

      if (!inventory.HasPhone) // Check for phone in inventory
      {
          inventory.HasPhone = true; // Set phone flag in inventory
          Debug.Log("Picked up Phone!");
          Destroy(gameObject); // Destroy phone object on pickup
          return true;
      }
      
      Debug.Log("You already have the phone.");
      return false;
  }
}
