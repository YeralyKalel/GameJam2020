using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public float timeBtwWaves;
    private float currentTime;

    int currentWave = 1;


    public PlayerShooting playerShooting;


    private void Update()
    {
        if(currentTime <= 0)
        {
            //spawn new wave of enemies

            Transform spawnPointParent = transform.GetChild(0);

            for (int p = 0; p < spawnPointParent.childCount; p++)
            {
                spawnPointParent.GetChild(p).GetComponent<Spawnpoint>().Spawn(currentWave);
            }

            ChangeSpell();            
            currentWave ++;
            currentTime = timeBtwWaves;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }

    void ChangeSpell()
    {
        int n = SpellStyle.GetNames(typeof(SpellStyle)).Length - 1;
        System.Random r = new System.Random();
        int rInt = r.Next(0, n);
        playerShooting.SetupSpelling((SpellStyle)(rInt + 1));
        //playerShooting.SetupSpelling(SpellStyle.Fireball);
    }
}
