using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject temporaryBullet;


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 target;

            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target += new Vector3(0, 0, 10);

            GameObject projectileSpawned = Instantiate(temporaryBullet, transform.position, transform.rotation);
            projectileSpawned.GetComponent<Projectile>().SetTarget(target);

        }

    }
}
