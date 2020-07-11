using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    bool targetSet = false;

    public float destroyTime = 5f;
    private float currentTime = 0f;

    public float travelSpeed;
   

    private void Update()
    {
        if (targetSet)
        {
            currentTime += Time.deltaTime;
            if (currentTime > destroyTime) Destroy(gameObject);
            transform.Translate(Vector2.up * travelSpeed * Time.deltaTime);
        }
    }


    public void SetTarget(Vector3 target)
    {
        targetSet = true;
        currentTime = 0f;

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
        if (collision.CompareTag("Environment"))
        {
            Destroy(gameObject);
        }
    }

}
