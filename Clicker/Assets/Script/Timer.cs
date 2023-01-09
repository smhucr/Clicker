using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text myText;
    public void OnEnable()
    {
        StartCoroutine(TimerFunc(GameManager.instance.timeNumber));
    }
    private IEnumerator TimerFunc(int timer)
    {

        if (!GameManager.instance.endGame)
            myText.text = timer.ToString();
        yield return new WaitForSeconds(1f);
        if (timer > 0 && !GameManager.instance.endGame)
            StartCoroutine(TimerFunc(timer - 1));
        else if (timer == 0 && !GameManager.instance.endGame)
        {
            GameManager.instance.GameOver();
            GameManager.instance.restartObject.SetActive(true);
        }

    }
}
