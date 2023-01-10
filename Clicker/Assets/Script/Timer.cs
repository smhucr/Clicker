using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Timer : MonoBehaviour
{
    public Text myText;
    public void OnEnable()
    {
        StartCoroutine(TimerFunc(GameManager.instance.timeNumber));
        gameObject.transform.DOScale(1.3f, 1).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
    private IEnumerator TimerFunc(int timer)
    {

        if (!GameManager.instance.endGame)
            myText.text = timer.ToString();
        yield return new WaitForSeconds(1f);
        if (timer > 1 && !GameManager.instance.endGame)
            StartCoroutine(TimerFunc(timer - 1));
        else if (timer == 1 && !GameManager.instance.endGame)
        {
            timer -= 1;
            myText.text = timer.ToString();
            GameManager.instance.GameOver();
            GameManager.instance.restartObject.SetActive(true);
        }
        else if (timer == 0 && !GameManager.instance.endGame)
        {
            GameManager.instance.GameOver();
            GameManager.instance.restartObject.SetActive(true);
        }

    }
}
