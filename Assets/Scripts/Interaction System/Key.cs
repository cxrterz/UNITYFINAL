using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();
        
        if (inventory == null)
        {
            Debug.LogWarning("Interactor doesn't have Inventory component!");
            return false;
        }

        if (!inventory.HasKey)
        {
            inventory.HasKey = true;
            Debug.Log("Picked up Key!");
            Destroy(gameObject); // Destroy the key object on pickup
            return true;
        }
        
        Debug.Log("You already have the key.");
        return false;
    }
}
