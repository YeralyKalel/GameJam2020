using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private float smoothAngle;

    public Rigidbody2D rb;

    private void Start()
    {
        smoothAngle = 0f;
    }

    void Update()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        target = new Vector3(target.x - transform.position.x, target.y - transform.position.y, 0);
        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        smoothAngle = Mathf.LerpAngle(smoothAngle, angle, 0.7f);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, smoothAngle));

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

        rb.velocity = movement;
    }


}
