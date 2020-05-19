using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoseCollector : MonoBehaviour
{
    private Text Score;
    public AudioClip pickupClip;

    void Start()
    {
        Score = GameObject.Find("ScoreText").GetComponent<Text>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        AudioSource.PlayClipAtPoint(pickupClip, transform.position);
        Score.GetComponent<ScoreController>().scoreNum += 1;
        Score.GetComponent<ScoreController>().UpdateScore();
    }
}
