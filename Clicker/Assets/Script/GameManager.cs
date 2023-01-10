using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject score;
    public GameObject highScore;
    public GameObject timer;
    [HideInInspector] public int timeNumber;
    public GameObject startObject;
    public GameObject timeObject;
    public GameObject timerField;
    public GameObject restartObject;
    public bool startGame;
    public bool endGame;
    private void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        Screen.SetResolution(1080, 1920, true);
    }

    private void Awake()
    {
        MakeInstance();
    }

    public void StartGame()
    {
        if (timeNumber != 0)
        {
            score.GetComponent<Text>().text = 0.ToString();
            endGame = false;
            startGame = true;
            startObject.SetActive(false);
            timeObject.SetActive(false);
            timerField.SetActive(false);
            highScore.SetActive(false);
            score.SetActive(true);
            timer.SetActive(true);
        }
        else
        {
            timerField.transform.DOShakeRotation(1, 40, 10, 60).OnComplete(() => timerField.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

    public void BackToStart()
    {
        startObject.SetActive(true);
        timeObject.SetActive(true);
        timerField.SetActive(true);
        score.SetActive(false);
        timer.SetActive(false);
        restartObject.SetActive(false);
    }

    public void TimerValue(string text)
    {
            timeNumber = int.Parse(text);
    }

    public void GameOver()
    {
        if (endGame)
        {
            return;
        }
        PlayerPrefs.SetInt("HighScore" + timeNumber.ToString(), int.Parse(score.GetComponent<Text>().text));
        restartObject.SetActive(true);
        endGame = true;
        startGame = false;
    }

    public void HighScoreDisplay()
    {
        if (!highScore.activeInHierarchy)
            highScore.SetActive(true);
        highScore.GetComponent<Text>().text = "High Score of " + timeNumber.ToString() + " s         " + PlayerPrefs.GetInt("HighScore" + timeNumber.ToString(), 0);
    }


}
