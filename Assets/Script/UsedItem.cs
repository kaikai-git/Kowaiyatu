using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedItem : MonoBehaviour
{

    public static UsedItem instance;
  [SerializeField] GameObject Usedkey;
  [SerializeField] GameObject Usedsword;

   void Start()
   {
    //Debug.Log(usetype);
   }
    private void Awake()
      {
          instance = this;
      }
    public  void UseItemKey()
    {
        //使用できるアイテムがあれば使用

    //勾玉を使った場合の処理
      bool hasItem = ItemBox.instance.CanUseItem(Item.Type.Key);
      if(hasItem == true )
      {
            Debug.Log("Key使用");
       Usedkey.SetActive(false);
          
       ItemBox.instance.UseItem(Item.Type.Key);
      }
      else
      {
        Debug.Log("ひつようなアイテムを持っていない");
      }
    }

    public  void UseItemSword()
    {
        //使用できるアイテムがあれば使用

    //勾玉を使った場合の処理
      bool hasItem = ItemBox.instance.CanUseItem(Item.Type.Sword);
      if(hasItem == true )
      {
            Debug.Log("Sword使用");
       Usedsword.SetActive(false);
          
       ItemBox.instance.UseItem(Item.Type.Sword);
      }
      else
      {
        Debug.Log("ひつようなアイテムを持っていない");
      }
    }

     public  void UseItemOhuda()
    {
        //使用できるアイテムがあれば使用

    //勾玉を使った場合の処理
      bool hasItem = ItemBox.instance.CanUseItem(Item.Type.Ohuda);
      if(hasItem == true )
      {
            Debug.Log("Ohudause");
       //Usedsword.SetActive(false);
          
       ItemBox.instance.UseItem(Item.Type.Ohuda);
      }
      else
      {
        Debug.Log("ひつようなアイテムを持っていない");
      }
    }
    
}
