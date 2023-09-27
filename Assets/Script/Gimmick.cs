using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

    void Start()
    {
        // アニメーターコンポーネントを取得して初期化
        animator = GetComponent<Animator>();
    }

    public void KakusiDore()
    {
        animator.SetTrigger("Click");
        Debug.Log("1");
    }

    public void Tansu()
    {
        animator.SetTrigger("Click");
        Debug.Log("1");
    }

    
}
