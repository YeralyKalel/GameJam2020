using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyCombat enemyCombat;
    // Start is called before the first frame update

    public void SetPlayer()
    {

    }

    public void Die()
    {
        enemyCombat.Die();

    }
}
