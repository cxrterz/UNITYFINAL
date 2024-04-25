using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera _mainCam;

    // Start is called before the first frame update
    private void Start()
    {
        _mainCam = Camera.main;
    }

    // LateUpdate is called once per frame after all Update functions
    private void LateUpdate()
    {
        Quaternion rotation = _mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }
}
