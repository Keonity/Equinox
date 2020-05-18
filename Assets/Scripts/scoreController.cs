using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour
{
    public int score = 0;
    public Text Score;
    private Text scoreText;

    public void UpdateScore()
    {
        Score.text = "Score: " + score;
    }
}
