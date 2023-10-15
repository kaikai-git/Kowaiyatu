using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGetGimmick : MonoBehaviour
{
    
    private AudioSource audioSource;
    public static bool LightOn = true;

  void Start()
  {
    audioSource = GetComponent<AudioSource>();
  }

  public void KeyGetEvent()
  {
    StartCoroutine( LightOff());

  }
 

  private IEnumerator LightOff()
  {
    Debug.Log("hit");
    bool GetItem = ItemBox.instance.CanUseItem(Item.Type.Key);
      if(GetItem == true)
      {
        LightOn = false;

      
       yield return new WaitForSeconds(2.0f);
       LightOn = true;
      }
  }
}
