using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    bool falling = true;
    public float fallSpeed;
    public float fallTime;
    public float destroyDelay;
    private float distanceTravelled;

    public ParticleSystem explosion;

    private void Update()
    {
        if (falling)
        {
            transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        }
    }

   public void startTimer()
    {
        StartCoroutine(timer());
    }

   private IEnumerator timer()
    {
        print("This was called");
        yield return new WaitForSeconds(fallTime);
        falling = false;

        GetComponent<BoxCollider2D>().enabled = true;

        //spawn particles
        Instantiate(explosion, transform.position, transform.rotation, ParticleParent.instance.transform);
        Camera.main.GetComponent<CameraShake>().Shake(0.05f, 0.3f);
        PlayerAudio.instance.LargeExplosion();
        Destroy(gameObject, destroyDelay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyController>().TakeDamage(100);
        }
    }





}
