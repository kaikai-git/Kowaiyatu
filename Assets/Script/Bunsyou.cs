using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bunsyou : MonoBehaviour
{
    public Text textbun;
    public string[] word;//表示する文章
    //テキストを変更
    public static Bunsyou instance;

   private void Awake()
    {
        instance = this;
    }

    public void changetext(int wordnum)
    {
        //Debug.Log("change");
        textbun.text = word[wordnum];
        Invoke(nameof(ClearText),3f);
    }

//テキストを初期化
    public void ClearText()
    {
        //Debug.Log("Clear");
        textbun.text = "";
    }
}
