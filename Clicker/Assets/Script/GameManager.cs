using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject score;
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
        endGame = false;
        startGame = true;
        startObject.SetActive(false);
        timeObject.SetActive(false);
        timerField.SetActive(false);
        score.SetActive(true);
        timer.SetActive(true);
        restartObject.SetActive(true);
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
        endGame = true;
        startGame = false;
    }


}
