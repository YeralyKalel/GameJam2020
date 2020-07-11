using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    private bool currentlySpawning = false;
    private int enemiesToSpawn;

    public GameObject meleeEnemy;
    public GameObject rangedEnemy;

    private void Update()
    {
        if (currentlySpawning)
        {
            if(enemiesToSpawn <= 0)
            {
                CancelInvoke();
                currentlySpawning = false;
            }
        }
    }



    public void Spawn(int currentWave)
    {
        currentlySpawning = true;
        enemiesToSpawn = Random.Range(currentWave, currentWave * 2);

        InvokeRepeating("SpawnEnemy", 0f, 2.3f);
    }

    void SpawnEnemy()
    {
        int n = Random.Range(0, 3);

        if(n== 0)
        {
            //spawn ranged enemy
            Instantiate(rangedEnemy, transform.position, transform.rotation, EnemyManager.instance.transform);
        }
        else
        {
            //spawn melee enemy
            Instantiate(meleeEnemy, transform.position, transform.rotation, EnemyManager.instance.transform);
        }

        
        enemiesToSpawn--;
    }
}
