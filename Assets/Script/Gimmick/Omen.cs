using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Omen : MonoBehaviour
{
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
         
    }

    public void fallomen()
    {
        audio.Play();
    }
}
