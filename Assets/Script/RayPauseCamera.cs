using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayPauseCamera : MonoBehaviour
{
   // Update is called once per frame
   void Update()
   {
    
        
     Raywotobasu();
 
   }

    public void Raywotobasu()
    {
       //Rayの初期設定、Rayを飛ばす
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit hit;
        float distance = 10;
        float duration = 1;
        Physics.Raycast(ray, out hit,distance);
        //可視化
         Debug.DrawRay (ray.origin, ray.direction * distance, Color.red, duration, false);

         
            //クリックオブジェクトの情報取得
            GameObject clickedObject = hit.collider.gameObject;

            
            if(hit.collider.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                Debug.Log("UI");
            }
            
        }
       
}


