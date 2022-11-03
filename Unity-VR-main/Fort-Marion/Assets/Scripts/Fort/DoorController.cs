using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;
    private static readonly int IsOpen = Animator.StringToHash("isOpen");

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ToggleDoor()
    {
        var state = animator.GetBool(IsOpen);
        animator.SetBool(IsOpen, !state);
        
    }
}
