using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoseCollector : MonoBehaviour
{
    private Text scoreText;
    public AudioClip pickupClip;

    private void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        AudioSource.PlayClipAtPoint(pickupClip, transform.position);
        scoreText.GetComponent<scoreController>().score += 1;
        scoreText.GetComponent<scoreController>().UpdateScore();
    }
}
