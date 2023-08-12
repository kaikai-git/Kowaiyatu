using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemwoTuaku : MonoBehaviour
{

    public  void UseItem()
    {
        //使用できるアイテムがあれば使用

    //勾玉を使った場合の処理
      bool hasItem = ItemBox.instance.CanUseItem(Item.Type.Magatama);
      if(hasItem == true)
      {
            
       gameObject.SetActive(false);
          
       ItemBox.instance.UseItem(Item.Type.Magatama);
      }
    }
    
}
