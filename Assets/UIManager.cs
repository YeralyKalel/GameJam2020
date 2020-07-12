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

    public Button startButton;
    public Button quitButton;
    public Button tutorialFinishButton;

    public Action StartGameAction;
    public Action TutorialFinishedAction;

    public void Initialize()
    {
        ActivateMainMenu(true);
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void ShowTutorial()
    {
        TutorialUI.SetActive(true);
        tutorialFinishButton.onClick.AddListener(FinishTutorial);
    }

    private void FinishTutorial()
    {
        tutorialFinishButton.onClick.RemoveAllListeners();
        TutorialFinishedAction();
        TutorialUI.SetActive(false);
    }



    public void StartGame()
    {
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
