using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region Singleton

    public static EnemyManager instance;
    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("You have more than one instance of this script!!!!");
        }
    }

    #endregion

    public Transform player;
    public float startDelay;

    public int playerX;
    public int playerY;


    //Particles
    public ParticleSystem speedBuff;
    public ParticleSystem healthBuff;
    public ParticleSystem attackSpeedBuff;


    private void Start()
    {
        InvokeRepeating("ChooseEnemyToBuff", 2.5f, WaveManager.instance.timeBtwWaves);
    }


    private void Update() //Maybe make it update every however much time rather than every frame as that is very expensive
    {        
       playerX = Mathf.RoundToInt(player.position.x - 0.5f);
       playerY = Mathf.RoundToInt(player.position.y - 0.5f);

    }


    void ChooseEnemyToBuff()
    {
        if(transform.childCount > 0)
        {
            int randNum = Random.Range(0, transform.childCount);
            GameObject enemyToBuff = transform.GetChild(randNum).gameObject;

            //now get a random buff

            //Double speed - White particles
            //Double Health - Red particles
            //Double attack speed - Light purple/ pink ish Particles

            int n = Random.Range(0, 3);

            if (n == 0)
            {
                //Double speed
                enemyToBuff.GetComponent<EnemyMovement>().moveSpeed = enemyToBuff.GetComponent<EnemyMovement>().moveSpeed * 2;
                Instantiate(speedBuff, enemyToBuff.transform.position, enemyToBuff.transform.rotation, enemyToBuff.transform);

            }
            else if (n == 1)
            {
                //Double Health
                enemyToBuff.GetComponent<EnemyController>().health = enemyToBuff.GetComponent<EnemyController>().health * 2;
                Instantiate(healthBuff, enemyToBuff.transform.position, enemyToBuff.transform.rotation, enemyToBuff.transform);
            }
            else
            {
                //Double attack speed
                if (enemyToBuff.GetComponent<EnemyController>().enemyType == EnemyController.EnemyType.ranged)
                {
                    enemyToBuff.GetComponent<EnemyCombat>().attackSpeed = enemyToBuff.GetComponent<EnemyCombat>().attackSpeed * 2;

                }
                else
                {
                    //Double speed if melee
                    enemyToBuff.GetComponent<EnemyMovement>().moveSpeed = enemyToBuff.GetComponent<EnemyMovement>().moveSpeed * 2;
                    Instantiate(speedBuff, enemyToBuff.transform.position, enemyToBuff.transform.rotation, enemyToBuff.transform);
                }

            }
        }

    }



}
