using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreIncrease : MonoBehaviour
{
    public Text scoreText;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.instance.endGame)
        {

            scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
        }
    }
}
