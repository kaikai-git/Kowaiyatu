using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageGimmick : MonoBehaviour
{
   
     [SerializeField] Image blackBackground;
    // [SerializeField] KeyGetGimmick keyGetGimmick;
    [SerializeField] AreaHit[] Area;
    [SerializeField] SceneChange sceneChange;
     bool[] flags = new bool[4];
     bool[] CalledOnce = new bool[4];
     bool GetItem;
     public bool[] Flags {get => flags;}
    [SerializeField] Animator animator;

   
    
    AudioSource audioSource;
    void Start()
    {
        bool GetItem = ItemBox.instance.CanUseItem(Item.Type.Key);
        flags[0] = false;
        flags[1] = false;
        flags[2] = false;
        flags[3] = false;
        audioSource = GetComponent<AudioSource>();
         
    }

 
    public void IsHit()
    {      
       
        if( Area[0].IsHit == true && !CalledOnce[0])
         {  audioSource.Play();
            animator.SetTrigger("State1");
             Debug.Log("hit1");
            flags[0] = true;
            CalledOnce[0] = true;
            //Camera.main.gameObject.GetComponent<ShakeCamera>().Shake();
            Bunsyou.instance.changetext(3);
         }
         else if( Area[1].IsHit == true && !CalledOnce[1]) 
         {
            animator.SetTrigger("State2");
             Debug.Log("hit1");
            flags[1] = true;
            CalledOnce[1] = true;
            Bunsyou.instance.changetext(4);
         }
         else if( Area[2].IsHit == true && !CalledOnce[2]) 
         {
            Time.timeScale = 1; 
             StartCoroutine( BlackOut(blackBackground));
             Debug.Log("SceneChange");
            flags[2] = true;
            CalledOnce[2] = true;
            //完全に暗転したらシーン変更
            

         }
         //鍵取得時イベント
          else if( Area[3].IsHit == true && !CalledOnce[3]) 
         {
            //bool GetItem = ItemBox.instance.CanUseItem(Item.Type.Key);
            //Time.timeScale = 1; 
            
             //Debug.Log("SceneChange");
             
             Debug.Log("hit2");
            flags[3] = true;
            CalledOnce[3] = true;
           
             Time.timeScale = 0;
            //StartCoroutine(LightOff());
             
            
            //完全に暗転したらシーン変更
            

         }
          
    }

//暗転させる
     private IEnumerator BlackOut(Image black)
    {   
        float fadeSpeed = 0.45f;
       
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
        yield return new WaitForSeconds(2.0f);
         sceneChange.ChangeScene("AnimScene");
    }

   
  
}
