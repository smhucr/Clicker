using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextAnimate : MonoBehaviour
{
    public Text rainbowText;
    public static Color indigo = new Color(0.294f, 0f, 0.509f);
    public static Color orange = new Color(1f, 0.647f, 0f);
    public static Color violet = new Color(0.933f, 0.510f, 0.933f);

    public Color[] rainbowColors = {
    //Color.red,
    orange,
    Color.yellow,
    Color.green,
    Color.blue,
    indigo,
    violet,
    Color.red
    };
    private void Start()
    {
        Sequence rainbowSequence = DOTween.Sequence();

        foreach (Color color in rainbowColors)
        {
            rainbowSequence.Append(rainbowText.DOColor(color, 1.5f).SetEase(Ease.Linear)).WaitForCompletion();

        }

        rainbowSequence.SetLoops(-1);
    }

}
