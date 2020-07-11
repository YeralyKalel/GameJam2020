using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    private bool currentlySpawning = false;
    private int enemiesToSpawn;

    public GameObject enemy;

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

        InvokeRepeating("SpawnEnemy", 0.5f, 2.3f);
    }

    void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, transform.rotation, EnemyManager.instance.transform);
        enemiesToSpawn--;
    }
}
