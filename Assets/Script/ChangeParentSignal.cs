using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeParentSignal : MonoBehaviour
{
    [SerializeField] GameObject ChangeParentObj;//親を変えるオブジェクト
    [SerializeField] GameObject ResetParentObj;//元の親であるオブジェクト
    [SerializeField] GameObject ParentObj;//新たに親になるオブジェクト
    
    [SerializeField] SceneChange sceneChange;

    [SerializeField] Image blackimage;

    [SerializeField] GameObject TimeLine12;
    [SerializeField] GameObject TimeLine3;
   
   public void Start()
   {
      EndPlayer.endnum = EndPlayer.instance.DecideEnd();
    
        if(EndPlayer.endnum == 1||EndPlayer.endnum == 2)
        {
            //エンディング１．２
            TimeLine12.SetActive(true);
        }
        else
        {

            TimeLine3.SetActive(true);
        }
   }

    public void Signal()
    {
        // ChangeParentObjの親をParentObjに変更する
            ChangeParentObj.transform.SetParent(ParentObj.transform);
            //ChangeParentObjのposをParentObjの座標から(0,-2,-1)した値にする
            ChangeParentObj.transform.position = ParentObj.transform.position + new  Vector3(0f, -0.24f, 0.27f);
        Debug.Log("Change");
    }
    public void ResetParentSignal()
    {
        // ChangeParentObjの親をParentObjに変更する
            ChangeParentObj.transform.SetParent(ResetParentObj.transform);
            //ChangeParentObjのposをParentObjの座標から(0,-2,-1)した値にする
            ChangeParentObj.transform.position = ResetParentObj.transform.position;
        Debug.Log("Change");
    }

    public void ToEndScene()
    {
        //暗転してシーン変更
        sceneChange.ChangeScene("EndScene");
    }

    public void FadeInOut()
    {
        StartCoroutine( BlackAlphaUp(blackimage));
   
    }
    private IEnumerator BlackAlphaUp(Image black)
    {   
        float fadeSpeed = 0.55f;
       
       if(black.color.a == 1)
       {
            while(black.color.a >= 0f)
        {
            black.color = new Color(
             black.color.r,
             black.color.g, 
             black.color.b, 
             black.color.a - fadeSpeed * Time.deltaTime
            );
             yield return null;
        }

       }
       else if(black.color.a <= 0)
       {
        while(black.color.a <= 1f)
        {
            black.color = new Color(
             black.color.r,
             black.color.g, 
             black.color.b, 
             black.color.a + fadeSpeed * Time.deltaTime
            );
             yield return null;
        }
       }
        
    }       
}
