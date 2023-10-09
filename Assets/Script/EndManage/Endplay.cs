using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Endplay : MonoBehaviour
{
    //public int endnum;
    public RectTransform pos;
    public RectTransform posEndNumText;
    [SerializeField] Text endtext;
    [SerializeField] Text endNumText;
    [TextArea]
    public string[] Endtext;
    public float ScrolSpeed = 0.2f;
    void Start()
    {
        EndPlayer.endnum = EndPlayer.instance.DecideEnd();
        endmovie();
        
    }

    void Update()
    {
        if(posEndNumText.anchoredPosition.y < 0)
        {
             pos.anchoredPosition  += new Vector2(0, ScrolSpeed);
            posEndNumText.anchoredPosition  += new Vector2(0, ScrolSpeed);
        }
       
        //OnEndNumtext();
    }
    public void endmovie()
    {
        if(EndPlayer.endnum == 1)
        {
            endtext.text = Endtext[0];
        }
        else if(EndPlayer.endnum == 2)
        {
            endtext.text = Endtext[1];
        }
        else if(EndPlayer.endnum == 3)
        {
            endtext.text = Endtext[2];
        }
    }

    public void OnEndNumtext()
    {
       if (posEndNumText.anchoredPosition.y < 500)
        {
            Debug.Log("1");
        }
    }
    
}
