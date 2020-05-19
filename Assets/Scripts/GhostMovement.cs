using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    private float floatingTimer = 0f;
    public float floatingMax = 1f;
    public float floatingDir = 0.01f;
    public AudioClip ghostClip;

    IEnumerator GhostSound(float time)
    {
        yield return new WaitForSeconds(time);
        AudioSource.PlayClipAtPoint(ghostClip, transform.position);
    }

    private void Start()
    {
        GhostSound(1f);
    }

    private void Update()
    {
        GhostSound(25f);
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
