using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaHit : MonoBehaviour
{
    public bool IsHit,IsOut,IsHitM,IsStay = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsHit = true;
            IsHitM = true;
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsOut = true;
            IsHitM = false;
            
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsStay = true;
            
        }
        else
        {
            IsStay = false;
        }
    }
}
