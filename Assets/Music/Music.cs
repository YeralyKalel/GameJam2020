using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    AudioSource ads;

    private void Start()
    {
        ads = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!ads.isPlaying)
        {
            ads.Play();
        }
    }
}
