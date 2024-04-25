using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private GameObject[] objectsToActivate; // Array of objects to activate/deactivate on interaction

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        // Toggle the activation state of all objects in the array
        foreach (var obj in objectsToActivate)
        {
            obj.SetActive(!obj.activeInHierarchy);
        }

        Debug.Log("Lever Pulled!");
        return true;
    }
}