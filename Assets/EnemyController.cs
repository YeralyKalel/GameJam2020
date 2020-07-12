using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum EnemyType { melee, ranged};

    public EnemyType enemyType;

    public int health;


    public EnemyCombat enemyCombat;
    public EnemyMovement enemyMovement;

    private void Start()
    {
        Activate(true);
    }

    public void Activate(bool val)
    {
        enemyCombat.Activate(val);
        enemyMovement.Activate(val);
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        Camera.main.GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }
}
