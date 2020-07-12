using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 targetPos;

    public float smoothSpeed;
    public Vector3 offset;

    private bool isActive;

    public void Initialize()
    {
        isActive = false;
    }

    public void StartGame()
    {
        isActive = true;
    }

    private void FixedUpdate()
    {
        if (!isActive) return;
        targetPos = new Vector3(target.position.x, target.position.y, -10);
        Vector3 desiredPosition = targetPos + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        transform.position = smoothedPosition;
    }

}
