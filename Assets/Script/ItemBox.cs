using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{

    public GameObject box0;
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
   public static ItemBox instance;

   private void Awake()
    {
        instance = this;
    }

     public void SetItem(Item.Type type)
    {
        if(type == Item.Type.Key)
        {
            
            
            box0.SetActive(true);
            
        }
         if(type == Item.Type.Ohuda)
        {
            
            
            box1.SetActive(true);
            
        }
         if(type == Item.Type.Sword)
        {
            
            
            box2.SetActive(true);
            
        }
         if(type == Item.Type.Magatama)
        {
            
            
            box3.SetActive(true);
            
        }
        
    }

    public bool CanUseItem(Item.Type type)
    {
        if (type == Item.Type.Key)
        {
            
            return box0.activeSelf;
            
        }
        if (type == Item.Type.Ohuda)
        {

            return box1.activeSelf;

        }
        if (type == Item.Type.Sword)
        {

            return box2.activeSelf;

        }
        if (type == Item.Type.Magatama)
        {

            return box3.activeSelf;

        }
        return false;
    }

     public void UseItem(Item.Type type)
    {
        if (type == Item.Type.Key)
        {
           
            box0.SetActive(false);
        }

        if (type == Item.Type.Ohuda)
        {
          
            box1.SetActive(false);
        }
        if (type == Item.Type.Sword)
        {
    
            box2.SetActive(false);
        }
        if (type == Item.Type.Magatama)
        {
           
            box3.SetActive(false);
        }
    }

   
}
