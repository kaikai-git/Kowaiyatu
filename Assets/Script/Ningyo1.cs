using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ningyo1 : MonoBehaviour
{
    private AudioSource audioSource;
     bool Once = false;




    void Start()
    {
        // ゲームオブジェクトから AudioSource コンポーネントを取得
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        NingyoActive();
        
    }
    public void NingyoActive()
    {
        bool GetItem = ItemBox.instance.CanUseItem(Item.Type.Ohuda);
       
        if(GetItem == true && Once == false)
        {
           //gameObject.SetActive(false);
            audioSource.Play();
            Once = true;
        }
        // else
        // {
        //     Debug.Log("ひつようなアイテムを持っていない");
        // }
    }
}
