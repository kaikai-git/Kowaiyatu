using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Choice : MonoBehaviour
{
   [SerializeField] Button YesButton;
   [SerializeField] Button NoButton;
   [SerializeField] Text text;

   [SerializeField] KeyDoreOpen keyDoreOpen;

//パネルを表示
   public void ActiveChoice()
   {
    //選択肢を呼び出す
     gameObject.SetActive(true);
   }

   //Yesボタンを押したらアイテム取得
   public void SwordYesPush()
   {
    //アイテムを使った時の処理をここに書く
     
     PlayerCtrl.CamMoveCtrl = 1;//画面
     UsedItem.instance.UseItemSword();  
     gameObject.SetActive(false);
     Time.timeScale = 1;   
     Cursor.lockState = CursorLockMode.Locked;
     Cursor.visible = false;

    
   }
   public void KeyYesPush()
   {
    //アイテムを使った時の処理をここに書く
     
      PlayerCtrl.CamMoveCtrl = 1;//画面
     UsedItem.instance.UseItemKey();
    Debug.Log("Open");
    
     gameObject.SetActive(false);
     Time.timeScale = 1;   
     Cursor.lockState = CursorLockMode.Locked;
     Cursor.visible = false;
     bool swordFlag = true;

     keyDoreOpen.OpenDore();
    
   }

   public void OhudaYesPush()
   {
    //アイテムを使った時の処理をここに書く
     
      PlayerCtrl.CamMoveCtrl = 1;//画面
     UsedItem.instance.UseItemOhuda();
      
    
     gameObject.SetActive(false);
     Time.timeScale = 1;   
     Cursor.lockState = CursorLockMode.Locked;
     Cursor.visible = false;
    // bool swordFlag = true;

     keyDoreOpen.OpenDore();
    
   }

   //Noボタンを押したらアイテムを取得せずキャンセル
   public void NoPush()
   {
    
      PlayerCtrl.CamMoveCtrl = 1;//画面
     gameObject.SetActive(false);
     Time.timeScale = 1;   
     Cursor.lockState = CursorLockMode.Locked;
     Cursor.visible = false;
   }
}
