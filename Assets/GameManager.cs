using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    // Start is called before the first frame update
    private void Awake()
    {
        StartGame();
    }
    private void StartGame()
    {
        SetupPlayer();
    }

    public void SetupPlayer()
    {
        playerController.Setup();
    }
}
