using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{
    public Text textbun;
    public string[] word;

    int num = 0;
    private void Start()
    {
        textbun.text = word[num];
        changetext(word[1]);
    }

    public void changetext(string newtext)
    {
        Debug.Log("change");
        textbun.text = newtext;
        Invoke(nameof(ClearText),3f);
    }

    public void ClearText()
    {
        Debug.Log("Clear");
        textbun.text = "";
    }
 }
