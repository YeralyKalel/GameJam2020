using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerShooting playerShooting;
    
    public void Setup()
    {
        int n = SpellStyle.GetNames(typeof(SpellStyle)).Length - 1;
        System.Random r = new System.Random();
        int rInt = r.Next(0, n);
        //playerShooting.SetupSpelling((SpellStyle) (rInt + 1));
        playerShooting.SetupSpelling(SpellStyle.LaserBeam);
    }


}
