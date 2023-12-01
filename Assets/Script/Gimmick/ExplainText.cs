using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplainText : MonoBehaviour
{
    public string[] ExWord;
    [SerializeField] Text explainText;
    private int ExWordnum = 0; 
    //文字を変更する処理
    void Start()
    {
       
        // changetext(1);
        // StartCoroutine(AlphaUp());
        // StartCoroutine(AlphaDown());
        changetext();
    }
    
    
    public void changetext()
    {
        Debug.Log(ExWordnum);
        explainText.text = ExWord[ExWordnum];
        ExWordnum++; 
    }

    public  IEnumerator AlphaUp()
    {
       float fadeSpeed = 0.6f; 
       //テキストの透明度上げる
      Debug.Log("Up");
        while(explainText.color.a <= 1f)
        {
            explainText.color = new Color(
             explainText.color.r,
             explainText.color.g, 
             explainText.color.b, 
             explainText.color.a + fadeSpeed * Time.deltaTime
            );
             yield return null;
        }
       
       
        yield return new WaitForSeconds(2.0f);

    }
    public  IEnumerator AlphaDown()
    {
       float fadeSpeed = 0.6f; 
       //テキストの透明度下げる
       Debug.Log("down");
        while(explainText.color.a >= 0f)
        {
            explainText.color = new Color(
             explainText.color.r,
             explainText.color.g, 
             explainText.color.b, 
             explainText.color.a - fadeSpeed * Time.deltaTime
            );
             yield return null;
        }
        changetext();
       
        yield return new WaitForSeconds(2.0f);

    }

}
