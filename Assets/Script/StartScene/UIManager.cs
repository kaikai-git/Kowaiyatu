using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] Image blackBackground;
    
    [SerializeField] Text text1;
    [SerializeField] Text text2;
    public GameObject buttonGameObject;
    private bool text1Faded = false; // フラグ
    //private bool text2Faded = false; // フラグ
    
    [SerializeField] SceneChange scenechange;
//スタートボタンをクリックすると暗転
    public void OnClickbutton()
    { 
        buttonGameObject.SetActive(false); // ボタンを非アクティブにする
       StartCoroutine( BlackOut(blackBackground));
    }

    

    //暗転させる
    private IEnumerator BlackOut(Image black)
    {   
        float fadeSpeed = 0.55f;
       
        while(black.color.a < 1f)
        {
            black.color = new Color(
             black.color.r,
             black.color.g, 
             black.color.b, 
             black.color.a + fadeSpeed * Time.deltaTime
            );
             yield return null;
        }
              
        //フェードが完了したら３秒間まつ
        yield return new WaitForSeconds(2.5f);

        //テキスト1の透明度を上げて表示]
        if(!text1Faded) // フラグがfalseの場合のみ実行
        {
            yield return StartCoroutine(UpAlpha(text1,0.45f));
            text1Faded = true;
        }

         yield return WaitForKeyPress(KeyCode.Return);

         yield return StartCoroutine(DownAlpha(text1, 0.50f));

         yield return new WaitForSeconds(1.0f);
         yield return StartCoroutine(UpAlpha(text2, 0.45f));

         yield return WaitForKeyPress(KeyCode.Return);
         yield return StartCoroutine(DownAlpha(text2, 0.50f));
         yield return new WaitForSeconds(2.0f);
         scenechange.ChangeScene("GameScene");
    }

   

    private IEnumerator UpAlpha(Text text, float fadeSpeed)
    {
        Debug.Log("Up");
        Color startColor = text.color;
        //Color endColor = new Color(startColor.r,startColor.g,startColor.b,1f);
        while(startColor.a < 1f)
        {
             
            startColor = new Color(
             startColor.r,
             startColor.g, 
             startColor.b, 
             startColor.a + fadeSpeed * Time.deltaTime
            );

            text.color = startColor;
            yield return null;
         }
        
    }
    //テキストの透明度を下げる関数
   private IEnumerator DownAlpha(Text text, float fadeSpeed)
    {
         Debug.Log("Down");
        Color startColor = text.color;      
        while(startColor.a > 0f)
        {
            startColor = new Color(
             startColor.r,
             startColor.g, 
             startColor.b, 
             startColor.a - fadeSpeed * Time.deltaTime
            );

            text.color = startColor;
            yield return null;
         }

    }

    private IEnumerator WaitForKeyPress(KeyCode keyCode)
    {
        while (!Input.GetKey(keyCode))
        {
            yield return null;
        }
    }


}
