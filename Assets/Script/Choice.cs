using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Choice : MonoBehaviour
{
   [SerializeField] Button YesButton;
   [SerializeField] Button NoButton;
   [SerializeField] Text text;

//パネルを表示
   public void ActiveChoice()
   {
    //選択肢を呼び出す
     gameObject.SetActive(true);
   }

   //Yesボタンを押したらアイテム取得
   public void Yes()
   {
    
     Debug.Log("Yes");
   }

   //Noボタンを押したらキャンセル
}
