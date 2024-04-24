using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private bool isOpen = false;
    [SerializeField] private Vector3 openRotation = new Vector3(0, 90, 0); // Adjust as needed
    [SerializeField] private float rotationSpeed = 90f; // Degrees per second

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.GetComponent<Inventory>();
        
        if (inventory == null) return false;
        
        if (inventory.HasKey)
        {
            StartCoroutine(AnimateDoor(!isOpen)); // Toggle the door's open state
            return true;
        }
        
        Debug.Log("No Key Found");
        return false;
    }

    private IEnumerator AnimateDoor(bool opening)
    {
        isOpen = opening;
        var endRotation = isOpen ? Quaternion.Euler(openRotation) : Quaternion.identity;
        var startRotation = transform.rotation;

        float time = 0f;
        while (time < 1f)
        {
            time += Time.deltaTime * rotationSpeed / openRotation.magnitude;
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
        }

        // Ensure the final rotation is set exactly to prevent small discrepancies due to frame rates
        transform.rotation = endRotation;

        Debug.Log(isOpen ? "Door opened." : "Door closed.");
    }
}
