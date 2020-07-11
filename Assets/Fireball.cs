using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    bool targetSet = false;
    public float travelSpeed;
    public float maxDistance;
    private float travelDistance = 0f;
    
    public int nKills = 1;

    private void Update()
    {
        if (targetSet)
        {
            if (travelDistance > maxDistance) DestroyObject();
            float deltaDistance = travelSpeed * Time.deltaTime;
            transform.Translate(Vector2.up * deltaDistance);
            travelDistance += deltaDistance;
        }
    }


    public void SetupFireball(Vector3 target)
    {
        targetSet = true;
        travelDistance = 0f;
        Vector3 direction = target - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (target.x >= transform.position.x)
        {
            if (target.y >= transform.position.y)
            {
                angle = 90 - angle;
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -angle);
            }
            else
            {
                angle = angle - 90;
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
            }
        }
        else
        {
            if (target.y >= transform.position.y)
            {
                angle = angle - 90;
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
            }
            else
            {
                angle = 90 + (180 + angle);
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string collisonTag = collision.tag;
        if (collisonTag == "Environment")
        {
            DestroyObject();
        } else if (collisonTag == "Enemy")
        {
            if (nKills < 1) return;
            //Put animation as input to Die function
            nKills--;
            collision.GetComponent<EnemyController>().Die();
            DestroyObject();
        }
    }

    private void DestroyObject()
    {
        //Add destroy animation here
        Destroy(gameObject);
    }

}
