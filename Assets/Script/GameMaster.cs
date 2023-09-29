using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] StageGimmick stageGimmick;
    [SerializeField] GameUI gameUi;
    [SerializeField] PlayerCtrl playerctrl;
    [SerializeField] Raytobasu raytobasu;
    [SerializeField] GameObject tegamipanel;

    [SerializeField] Choice choice;

   
     bool[] CalledOnce = new bool[3];
   
     
//手紙を読んでいるかどうかの変数
     public static bool check = false;
    private void Start()
    {
         //gameUi.changetext(1);
        
    }

    void Update()
    {
        

        stageGimmick.IsHit();
       
        if(check == false)
        {
            //手紙パネル消滅
            tegamipanel.SetActive(false);
        }
        //raytobasu.Raywotobasu();
        
        // if(raytobasu.IsChoiced)
        // {
        //     //カーソル固定
        //     playerctrl.Choice();
        // }
        
        
    }


    // void kagidore()
    // {
    //     bool KeyFlag = choice.KeyYesPush();
    //     if(KeyFlag)
    //     {
    //         Debug.Log("open");
    //         keyDoreOpen.OpenDore();
    //     }
    // }
    


}
