using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject GameOverMenu;

    public void QuitTheGame()
    {
        Application.Quit();
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
