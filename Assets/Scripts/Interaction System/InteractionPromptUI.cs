using System.Collections.Generic; // Remove unused namespace
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; // Add this line


public class InteractionPromptUI : MonoBehaviour
{
    private Camera _mainCam;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private TextMeshProUGUI _promptText;

    private void Start()
    {
        _mainCam = Camera.main;
        _uiPanel.SetActive(false);
    }

    // LateUpdate is called once per frame after all Update functions
    private void LateUpdate()
    {
        Quaternion rotation = _mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    public bool IsDisplayed = false; // Fix capitalization

    public void SetUp(string promptText)
    {
        _promptText.text = promptText; // Use lowercase 'text'
        _uiPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    {
        _uiPanel.SetActive(false);
        IsDisplayed = false;
    }
}