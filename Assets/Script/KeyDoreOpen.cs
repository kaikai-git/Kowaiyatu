using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoreOpen : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
     private bool once = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    public void OpenDore()
    {
        if(once == true)
        {
            audioSource.Play();
            animator.SetTrigger("Open");
            Debug.Log("ii");
            once = false;
        }

    }
}
