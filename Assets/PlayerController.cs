﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerShooting playerShooting;
    private int currentHealth;
    public int maxHealth;
    private bool isDead;
    
    public void Setup()
    {
        //Change later
        currentHealth = 3;
        //

        isDead = false;
        int n = SpellStyle.GetNames(typeof(SpellStyle)).Length - 1;
        System.Random r = new System.Random();
        int rInt = r.Next(0, n);
        playerShooting.SetupSpelling((SpellStyle) (rInt + 1));
        //playerShooting.SetupSpelling(SpellStyle.Fireball);
    }

    public void GetDamage()
    {
        if (isDead) return;
        Debug.Log(currentHealth);
        currentHealth--;
        if (currentHealth > 0)
        {
            //Hit animation on player
        } else
        {
            //Game over
            Debug.Log("Game Over");
            isDead = true;
        }
    }


}
