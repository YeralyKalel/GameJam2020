using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    private PlayerController player;
    int n;

    public float distanceThreshold = 0.1f;
    public void Die()
    {
        //Die animation
        Destroy(gameObject);
    }

    void Start()
    {
        SetPlayer();
        n = 0;
    }

    public void SetPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        Debug.Log(n);
        if (n == 2)
        {
            float distance = Vector3.Distance(player.transform.position, this.transform.position);

            Debug.Log(distance);
            if (distance < distanceThreshold)
            {
                player.GetDamage();
            }
        }
        n = ++n % 3;
    }
}
