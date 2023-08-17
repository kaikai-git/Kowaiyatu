using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raytobasu : MonoBehaviour
{
    [SerializeField] Image pointer;
    [SerializeField] Image pointer2;
    [SerializeField] GameObject keyChoicePanel;
    [SerializeField] GameObject swordChoicePanel;
    [SerializeField] Check check;

   

   public bool IsChoiced;


   public void Update()
   {
     Raywotobasu();
     
     //Debug.Log(PlayerCtrl.CamMoveCtrl);
   }

    public void Raywotobasu()
    {
        //PlayerCtrl.CamMoveCtrl = 0;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float distance = 10;
        float duration = 0;
        Physics.Raycast(ray, out hit, distance);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, duration, false);

        if (hit.collider != null)
        {
            //PlayerCtrl.CamMoveCtrl = 0;
            GameObject clickedObject = hit.collider.gameObject;
            LayerMask hitLayer = hit.collider.gameObject.layer;

            if (hitLayer == LayerMask.NameToLayer("UseItem") || 
                hitLayer == LayerMask.NameToLayer("Item") || 
                hitLayer == LayerMask.NameToLayer("CheakItem"))
            {
                //PlayerCtrl.CamMoveCtrl = 0;
                HandleClickableObject(hitLayer, clickedObject);
            }
            else
            {
                pointer.enabled = true;
                pointer2.enabled = false;
            }
        }
        else
        {
            pointer.enabled = true;
            pointer2.enabled = false;
        }
    }

    public void HandleClickableObject(LayerMask hitLayer, GameObject clickedObject)
    {
        pointer.enabled = false;
        pointer2.enabled = true;

        if (Input.GetMouseButtonDown(0))
        {
           
            if (hitLayer == LayerMask.NameToLayer("Item"))
            {
                Item itemComponent = clickedObject.GetComponent<Item>();
                itemComponent.ClickedItem();
            }
            else if (hitLayer == LayerMask.NameToLayer("CheakItem"))
            {
                GameMaster.check = true;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                check.CheckTegami();
                //check.CheckTegami();
                Debug.Log(GameMaster.check);
            }
            else if (hitLayer == LayerMask.NameToLayer("UseItem"))
            {
                
                bool hasKey = ItemBox.instance.CanUseItem(Item.Type.Key);
                bool hasSword = ItemBox.instance.CanUseItem(Item.Type.Sword);

                if (clickedObject.CompareTag("UsedKey"))
                {
                    
                    Bunsyou.instance.changetext(6);

                    if (hasKey)
                    {
                        //IsChoiced = true;
                        PlayerCtrl.CamMoveCtrl = 0;//画面固定
                        Bunsyou.instance.ClearText();//テキスト消す
                        keyChoicePanel.SetActive(true);//パネル表示
                        Time.timeScale = 0;//停止
                        Cursor.lockState = CursorLockMode.Confined;
                        Cursor.visible = true;
                    }
                }
                else if (clickedObject.CompareTag("UsedSword"))
                {
                    Bunsyou.instance.changetext(5);

                    if (hasSword)
                    {
                        //IsChoiced = true;
                        Debug.Log("実行");
                        PlayerCtrl.CamMoveCtrl = 0;//画面固定
                        Bunsyou.instance.ClearText();
                        swordChoicePanel.SetActive(true);
                        Time.timeScale = 0;
                        Cursor.lockState = CursorLockMode.Confined;
                        Cursor.visible = true;
                    }
                }
            }
        }
    }
}
