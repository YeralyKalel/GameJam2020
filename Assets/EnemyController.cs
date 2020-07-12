using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum EnemyType { melee, ranged};

    public EnemyType enemyType;

    public int health;


    public EnemyCombat enemyCombat;
    // Start is called before the first frame update

    public void SetPlayer()
    {

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
        enemyCombat.Die();

    }
}
