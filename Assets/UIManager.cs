using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject GameUI;
    public GameObject TutorialUI;
    public GameObject GameOverUI;
    public GameObject HealthBarUI;
    public GameObject RoundNumberUI;

    public Button startButton;
    public Button quitButtonMainMenu;
    public Button tutorialFinishButton;
    public Button rematchButton;
    public Button quitButtonGame;

    public Action StartGameAction;
    public Action TutorialFinishedAction;

    public void Initialize()
    {
        ActivateMainMenu(true);
        startButton.onClick.AddListener(StartGame);
        quitButtonMainMenu.onClick.AddListener(QuitGame);
        rematchButton.onClick.AddListener(StartGame);
        quitButtonGame.onClick.AddListener(QuitGame);
    }

    public void ShowTutorial()
    {
        TutorialUI.SetActive(true);
        GameOverUI.SetActive(false);
        HealthBarUI.SetActive(false);
        RoundNumberUI.SetActive(false);
        tutorialFinishButton.onClick.AddListener(FinishTutorial);
    }

    private void FinishTutorial()
    {
        tutorialFinishButton.onClick.RemoveAllListeners();
        TutorialFinishedAction();
        TutorialUI.SetActive(false);
        HealthBarUI.SetActive(true);
        RoundNumberUI.SetActive(true);
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
    }



    public void StartGame()
    {
        GameOverUI.SetActive(false);
        ActivateMainMenu(false);
        StartGameAction(); 
    }
    public void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
         Application.Quit();
    #endif
    }

    public void ActivateMainMenu(bool isActive)
    {
        MainMenuUI.SetActive(isActive);
        GameUI.SetActive(!isActive);
    }
}
