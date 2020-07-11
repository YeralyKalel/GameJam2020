using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    bool targetSet = false;
    public float travelSpeed;
    public float maxDistance;
    private float travelDistance = 0f;

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



    public void SetTargetAndRotation(Vector3 target)
    {
        print("This is getting run");

        travelDistance = 0f;
        targetSet = true;

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
        }
        else if (collisonTag == "Player")
        {
            collision.GetComponent<PlayerController>().GetDamage();
            DestroyObject();
        }
    }



    private void DestroyObject()
    {
        //Add destroy animation here
        Destroy(gameObject);
    }
}
