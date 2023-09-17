using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fusuma : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // アニメーターコンポーネントを取得して初期化
        animator = GetComponent<Animator>();
    }

    public void AnimateFusuma()
    {
        animator.SetTrigger("Click");
        Debug.Log("1");
    }
    
}
