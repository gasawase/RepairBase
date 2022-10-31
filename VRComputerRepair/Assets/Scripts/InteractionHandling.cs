using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandling : MonoBehaviour
{
    private Quaternion originalRotation;
    private Vector3 originalLocation;
    private void Start()
    {
        originalRotation = transform.rotation;
        originalLocation = transform.position;
    }

    /*
     * This script is called everytime an interactable object is released
     */
    public void OnRelease()
    {
        //snap back to original location
        transform.position = originalLocation;
        transform.rotation = originalRotation;
    }
}
