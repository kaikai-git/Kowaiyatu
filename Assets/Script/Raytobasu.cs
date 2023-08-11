using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raytobasu : MonoBehaviour
{
   
   // Update is called once per frame
   void Update()
   {
    
        
     Raywotobasu();
 
   }

    public void Raywotobasu()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit,10.0f))
            {
                //クリックオブジェクトの情報取得
                GameObject clickedObject = hit.collider.gameObject;
                
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Item"))
                {
                    Debug.Log(clickedObject.name);
                    Item itemComponent = clickedObject.GetComponent<Item>(); // Itemコンポーネントを取得
                   itemComponent.test();
                     Destroy(clickedObject);
                }
            }

           
        }
    }
   
            

           
        
}
