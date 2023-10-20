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
   //足音止める用
    [SerializeField] AudioSource FootSE;

//パネルを表示
   public void ActiveChoice()
   {
    //選択肢を呼び出す
     FootSE.Stop();
     gameObject.SetActive(true);
      Time.timeScale = 0;//停止
       Cursor.lockState = CursorLockMode.Confined;
      Cursor.visible = true;
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
