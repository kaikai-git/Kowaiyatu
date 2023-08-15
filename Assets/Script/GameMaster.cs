using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] StageGimmick stageGimmick;
    [SerializeField] GameUI gameUi;
    [SerializeField] PlayerCtrl playerctrl;
    [SerializeField] Raytobasu raytobasu;

     bool[] CalledOnce = new bool[3];
    private void Start()
    {
         //gameUi.changetext(1);
        
    }

    void Update()
    {

        stageGimmick.IsHit();


        raytobasu.Raywotobasu();
        
        // if(raytobasu.IsChoiced)
        // {
        //     //カーソル固定
        //     playerctrl.Choice();
        // }
        
        
    }


}
