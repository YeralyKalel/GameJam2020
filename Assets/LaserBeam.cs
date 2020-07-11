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
            DestroyObject();
        }
    }


    public void SetupLaserBeam()
    {
        gameObject.transform.localPosition = new Vector3(offset, 0, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        string collisonTag = collision.tag;
        if (collisonTag == "Environment")
        {
            //Shorten the length of beam until environment using ray
        } else if (collisonTag == "Enemy")
        {
            //Put animation as input to Die function (cut into two)
            collision.GetComponent<EnemyController>().Die();
        }
    }
    private void DestroyObject()
    {

        Destroy(gameObject);
    }

}
