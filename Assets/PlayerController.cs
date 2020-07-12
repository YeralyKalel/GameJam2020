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

    public GameObject GameOverPanel;
    

    public PlayerShooting playerShooting;
    public PlayerMovement playerMovement;
    public Action GameOver;

    private int currentHealth;
    public int maxHealth;
    private bool isDead;
    
    public void Setup()
    {
        //Change later
        currentHealth = 3;
        //
        GameOverPanel.SetActive(false);

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
        currentHealth--;
        Debug.Log(currentHealth);
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
