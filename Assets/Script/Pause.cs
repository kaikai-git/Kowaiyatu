using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Pause : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Text ItemName;
    [SerializeField] Text ItemDescription;
    [SerializeField] Image KeyImage;
    [SerializeField] Image OhudaImage;
    [SerializeField] Image SwordImage;
    [SerializeField] Image MagatamaImage;
     
//テキスト初期化
    void Start()
    {
        ItemName.text = ("");
        ItemDescription.text = ("");
    }
      public void OnPointerEnter(PointerEventData eventData)
    {
        //アイテム画像の時のみ処理実行
        if (eventData.pointerEnter.CompareTag("ItemImage"))
        {
            Image enteredImage = eventData.pointerEnter.GetComponent<Image>();
            Debug.Log(enteredImage);
             //鍵の画像にカーソルを合わせたとき
             if(enteredImage == KeyImage)
             {
                 Debug.Log("Key説明");
                ItemName.text = ("どこかの鍵");
                ItemDescription.text = ("この鍵をつかえばどこかが開くかも");
             }
             else if(enteredImage == OhudaImage)
             {
                ItemName.text = ("おふだ");
                ItemDescription.text = ("なにかにつかえるのか？");
             }
            else if(enteredImage == SwordImage)
             {
                ItemName.text = ("日本刀");
                ItemDescription.text = ("切れ味がすごそうだ");
             }
             else if(enteredImage == MagatamaImage)
             {
                Debug.Log("まがたま説明");
                ItemName.text = ("まがたま");
                ItemDescription.text = ("これを持っていると心地よいきがする");
             }
                //おふだの画像にカーソルを合わせたとき
                //剣の画像にカーソルを合わせたとき
                //勾玉の画像にカーソルを合わせたとき
        }
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ItemName.text = ("");
        ItemDescription.text = ("");
    }
}


// Image getImage = eventData.pointerEnter.GetComponent<Image>();
        
//         if (getImage == KeyImage && eventData.pointerEnter.CompareTag("ItemImage"))
//         {
//             ItemName.text = ("どこかの鍵");
//             ItemDescription.text = ("この鍵をつかえばどこかが開くかも");
//         }
//         else if (getImage == OhudaImage)
//         {
//             ItemName.text = ("おふだ");
//             ItemDescription.text = ("ふしぎなちからを感じる");
//         }
//         else if (getImage == SwordImage)
//         {
//             ItemName.text = ("日本刀");
//             ItemDescription.text = ("切れ味がすごそうだ");
//         }
//         else if (getImage == MagatamaImage)
//         {
//             ItemName.text = ("まがたま");
//             ItemDescription.text = ("これを持っていると心地よいきがする");
//         }

        //おふだの画像にカーソルを合わせたとき
        //剣の画像にカーソルを合わせたとき
        //勾玉の画像にカーソルを合わせたとき