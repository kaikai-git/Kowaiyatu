using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlayer : MonoBehaviour
{
    
    // [SerializeField] GameObject Magatama;
    // [SerializeField] GameObject Katana;
    public static EndPlayer instance;

    private void Awake()
    {
        instance = this;
    }

    public static int endnum = 3;
    public static bool HasSword = false;
    public static bool HasMagatama = false;

    void Start()
    {
        //int endnum = 3;
    }   
    void Update()
    {
        //  int endnum = DecideEnd();
        // Debug.Log(HasMagatama);
    }

    public int DecideEnd()
    {
        
        // bool hasItemSword = ItemBox.instance.CanUseItem(Item.Type.Sword);
        // bool hasItemMagatama = ItemBox.instance.CanUseItem(Item.Type.Magatama);
        //エンディング1を再生(Goodエンディング)
        if(HasMagatama == true && HasSword == true)
        {
            Debug.Log("エンディング1へ");
            endnum = 1;
        }
         //エンディング2(Usualエンディング)を再生
        else if(HasSword == true)
        {
            Debug.Log("エンディング2へ");
            endnum = 2;

        }
         //エンディング3(Badエンディング)を再生
         else
         {
            Debug.Log("エンディング3へ");
            endnum = 3;
         }
         return endnum ;
    }
}
