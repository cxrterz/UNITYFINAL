using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; // Assuming you're using TextMeshPro

public class Interactor : MonoBehaviour
{
  [SerializeField] private Transform _interactionPoint;
  [SerializeField] private float _interactionPointRadius = 0.5f;
  [SerializeField] private LayerMask _interactableMask;
  [SerializeField] private InteractionPromptUI _interactionPromptUI;
  private readonly Collider[] _colliders = new Collider[3];
  [SerializeField] private int _numFound;

  private IInteractable _interactable;

  private void Update()
  {
    _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, (int)_interactableMask);

    if (_numFound > 0)
    {
      _interactable = _colliders[0].GetComponent<IInteractable>();

      if (_interactable != null)
      {
        if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.SetUp(_interactable.InteractionPrompt);
      }
    }
    else // No interactable object found, hide UI
    {
      _interactable = null;
      if (_interactionPromptUI.IsDisplayed) _interactionPromptUI.Close();
    }

    if (Keyboard.current.eKey.wasPressedThisFrame && _interactable != null)
    {
      _interactable.Interact(this); // Call the Interact method on the detected interactable
    }
  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
  }
}
