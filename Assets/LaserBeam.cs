using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LaserBeam : MonoBehaviour
{
    public float offset;

    private void Update()
    {
        if (!Input.GetMouseButton(0) || transform.parent.GetComponent<PlayerShooting>().spellStyle != SpellStyle.LaserBeam)
        {
            gameObject.SetActive(false);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        string collisonTag = collision.tag;
        if (collisonTag == "Environment")
        {
            //Shorten the length of beam until environment using ray
        }
        else if (collisonTag == "Enemy")
        {
            //Put animation as input to Die function (cut into two)
            collision.GetComponent<EnemyController>().TakeDamage(1);
            Camera.main.GetComponent<CameraShake>().Shake(0.015f, 0.05f);
        }
    }

    private void DestroyObject()
    {

        Destroy(gameObject);
    }

}
