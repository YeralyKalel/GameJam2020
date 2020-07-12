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

    private bool isPause;
    private bool showTutorial;
    private List<EnemyController> enemyControllers;

    private void Initialize()
    {
        uiManager.StartGameAction += SetupEnvironment;
        uiManager.TutorialFinishedAction += StartGame;
        playerController.GameOver += GameOver;

        uiManager.Initialize();
        cameraManager.Initialize(); 
        waveManager.Initialize();
        playerController.Initialize();

        showTutorial = true;
        isPause = false;

        enemyControllers = new List<EnemyController>();
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
        foreach (EnemyController e in enemyControllers)
        {
            if (e == null) continue;
            Destroy(e.gameObject);
        }
        enemyControllers = new List<EnemyController>();
        waveManager.Reset();

        playerController.Activate(true);
        cameraManager.Activate(true);
        waveManager.Activate(true);
    }
    private void GameOver()
    {
        uiManager.GameOver();
        StopGame();
    }

    private void StopGame()
    {
        isPause = true;
        waveManager.Activate(false);
        playerController.Activate(false);
        cameraManager.Activate(false);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        enemyControllers = new List<EnemyController>();
        foreach (GameObject enemy in enemies)
        {
            EnemyController temp = enemy.GetComponent<EnemyController>();
            temp.Activate(false);
            enemyControllers.Add(temp);
        }
    }

    public void SetupPlayer()
    {
        playerController.Setup();
    }
}
