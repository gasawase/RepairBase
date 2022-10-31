using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class DragAndDropUnityTrigger : MonoBehaviour
{
    //TODO: get that this has been picked up and then that it is intersecting with the socket

    public UnityEvent WhenIntersectingWithSocket;
    
    private bool isPickedUp = false;
    private bool isIntersecting = false;

    public void PickedUp()
    {
        isPickedUp = true;
        CheckIntersecting();
    }

    public void IntersectingWithSocket()
    {
        isIntersecting = true;
        CheckIntersecting();
    }

    public void CheckIntersecting()
    {
        if (isIntersecting && isPickedUp)
        {
            WhenIntersectingWithSocket.Invoke();
        }
    }
    
}
