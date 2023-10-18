using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    [SerializeField] Tegamitext tegamitext;

    public void CheckTegami(int tegamiID)
    {
            tegamitext.changetext(tegamiID);
            gameObject.SetActive(true);
             PlayerCtrl.CamMoveCtrl = 0;
    
            Time.timeScale = 0;
     }
    public void OutTegami()
    {
        // if (GameMaster.check == false)
        // {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            GameMaster.check = false;
            gameObject.SetActive(false);
            PlayerCtrl.CamMoveCtrl = 1;   
            Time.timeScale = 1;
        //}

          
    }

    
}
