using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] StageGimmick stageGimmick;
    [SerializeField] GameUI gameUi;



    private void Start()
    {
         //gameUi.changetext(1);
        
    }

    void Update()
    {
        if(stageGimmick.Flags[0])
        {
            gameUi.changetext(1);
        }

    }


}
