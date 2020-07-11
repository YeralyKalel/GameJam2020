using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    private PlayerController player;
    public void Die()
    {
        //Die animation
        Destroy(gameObject);
    }

    public void SetPlayer(PlayerController player)
    {
        this.player = player;
    }
}
