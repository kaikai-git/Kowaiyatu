using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlayer : MonoBehaviour
{
    
    [SerializeField] GameObject Magatama;
    [SerializeField] GameObject Katana;

    


    void Update()
    {
        int endnum = DecideEnd();
        Debug.Log(endnum);
    }

    public int DecideEnd()
    {
        int endnum = 3;
        //エンディング1を再生
        if(!Magatama.activeSelf&&!Katana.activeSelf)
        {
            Debug.Log("エンディング1へ");
            endnum = 1;
        }
         //エンディング2を再生
        else if(!Katana.activeSelf)
        {
            Debug.Log("エンディング2へ");
            endnum = 2;

        }
         //エンディング3を再生
         else
         {
            Debug.Log("エンディング3へ");
            endnum = 3;
         }
         return endnum ;
    }
}
