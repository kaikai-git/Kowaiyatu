using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Raytobasu : MonoBehaviour
{
   [SerializeField] Image pointer;
   [SerializeField] Image pointer2;
   
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

         //クリックできるものに標準がある場合UI変更
         if (hit.collider != null)//何かに当たっている場合
         {
            //クリックオブジェクトの情報取得
            GameObject clickedObject = hit.collider.gameObject;

            //レイヤー探索
            if ( hit.collider.gameObject.layer == LayerMask.NameToLayer("UseItem") || hit.collider.gameObject.layer == LayerMask.NameToLayer("Item"))
            {
                Debug.Log("Item");
                 //クリックできるものに標準がある場合pointer2表示,pointer1非表示
                 pointer.enabled = false;    
                 pointer2.enabled = true;
                 //Debug.Log("use?");
                    //マウスをクリックした場合アイテム取得
                    if (Input.GetMouseButtonDown(0))
                    {
                        
                        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Item"))
                        {
                            Debug.Log(clickedObject.name);
                            Item itemComponent = clickedObject.GetComponent<Item>(); // Itemコンポーネントを取得
                            
                            itemComponent.ClickedItem();
                            //Destroy(clickedObject);
                        }    
                        else if(hit.collider.gameObject.layer == LayerMask.NameToLayer("UseItem"))
                        {
                            //Debug.Log("use?");
                            UsedItem itemComponent = clickedObject.GetComponent<UsedItem>(); // Itemコンポーネントを取得
                            itemComponent.UseItem();
                        }       
                    }                   
            }
            else if(hit.collider.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                Debug.Log("UI");
            }
            else
            {
                //クリックできるものに標準がない場合pointer1表示,pointer2非表示
                pointer.enabled = true;    
                pointer2.enabled = false;
            }   
       
        }
        else
        {
            // レイが何にも当たっていない場合pointer1表示,pointer2非表示
            pointer.enabled = true;
            pointer2.enabled = false;
        }
    }      
}
