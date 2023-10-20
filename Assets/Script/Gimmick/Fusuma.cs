using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fusuma : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    void Start()
    {
        // アニメーターコンポーネントを取得して初期化
        animator = GetComponent<Animator>();
        audioSource =  GetComponent<AudioSource>();
    }

    public void AnimateFusuma()
    {
        animator.SetTrigger("Click");
        audioSource.Play();
        Debug.Log("1");
    }

    public void MoveFusuma()
    {
        animator.SetTrigger("Move");
    }
}
