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


    //Ranged attack variables
    private bool readyToAttack = true;
    public float attackSpeed;
    public GameObject enemyProjectile;


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
        if (GetComponent<EnemyController>().enemyType == EnemyController.EnemyType.melee)
        {
            //Check if it is melee first, if it is not: "return;"
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


    public void RangedAttack() //This is called externally by the movement script
    {
        if (readyToAttack)
        {
            //Spawn Projectile

            GameObject objectInstantiated = Instantiate(enemyProjectile, transform.position, transform.rotation);
            objectInstantiated.GetComponent<EnemyProjectile>().SetTargetAndRotation(PlayerController.instance.transform.position);

            StartCoroutine(ResetAttack());
        }
    }

    IEnumerator ResetAttack()
    {
        readyToAttack = false;
        yield return new WaitForSeconds(1/attackSpeed);
        readyToAttack = true;

    }


}
