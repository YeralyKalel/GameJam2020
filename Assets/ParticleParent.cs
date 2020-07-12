using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleParent : MonoBehaviour
{
    public static ParticleParent instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("More than one instance of this");
        }
    }
}
