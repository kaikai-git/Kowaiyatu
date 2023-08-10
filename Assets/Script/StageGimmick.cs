using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGimmick : MonoBehaviour
{
    [SerializeField] AreaHit[] Area;
     bool[] flags = new bool[3];
     
     public bool[] Flags {get => flags;}
    
    void Start()
    {
        flags[0] = false;
        flags[1] = false;
        flags[2] = false;
    }

    void Update()
    {
        IsHit();
    }
    public void IsHit()
    {      
       
        if( Area[0].IsHit == true)
        {
            Debug.Log("hit2");
            flags[0] = true;
        }
            
                 
    }
}
