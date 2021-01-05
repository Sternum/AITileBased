using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text ScoreText;

    private const string SCORE_TEXT = "Score: ";

    private int Score = 0;

    private void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int score)
    {
        Score += score;
        ScoreText.text = SCORE_TEXT + Score;
    }
}
