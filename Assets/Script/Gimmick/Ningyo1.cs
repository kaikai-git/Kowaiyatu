using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ningyo1 : MonoBehaviour
{
    private AudioSource audioSource;
     bool Once = false;
    [SerializeField] Transform MovePos;

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
          
            //audioSource.Play();
            Once = true;
            transform.position = MovePos.position;
            transform.Rotate(0,180f,0);
        }
        // else
        // {
        //     Debug.Log("ひつようなアイテムを持っていない");
        // }
    }
}
