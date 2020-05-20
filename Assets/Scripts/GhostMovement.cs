using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    private float floatingTimer = 0f;
    public float floatingMax = 2f;
    public float floatingDir = 0.01f;
    public AudioClip ghostClip;

    void Start()
    {
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (floatingTimer < floatingMax)
        {
            this.transform.position = new Vector2(transform.position.x + (Time.fixedDeltaTime * floatingDir),
                transform.position.y);
            floatingTimer += Time.fixedDeltaTime;
        }
        else
        {
            floatingDir *= -1;
            floatingTimer = 0f;
            AudioSource.PlayClipAtPoint(ghostClip, this.transform.position, 0.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            Destroy(collision.gameObject, 1f);
        }
    }
}
