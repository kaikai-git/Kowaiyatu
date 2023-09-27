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

   

  // public bool IsChoiced;


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
        float distance = 2;
        float duration = 0;
        Physics.Raycast(ray, out hit, distance);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, duration, false);
        // string objectName = hit.collider.gameObject.name;
        // Debug.Log(objectName);
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
                string objTag = clickedObject.tag;

                switch(objTag)
            {
                case "tegami":
                    GameMaster.check = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                    check.CheckTegami();
                    Debug.Log(GameMaster.check);
                    break;
                case "Tabibito":
                Bunsyou.instance.changetext(7);
                break;
                case "KeyDore":
                Bunsyou.instance.changetext(8);
                break;
                // case "KeyWall1":
                // Bunsyou.instance.changetext(9);
                // break;
                // case "KeyWall1":
                // opendoreAnim.SetTrigger("open");
                // break;
                // 他のオブジェクトの処理をここに追加
                case "Fusuma":
                    Debug.Log("Open");
                    Fusuma fusumaComponent = clickedObject.GetComponent<Fusuma>();
                    if (fusumaComponent != null)
                    {
                       
                        fusumaComponent.AnimateFusuma();
                    }
                    break;
                 case "KakusiDore":
                    Debug.Log("Open");
                    Gimmick KakusiDorecomponent = clickedObject.GetComponent<Gimmick>();
                    if (KakusiDorecomponent != null)
                    {
                       
                        KakusiDorecomponent.KakusiDore();
                    }
                    break;    
                
                case "Tansu":
                    Debug.Log("Open");
                    Gimmick Tansucomponent = clickedObject.GetComponent<Gimmick>();
                    if (Tansucomponent != null)
                    {
                       
                        Tansucomponent.Tansu();
                    }
                    break;    
            }
                
            }
            else if (hitLayer == LayerMask.NameToLayer("UseItem"))
            {
                
                bool hasKey = ItemBox.instance.CanUseItem(Item.Type.Key);
                bool hasSword = ItemBox.instance.CanUseItem(Item.Type.Sword);

                ObjID objID = clickedObject.GetComponent<ObjID>();
                int rayHitID = objID.ID;
            //0鍵1刀
                switch(rayHitID)
                {
                    case 0:
                    Debug.Log("0");
                    if (hasKey)
                        {
                            //パネルのデザインを変える処理
                            //IsChoiced = true;
                            PlayerCtrl.CamMoveCtrl = 0;//画面固定
                            Bunsyou.instance.ClearText();//テキスト消す
                            keyChoicePanel.SetActive(true);//パネル表示
                            Time.timeScale = 0;//停止
                            Cursor.lockState = CursorLockMode.Confined;
                            Cursor.visible = true;
                        }
                    break;
                    case 1:
                    Debug.Log("1");
                    if (hasSword)
                        {
                            //IsChoiced = true;
                            
                            PlayerCtrl.CamMoveCtrl = 0;//画面固定
                            Bunsyou.instance.ClearText();
                            swordChoicePanel.SetActive(true);
                            Time.timeScale = 0;
                            Cursor.lockState = CursorLockMode.Confined;
                            Cursor.visible = true;
                        }
                
                    break;
                }
                //パネルを開く処理

                // if (clickedObject.CompareTag("UsedKey"))
                // {
                    
                //     Bunsyou.instance.changetext(6);

                //     if (hasKey)
                //     {
                //         //IsChoiced = true;
                //         PlayerCtrl.CamMoveCtrl = 0;//画面固定
                //         Bunsyou.instance.ClearText();//テキスト消す
                //         keyChoicePanel.SetActive(true);//パネル表示
                //         Time.timeScale = 0;//停止
                //         Cursor.lockState = CursorLockMode.Confined;
                //         Cursor.visible = true;
                //     }
                // }
                // else if (clickedObject.CompareTag("UsedSword"))
                // {
                //     Bunsyou.instance.changetext(5);

                //     if (hasSword)
                //     {
                //         //IsChoiced = true;
                //         Debug.Log("実行");
                //         PlayerCtrl.CamMoveCtrl = 0;//画面固定
                //         Bunsyou.instance.ClearText();
                //         swordChoicePanel.SetActive(true);
                //         Time.timeScale = 0;
                //         Cursor.lockState = CursorLockMode.Confined;
                //         Cursor.visible = true;
                //     }
                // }
            }
        }
    }
}
