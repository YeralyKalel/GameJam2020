using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region Singleton

    public static EnemyManager instance;
    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("You have more than one instance of this script!!!!");
        }
    }

    #endregion

    public Transform player;
    public float startDelay;

    public int playerX;
    public int playerY;


    private void Update() //Maybe make it update every however much time rather than every frame as that is very expensive
    {        
       playerX = Mathf.RoundToInt(player.position.x - 0.5f);
       playerY = Mathf.RoundToInt(player.position.y - 0.5f);

    }



}
