using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGameButton : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject TutorialPanel;

    public void StartGame()
    {
        MainMenu.SetActive(false);
        HUD.SetActive(true);
        TutorialPanel.SetActive(true);
    }
}
