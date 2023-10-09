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
        

        //タイプごとに異なった文章を表示
        if(type == Type.Magatama)
        {
             Bunsyou.instance.changetext(0);
        }
        else if(type == Type.Ohuda)
        {
             Bunsyou.instance.changetext(1);
        }
        else if(type == Type.Sword)
        {
             Bunsyou.instance.changetext(2);
        }
        else if(type == Type.Key)
        {
             Bunsyou.instance.changetext(3);
        }
        //changetext(int wordnum);  
        ItemBox.instance.SetItem(type);

     }
}
