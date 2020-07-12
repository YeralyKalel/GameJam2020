using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public WaveManager waveManager;
    public UIManager uiManager;
    public CameraFollow cameraManager;

    private void Awake()
    {
        Initialize();
    }

    private bool showTutorial;

    private void Initialize()
    {
        uiManager.StartGameAction += SetupEnvironment;
        uiManager.TutorialFinishedAction += StartGame;
        uiManager.Initialize();
        cameraManager.Initialize();
        waveManager.Initialize();
        playerController.Initialize();
        showTutorial = true;
    }
    private void SetupEnvironment()
    {
        SetupPlayer();
        if (showTutorial)
        {
            showTutorial = false;
            uiManager.ShowTutorial();
        }
        else
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        playerController.Activate();
        cameraManager.StartGame();
        waveManager.StartWave();
    }

    public void SetupPlayer()
    {
        playerController.Setup();
    }
}
