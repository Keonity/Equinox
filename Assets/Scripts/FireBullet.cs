using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject bullet;
    public AudioClip fireClip;
    private float fireTimer = 0f;
    public float fireMax = 1f;

    private void FixedUpdate()
    {
        if (fireTimer < fireMax)
        {
            fireTimer += Time.fixedDeltaTime;
        }
        else
        {
            Instantiate(bullet, new Vector3(transform.position.x - 0.2f, transform.position.y + 0.1f, transform.position.z), transform.rotation);
            AudioSource.PlayClipAtPoint(fireClip, transform.position, 0.5f);
            fireTimer = 0f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
