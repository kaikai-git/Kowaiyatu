using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type
    {
        Key,
        Magatama,
        Sword,
        Ohuda,
    }
     
     public Type type;
     

//所得したアイテムを格納してActiveFalse
     public void ClickedItem()
     {
        
        gameObject.SetActive(false);
        Debug.Log(type+"を取得");
        Bunsyou.instance.changetext(1);
        //changetext(int wordnum);  
        ItemBox.instance.SetItem(type);

     }
}
