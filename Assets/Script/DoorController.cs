﻿using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        animator.SetBool("isOpen", true);
    }

    public void CloseDoor()
    {
        animator.SetBool("isOpen", false);
    }
}
