using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type
    {
        Key,
        Magatama,
        Sowrd,
        Ohuda,
    }
     
     public Type type;
     

     public void test()
     {
        Debug.Log("2iine");
     }
}
