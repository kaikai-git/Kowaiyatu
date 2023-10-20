using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
      
    private Animator Gateanimator;
    private AudioSource audioSource;
    void Start()
    {
        // アニメーターコンポーネントを取得して初期化
        Gateanimator = GetComponent<Animator>();
        audioSource =  GetComponent<AudioSource>();
    }
   public void Close()
   {
        Gateanimator.SetTrigger("Close");
        audioSource.Play();
         Debug.Log("1");
   }
            
}
