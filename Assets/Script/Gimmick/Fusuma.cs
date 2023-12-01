using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fusuma : MonoBehaviour
{
    private Animator animator;
    [SerializeField] AudioSource audioSource;

    private bool isanim = false;
    void Start()
    {
        // アニメーターコンポーネントを取得して初期化
        animator = GetComponent<Animator>();
        //audioSource =  GetComponent<AudioSource>();
    }

    void Update()
    {
        Debug.Log(isanim);
    }

    public void SwitchBool()
    {
        if(isanim) isanim = false;
        else isanim = true;
    }
    public void AnimateFusuma()
    {
        //開閉アニメーション中じゃなければ
        if(!isanim)
        {
            animator.SetTrigger("Click");
            audioSource.Play();
            isanim = true;
        }
        
    }

 
    public void MoveFusuma()
    {
        animator.SetTrigger("Move");
    }
}
