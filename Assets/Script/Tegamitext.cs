using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tegamitext : MonoBehaviour
{
    [TextArea]
    public string[] ExWord;
    
    [SerializeField] Text explainText;
    public int ExWordnum = 0; 
    //文字を変更する処理
  
    
    
    public void changetext(int ExWordnum)
    {
        Debug.Log(ExWordnum);
        explainText.text = ExWord[ExWordnum];
        ExWordnum++; 
    }
}
