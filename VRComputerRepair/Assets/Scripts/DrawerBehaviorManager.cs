using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerBehaviorManager : MonoBehaviour
{
    private bool isOpen;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        isOpen = _animator.GetBool("isOpen");
        if (isOpen)
        {
            _animator.Play("DrawerOpen");
            isOpen = false;
        }
        else
        {
            _animator.Play("DrawerClose");
            isOpen = true;
        }
    }
}
