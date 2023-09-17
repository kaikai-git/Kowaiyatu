using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Endplay : MonoBehaviour
{
    public int endnum;
    public RectTransform pos;
    [SerializeField] Text endtext;
    [TextArea]
    public string[] Endtext;
    void Start()
    {
        endmovie();
    }

    void Update()
    {
        pos.position += new Vector3(0,0.04f,0);
    }
    public void endmovie()
    {
        if(endnum == 1)
        {
            endtext.text = Endtext[0];
        }
        else if(endnum == 2)
        {
            endtext.text = Endtext[1];
        }
        else if(endnum == 3)
        {
            endtext.text = Endtext[2];
        }
    }

    public void Uptext()
    {
        
    }
}
