using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public float timeBtwWaves;
    private float currentTime;

    int currentWave = 1;

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

            currentWave ++;
            currentTime = timeBtwWaves;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }
}
