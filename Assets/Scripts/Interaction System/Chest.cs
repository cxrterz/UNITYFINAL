using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private List<string> _storedItems = new List<string>(); // List of stored items
    [SerializeField] private List<GameObject> treesToActivate; // List of trees to activate

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        // Check for specific items in inventory
        var inventory = interactor.GetComponent<Inventory>();
        if (inventory == null)
        {
            Debug.LogWarning("Interactor doesn't have Inventory component!");
            
            return false;
        }

 if (CanStoreItem(inventory))
    {
        StoreItem(inventory);
        Debug.Log("Stored item in chest!");

        // Activate the trees
        foreach (GameObject tree in treesToActivate)
        {
            tree.SetActive(true);
        }

        return true;
    }
    else
    {
        Debug.Log("No suitable items found in inventory to store.");
        return false;
    }
}

    private bool CanStoreItem(Inventory inventory)
    {
        // Check if player has phone, Instagram, or Snapchat
        return inventory.HasPhone || inventory.HasInstagram || inventory.HasSnapchat;
    }

    private void StoreItem(Inventory inventory)
    {
        // Update inventory and chest state based on stored item type
        if (inventory.HasPhone)
        {
            inventory.HasPhone = false;
            _storedItems.Add("Phone");
        }
        else if (inventory.HasInstagram)
        {
            inventory.HasInstagram = false;
            _storedItems.Add("Instagram");
        }
        else if (inventory.HasSnapchat)
        {
            inventory.HasSnapchat = false;
            _storedItems.Add("Snapchat");
        }
    }
}