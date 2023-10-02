using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoreOpen : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenDore()
    {
        animator.SetTrigger("Open");
        Debug.Log("ii");

    }
}
