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
     bool[] flags = new bool[11];
     bool[] CalledOnce = new bool[11];
     bool GetItem;
     public bool[] Flags {get => flags;}
    [SerializeField] Animator[] animator;
    
   //[SerializeField] Gate gate;


   [SerializeField]  AudioClip[] audioClip;
   [SerializeField] ShakeCamera shakeCamera;
    
    AudioSource audioSource;
    [SerializeField] AudioSource RainaudioSource;
    void Start()
    {
        bool GetItem = ItemBox.instance.CanUseItem(Item.Type.Key);
        
        audioSource = GetComponent<AudioSource>();
         
    }

 
    public void IsHit()
    {      
       
        if( Area[0].IsHit == true && !CalledOnce[0])
         {  
            audioSource.PlayOneShot(audioClip[0]);
            animator[0].SetTrigger("State1");
             Debug.Log("hit1");
            flags[0] = true;
            CalledOnce[0] = true;
            //Camera.main.gameObject.GetComponent<ShakeCamera>().Shake();
            
         }
         else if( Area[1].IsHit == true && !CalledOnce[1]) 
         {
            animator[0].SetTrigger("State2");
             Debug.Log("hit1");
            flags[1] = true;
            CalledOnce[1] = true;
            
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
         //扉が閉まって音再生
         else if(Area[4].IsHit == true && !CalledOnce[4])
         { 
            
            flags[4] = true;
            CalledOnce[4] = true;
            StartCoroutine(Gate());
          
         }
         //箪笥落下
          else if(Area[5].IsHit == true && !CalledOnce[5])
         { 
            
            flags[5] = true;
            CalledOnce[5] = true;
           
            animator[2].SetTrigger("Fall");
            Invoke("TansuFall",0.5f);
         }

         //お面落下
          else if(Area[6].IsHit == true && !CalledOnce[6])
         { 
            
            flags[6] = true;
            CalledOnce[6] = true;
           
            animator[3].SetTrigger("Fall");
           
         }
          else if(Area[7].IsHit == true && !CalledOnce[7])
         { 
            
            flags[7] = true;
            CalledOnce[7] = true;
           
            Bunsyou.instance.changetext(12);
           
         }
    }

   
    private void TansuFall()
   {
         shakeCamera.Shake();
        audioSource.PlayOneShot(audioClip[2]);
   }

      private  IEnumerator Gate()
      {
         animator[1].SetTrigger("Close");
           yield return new WaitForSeconds(0.7f);
          audioSource.PlayOneShot(audioClip[1]);
            yield return new WaitForSeconds(0.6f);
          //音量を下げる
            RainaudioSource.volume = 0.1f;
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
