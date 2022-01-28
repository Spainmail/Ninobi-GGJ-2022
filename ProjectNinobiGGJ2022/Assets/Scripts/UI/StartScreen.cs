using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartScreen : MonoBehaviour
{
    
    [Header("Levels")]
    public string[] levels;
    public EventSystem eventSystem;
    public GameObject initialSelection;

    [Header("Credits")]
    private bool creditsVisible;
    public GameObject credits;

    private void Start()
    {
        eventSystem.SetSelectedGameObject(initialSelection);
    }

    public void StartGame(int chosenLevel)
    {
        SceneManager.LoadScene(levels[chosenLevel]);
    }

    public void ToggleCredits()
    {
        if (creditsVisible == true)
        {
            creditsVisible = false;
            credits.SetActive(false);
        }
        else
        {
            creditsVisible = true;
            credits.SetActive(true);
        }
    }

    public void ReturnToStart()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
