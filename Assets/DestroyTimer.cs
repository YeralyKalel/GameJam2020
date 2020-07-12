using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public float timeTillDestroy;

    private void Start()
    {
        Destroy(gameObject, timeTillDestroy);
    }
}
