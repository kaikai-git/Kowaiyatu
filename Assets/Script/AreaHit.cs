using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaHit : MonoBehaviour
{
    public bool IsHit = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsHit = true;
            Debug.Log("hit");
        }
    }
}
