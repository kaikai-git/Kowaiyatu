using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OhudaDore : MonoBehaviour
{
     private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OpenDore()
    {
        animator.SetTrigger("A");
        Debug.Log("ii");

    }
}
