using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int scoreNum = 0;
    public Text Score;

    private void Start()
    {
    }

    public void UpdateScore()
    {
        Score.text = "Score: " + scoreNum;
    }
}
