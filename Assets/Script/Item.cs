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
     public void test()
     {
        gameObject.SetActive(false);
     }
}
