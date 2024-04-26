using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private List<string> _storedItems = new List<string>(); // List of stored items
    [SerializeField] private List<GameObject> treesToActivateFirst; // List of trees to activate first
    [SerializeField] private List<GameObject> treesToActivateSecond; // List of trees to activate second
    [SerializeField] private List<GameObject> treesToActivateThird; // List of trees to activate third
     [SerializeField] private AudioSource successSound;
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
            ActivateTreesBasedOnCount();
        }
        else if (inventory.HasInstagram)
        {
            inventory.HasInstagram = false;
            _storedItems.Add("Instagram");
            ActivateTreesBasedOnCount();
        }
        else if (inventory.HasSnapchat)
        {
            inventory.HasSnapchat = false;
            _storedItems.Add("Snapchat");
            ActivateTreesBasedOnCount();
        }
    }

private void ActivateTreesBasedOnCount()
{
    int numItemsStored = _storedItems.Count;

    // Activate trees based on the number of items stored
    if (numItemsStored == 1)
    {
        foreach (GameObject tree in treesToActivateFirst)
        {
            tree.SetActive(true);
        }
    }
    else if (numItemsStored == 2)
    {
        foreach (GameObject tree in treesToActivateSecond)
        {
            tree.SetActive(true);
        }
    }
    else if (numItemsStored == 3)
    {
        foreach (GameObject tree in treesToActivateThird)
        {
            tree.SetActive(true);
        }
        // Play success sound
        successSound.Play();
    }
}
}
