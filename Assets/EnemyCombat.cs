using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    private PlayerController player;
    int n;

    private float currentDamageInterval;
    public float minDamageInterval = 2f;

    public float distanceThreshold = 0.5f;
    public void Die()
    {
        //Die animation
        Destroy(gameObject);
    }

    void Start()
    {
        currentDamageInterval = minDamageInterval;
        SetPlayer();
        n = 0;
    }

    public void SetPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        currentDamageInterval += Time.deltaTime;
        if (currentDamageInterval < minDamageInterval) return;
        if (n == 2)
        {
            float distance = Vector3.Distance(player.transform.position, this.transform.position);

            if (distance < distanceThreshold)
            {
                player.GetDamage();
                currentDamageInterval = 0;
            }
        }
        n = ++n % 3;
    }
}
