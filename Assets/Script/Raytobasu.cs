using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raytobasu : MonoBehaviour
{
    [SerializeField] Image pointer;
    [SerializeField] Image pointer2;
    [SerializeField] Choice keyChoicePanel;
    //[SerializeField] GameObject swordChoicePanel;

     [SerializeField] Choice ohudaChoicePanel;
    [SerializeField] Check check;

//  アイテムを使用したオブジェクトに使用する前のテキストを表示させないようにする変数
   bool[] UsedText = new bool[11];

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
                //手紙ならぱねるをひょうじして
                case "tegami":
                    ObjID objID = clickedObject.GetComponent<ObjID>();
                    int rayHitID = objID.ID;
                    Cursor.lockState = CursorLockMode.Confined;
                    check.CheckTegami(rayHitID);
                    
                    
                    break;
                case "Tabibito":
                Bunsyou.instance.changetext(7);
                break;
                case "KeyDore":
                KeyDoreOpen component = clickedObject.GetComponent<KeyDoreOpen>();
                component.OpenDore();
                //Bunsyou.instance.changetext(8);
                break;
                case "LockDore":
                Bunsyou.instance.changetext(10);

                break;
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
                bool hasOfuda = ItemBox.instance.CanUseItem(Item.Type.Ohuda);

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
                            keyChoicePanel.ActiveChoice();//パネル表示
                            
                          
                        }
                        else if(UsedText[0])
                        {
                            
                        }
                        else
                        {
                            Bunsyou.instance.changetext(14);
                        }
                    break;
                    case 1:
                    Debug.Log("1");
                    if (hasSword)
                        {
                            //IsChoiced = true;
                            
                            // PlayerCtrl.CamMoveCtrl = 0;//画面固定
                            // Bunsyou.instance.ClearText();
                            // swordChoicePanel.SetActive(true);
                            // Time.timeScale = 0;
                            // Cursor.lockState = CursorLockMode.Confined;
                            // Cursor.visible = true;
                        }
                        else if(UsedText[1])
                        {
                            
                        }
                        else
                        {
                            //Bunsyou.instance.changetext(13);
                        }
                
                    break;
                    case 2:
                    Debug.Log("2");
                    //御札で開けるドア
                    if (hasOfuda)
                        {
                            //IsChoiced = true;
                            
                            PlayerCtrl.CamMoveCtrl = 0;//画面固定
                            Bunsyou.instance.ClearText();//テキスト消す
                            ohudaChoicePanel.ActiveChoice();//パネル表示
                            UsedText[2] = true;
                        }
                        else if(UsedText[2])
                        {
                            
                        }
                        else
                        {
                            Bunsyou.instance.changetext(13);
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
