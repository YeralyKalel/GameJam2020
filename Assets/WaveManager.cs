﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    #region Singleton

    public static WaveManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("You have more than one instance of this");
        }
    }

    #endregion


    public float timeBtwWaves;
    private float currentTime;
    public bool isActive;

    public TMP_Text textObject;

    int currentWave;
    bool isSpawning;


    public PlayerShooting playerShooting;

    public void Initialize()
    {
        Activate(false);
        Reset();
    }

    public void Activate(bool val)
    {
        isActive = val;
    }

    public void Reset()
    {
        currentTime = 0;
        currentWave = 0;
        isSpawning = false;
    }

    private void Update()
    {
        if (!isActive)
        {
            if (isSpawning)
            {
                Transform spawnPointParent = transform.GetChild(0);
                for (int p = 0; p < spawnPointParent.childCount; p++)
                {
                    spawnPointParent.GetChild(p).GetComponent<Spawnpoint>().StopSpawning();
                }
                isSpawning = false;
            }
            return;
        }
        if(currentTime <= 0 || EnemyManager.instance.transform.childCount == 0)
        {
            //spawn new wave of enemies

            Transform spawnPointParent = transform.GetChild(0);

            currentWave++;
            isSpawning = true;
            for (int p = 0; p < spawnPointParent.childCount; p++)
            {
                spawnPointParent.GetChild(p).GetComponent<Spawnpoint>().Spawn(currentWave);
            }

            ChangeSpell();
            SetupText();
            currentTime = timeBtwWaves;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }

    void SetupText() {
        textObject.text = "Round " + currentWave.ToString();
        //Spell change text:
    }

    public void ChangeSpell()
    {
        int n = SpellStyle.GetNames(typeof(SpellStyle)).Length - 1;
        System.Random r = new System.Random();
        int rInt = r.Next(0, n);
        playerShooting.SetupSpelling((SpellStyle)(rInt + 1));
        //playerShooting.SetupSpelling(SpellStyle.Fireball);
    }
}
