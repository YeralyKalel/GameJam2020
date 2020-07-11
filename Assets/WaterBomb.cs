using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBomb : MonoBehaviour
{
    public BoxCollider2D boxCollider;

    private int currentBounces;
    public int nBounces;

    private bool onGround;

    public float maxSpeed;

    private float currentBounceDisplacement;
    public float maxBounceDistance;

    private float currentSize;
    public float sizeUp;
    public float sizeDown;

    public float explosionRange;
    private bool isDestroying;

    public float explosionTime;

    public int nKills = 1;

    // Update is called once per frame
    void Update()
    {
        if (isDestroying) return;
        if (currentBounces < nBounces)
        {
            if (currentBounceDisplacement < 0.5*maxBounceDistance)
            {
                onGround = false;
                float t = currentBounceDisplacement / (0.5f * maxBounceDistance);
                currentSize = sizeDown * (1 - t) + sizeUp * t;
                this.gameObject.transform.localScale = Vector3.one * currentSize;
            }
            else if (currentBounceDisplacement < maxBounceDistance)
            {
                onGround = false;
                float t = (currentBounceDisplacement - 0.5f*maxBounceDistance) / (0.5f * maxBounceDistance);
                currentSize = sizeDown * t + sizeUp * (1 - t);
                this.gameObject.transform.localScale = Vector3.one * currentSize;
            }
            else
            {
                onGround = true;
                nKills = 1;
                currentBounceDisplacement = 0;
                currentBounces++;
            }
            float deltaDistance = maxSpeed * Time.deltaTime;
            transform.Translate(Vector2.up * deltaDistance);
            currentBounceDisplacement += deltaDistance;
        } else
        {
            DestroyObject();
        }
    }

    public void SetupWaterBomb(Vector3 target)
    {
        isDestroying = false;
        onGround = false;
        currentSize = sizeDown;
        currentBounceDisplacement = 0f;
        currentBounces = 0;

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
                angle -= 90;
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
            }
        }
        else
        {
            if (target.y >= transform.position.y)
            {
                angle -= 90;
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
            }
            else
            {
                angle += 270;
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject == null) return;
        string collisionTag = collision.tag;
        if (collisionTag == "Environment")
        {
            DestroyObject();
        }
        if (onGround)
        {
            if (collisionTag == "Enemy")
            {
                if (isDestroying)
                {
                    //Put animation as input to Die function (explode)
                    collision.GetComponent<EnemyController>().Die();
                }
                else
                {
                    if (nKills < 1) return;
                    nKills--;
                    //Put animation as input to Die function (hit)
                    collision.GetComponent<EnemyController>().Die();
                }
            }
        }
    }

    private void DestroyObject()
    {
        if (isDestroying) return;
        onGround = true;
        isDestroying = true;
        boxCollider.size = Vector2.one * explosionRange;
        Destroy(gameObject, explosionTime);
    }

}
