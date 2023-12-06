using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageGimmick : MonoBehaviour
{
   [SerializeField] Image blackBackground;
   [SerializeField] AreaHit[] Area;
   [SerializeField] SceneChange sceneChange;
   [SerializeField] ExplainText explainText;
   bool[] flags = new bool[20];
   bool[] CalledOnce = new bool[20];
   public bool[] Flags { get => flags; }
   [SerializeField] Animator[] animator;

   [SerializeField] AudioClip[] audioClip;
   [SerializeField] ShakeCamera shakeCamera;

   AudioSource audioSource;
   [SerializeField] GameObject RainaudioSource;
   [SerializeField] GameObject RainaudioSourceClose;
   [SerializeField] GameObject NarehateRun;
   [SerializeField] GameObject NarehateWalk;
   [SerializeField] GameObject Nigyou;

   [SerializeField] GameObject Rousoku;
   void Start()
   {
      audioSource = GetComponent<AudioSource>();
      explainText = explainText.GetComponent<ExplainText>();
   }

   void Update()
   {
       IsHit();
   }


   public void IsHit()
   {
      bool GetItem = ItemBox.instance.CanUseItem(Item.Type.Magatama);

      if (Area[0].IsHit == true && !CalledOnce[0])
      {
         audioSource.PlayOneShot(audioClip[0]);
         animator[0].SetTrigger("State1");
         Debug.Log("hit1");
         flags[0] = true;
         CalledOnce[0] = true;
         //Camera.main.gameObject.GetComponent<ShakeCamera>().Shake();

      }
      else if (Area[1].IsHit == true && !CalledOnce[1])
      {
         animator[0].SetTrigger("State2");
         Debug.Log("hit1");
         flags[1] = true;
         CalledOnce[1] = true;

      }
      else if (Area[2].IsHit == true && !CalledOnce[2])
      {
         Time.timeScale = 1;
         StartCoroutine(BlackOut(blackBackground));
         Debug.Log("SceneChange");
         flags[2] = true;
         CalledOnce[2] = true;
         //完全に暗転したらシーン変更


      }
      //鍵取得時イベント
      else if (Area[3].IsHit == true && !CalledOnce[3])
      {
         //bool GetItem = ItemBox.instance.CanUseItem(Item.Type.Key);
         //Time.timeScale = 1; 

         //Debug.Log("SceneChange");

         Debug.Log("hit2");
         flags[3] = true;
         CalledOnce[3] = true;

         //Time.timeScale = 0;
         //StartCoroutine(LightOff());


         //完全に暗転したらシーン変更


      }
      //扉が閉まって音再生
      else if (Area[4].IsHit == true && !CalledOnce[4])
      {

         flags[4] = true;
         CalledOnce[4] = true;
         StartCoroutine(Gate());

      }
      //箪笥落下
      else if (Area[5].IsHit == true && !CalledOnce[5])
      {

         flags[5] = true;
         CalledOnce[5] = true;

         animator[2].SetTrigger("Fall");
         Invoke("TansuFall", 0.5f);
      }

      //お面落下
      else if (Area[6].IsHit == true && !CalledOnce[6])
      {

         flags[6] = true;
         CalledOnce[6] = true;

         animator[3].SetTrigger("Fall");

      }
      //懐中電灯テキスト表示
      else if (Area[7].IsHit == true && !CalledOnce[7])
      {

         flags[7] = true;
         CalledOnce[7] = true;


         explainText.StartCoroutine("AlphaUp");

      }
      //懐中電灯テキスト非表示
      else if (Area[7].IsOut == true && !CalledOnce[8])
      {

         flags[8] = true;
         CalledOnce[8] = true;
         explainText.StopCoroutine("AlphaUp");
         explainText.StartCoroutine("AlphaDown");

      }
      //アイテムテキスト表示
      else if (Area[8].IsHit == true && !CalledOnce[9])
      {

         flags[9] = true;
         CalledOnce[9] = true;


         explainText.StartCoroutine("AlphaUp");

      }
      //アイテムテキスト非表示
      else if (Area[8].IsOut == true && !CalledOnce[10])
      {

         flags[10] = true;
         CalledOnce[10] = true;
         explainText.StopCoroutine("AlphaUp");
         explainText.StartCoroutine("AlphaDown");
         // explainText.changetext(1);
         //Bunsyou.instance.changetext(12);          

      }
      //勾玉取得したら出現
      else if (Area[9].IsHitM == true && !CalledOnce[11] && GetItem == true)
      {

         Debug.Log("zikkou");
         flags[11] = true;
         CalledOnce[11] = true;
         audioSource.PlayOneShot(audioClip[4]);
         NarehateRun.SetActive(true);
         Destroy(NarehateRun, 4f);

      }
      //人形落下
      else if (Area[10].IsHit == true && !CalledOnce[12])
      {

         flags[12] = true;
         CalledOnce[12] = true;
         Nigyou.SetActive(true);
         Invoke("NingyoFall", 0.5f);

      }

      //ろうそく着く
      else if (Area[11].IsHit == true && !CalledOnce[13])
      {

         flags[13] = true;
         CalledOnce[13] = true;
         Rousoku.SetActive(true);


      }
      else if (Area[12].IsHit == true && !CalledOnce[14])
      {

         flags[14] = true;
         CalledOnce[14] = true;
         Rousoku.SetActive(false);


      }
      else if (Area[13].IsHit == true && !CalledOnce[15])
      {

         flags[15] = true;
         CalledOnce[15] = true;

         NarehateWalk.SetActive(true);
         animator[4].SetTrigger("Walk");
         Destroy(NarehateWalk, 10f);

      }
   }

   private void NingyoFall()
   {
      audioSource.PlayOneShot(audioClip[5]);
   }
   private void TansuFall()
   {
      //shakeCamera.Shake();
      audioSource.PlayOneShot(audioClip[2]);
   }

   private IEnumerator Gate()
   {
      animator[1].SetTrigger("Close");
      yield return new WaitForSeconds(0.7f);
      audioSource.PlayOneShot(audioClip[1]);
      yield return new WaitForSeconds(0.6f);
      //音量を下げる
      RainaudioSource.SetActive(false);
      RainaudioSourceClose.SetActive(true);
   }
   //暗転させる

   private IEnumerator BlackOut(Image black)
   {
      float fadeSpeed = 0.45f;

      while (black.color.a < 1f)
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
