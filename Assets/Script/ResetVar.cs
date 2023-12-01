using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetVar : MonoBehaviour
{
    //変数、状態初期化スクリプト
    void Start()
    {
        //カーソル視覚化
         Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 1;
            //endnum初期化
             EndPlayer.endnum = EndPlayer.instance.DecideEnd();
             EndPlayer.endnum = 3;
             EndPlayer.HasSword = false;
             EndPlayer.HasMagatama = false;
    }

    void Update()
    {
        //Debug.Log(EndPlayer.endnum);
    }
}
