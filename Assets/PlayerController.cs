using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Singleton

    public static PlayerController instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("There is more than one instance of this");
        }
    }

    #endregion
    

    public PlayerShooting playerShooting;
    public PlayerMovement playerMovement;
    public Action GameOver;

    private int currentHealth;
    public int maxHealth;
    private bool isDead;

    //Crystal UI
    public GameObject healthUIParent;
    
    public void Setup()
    {
        //Change later
        currentHealth = maxHealth;

        if(maxHealth > healthUIParent.transform.childCount)
        {
            print("MAX HEALTH IS GREAT THAT CRYSTALS AVAILABLE PLS LOWER THE MAX HEALTH");
        }
        else
        {
            for (int p = 0; p < maxHealth; p++)
            {
                healthUIParent.transform.GetChild(p).gameObject.SetActive(true);
            }
        }

        isDead = false;
    }

    public void Initialize()
    {
        Activate(false);
    }

    public void Activate(bool val)
    {
        playerShooting.Activate(val);
        playerMovement.Activate(val); ;
    }

    public void GetDamage()
    {
        if (isDead) return;


        healthUIParent.transform.GetChild(currentHealth - 1).gameObject.SetActive(false);
        currentHealth--;
        if (currentHealth > 0)
        {
            //Hit animation on player
        } else
        {
            //Game over
            GameOver();
            isDead = true;
        }
    }


}
