using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum UIState{MAIN_MENU, OPTIONS, CREDITS};

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;
    public GameObject creditsPanel;
    private UIState currentState;

    void Start()
    {
        currentState = UIState.MAIN_MENU;
        CleanUI();
        mainMenuPanel.SetActive(true);
    }

    void CleanUI()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void creditos()
    {
        SceneManager.LoadScene(2);
    }
    public void inicio()
    {
        SceneManager.LoadScene(0);
    }
    public void salir()
    {
        Application.Quit();
    }
}
