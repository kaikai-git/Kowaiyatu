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
        
        // if(stageGimmick.Flags[0] && !CalledOnce[0])
        // {
        //     gameUi.changetext(0);
        //     CalledOnce[0] = true;
        // }
        // else if(stageGimmick.Flags[1] && !CalledOnce[1])
        // {
        //     gameUi.changetext(1);
        //     CalledOnce[1] = true;
        // }

    }


}
