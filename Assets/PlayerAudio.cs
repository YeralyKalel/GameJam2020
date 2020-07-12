using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{ 
    #region Singleton

    public static PlayerAudio instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("More than one instance of this, this is a big error, please remove this error");
        }
    }

    #endregion



    public AudioClip getHit;
    public AudioClip enemyDead;
    public AudioClip laserStart;
    public AudioClip smallExplosion;
    public AudioClip largeExplosion;
    public AudioClip waterBomb;



    AudioSource ads;

    private void Start()
    {
        ads = GetComponent<AudioSource>();
    }

    public void PlayGetHit()
    {
        if (!ads.isPlaying)
        {
            ads.PlayOneShot(getHit);
        }
    }

    public void EnemyDead()
    {
        if (!ads.isPlaying)
        {
            ads.PlayOneShot(enemyDead);
        }
    }

    public void LaserStart()
    {
        if (!ads.isPlaying)
        {
            ads.PlayOneShot(laserStart);
        }
    }

    public void SmallExplosion()
    {
        if (!ads.isPlaying)
        {
            ads.PlayOneShot(smallExplosion);
        }
    }

    public void LargeExplosion()
    {
        if (!ads.isPlaying)
        {
            ads.PlayOneShot(largeExplosion);
        }
    }

    public void WaterBomb()
    {
        if (!ads.isPlaying)
        {
            ads.PlayOneShot(waterBomb);
        }
    }

}
