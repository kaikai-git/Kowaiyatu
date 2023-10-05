using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private AudioSource audioSource;

    private bool hasPlayed = false; 
    
    void Start()
    {
        // アニメーターコンポーネントを取得して初期化
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void KakusiDore()
    {
        if (!hasPlayed) // 再生していない場合のみ再生
        {
           animator.SetTrigger("Click");
            audioSource.Play();
            hasPlayed = true; // 再生したことをフラグで記録
            Debug.Log("1");
        }
        else
        {
            Bunsyou.instance.changetext(11);
        }
    }

    public void Tansu()
    {
        animator.SetTrigger("Click");
         audioSource.Play();
        Debug.Log("1");
    }

    
}
