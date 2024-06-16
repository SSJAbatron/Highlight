using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public int score = 0;
    public GameObject PlayerRef;
    public bool loseGame = false;
    public GameObject DeathVFX, PauseMenuPanel,TutorialPanel,GameOverPanel, DeathZone, PlayerDialogue1, PlayerDialogue2,LevelGenerator;
    public Slider slider;
    public Image sliderImageColor;
    public TMP_Text scoreText, gameOverScoreText;
    public bool gameStart;
    public Light2D GlobalLight;


    private void Start()
    {
        if(Time.timeScale == 0f)
            Time.timeScale = 1f;
        PlayerRef.GetComponent<PlayerInput>().DeactivateInput();
    }

    private void Update()
    {
        // game start condition
        if(gameStart)
        {
            StartCoroutine(PlayCutScene());
            LevelGenerator.SetActive(true);
            AudioManager.instance.PlayMusic("Background");
            gameStart = false;
        }
        //lose game condition
        if (loseGame)
        {
            PlayerRef.SetActive(false);
            GameObject VFX = Instantiate(DeathVFX,PlayerRef.transform.position, Quaternion.identity);
            Destroy(VFX,0.5f);
            // show score panel
            GameOverPanel.SetActive(true);
            if (score < 10)
                gameOverScoreText.text = "Your Score was: 00" + score.ToString();
            else if (score < 100)
                gameOverScoreText.text = "Your Score was: 0" + score.ToString();
            else
                gameOverScoreText.text = "Your Score was: " + score.ToString();
            loseGame = false;
        }


       
    }
  

    IEnumerator PlayCutScene()
    {
        PlayerDialogue1.SetActive(true);
        Destroy(PlayerDialogue1,3f);
        yield return new WaitForSeconds(2f);
        GlobalLight.intensity = 0.1f;
        PlayerDialogue2.SetActive(true);
        Destroy(PlayerDialogue2, 3f);
        yield return new WaitForSeconds(1f);
        PlayerRef.GetComponent<PlayerInput>().ActivateInput();
    }


    public void ActivateDeathZone()
    {
        if (DeathZone.activeSelf == false)
            DeathZone.SetActive(true);
    }


    public void ChangeSliderColorTemp()
    {
        sliderImageColor.color = Color.red;
        StartCoroutine(ChangeColorBack());
    }


    IEnumerator ChangeColorBack()
    {
        yield return new WaitForSeconds(1f);
        sliderImageColor.color = new Color(255, 241, 190);
    }


    public void UpdateLanternBrightnessSlider()
    {
        slider.value = PlayerRef.transform.GetChild(0).gameObject.GetComponent<Light2D>().pointLightOuterRadius/7f;
    }

    public void UpdateScore()
    {
        score += 1;
        if(score < 10)
            scoreText.text = "Score: 00" + score.ToString();
        else if(score < 100)
            scoreText.text = "Score: 0" +score.ToString();
        else
            scoreText.text = "Score: " + score.ToString();
    }

    public void StartGame()
    {
        TutorialPanel.SetActive(false);
        gameStart= true;
    }
    
    public void PauseGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

            if (Time.timeScale == 1f)
            {
                PauseMenuPanel.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                PauseMenuPanel.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

}
