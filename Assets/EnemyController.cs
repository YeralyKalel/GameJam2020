using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum EnemyType { melee, ranged};

    public EnemyType enemyType;


    public EnemyCombat enemyCombat;
    // Start is called before the first frame update

    public void Die()
    {
        enemyCombat.Die();

    }
}
