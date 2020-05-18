using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float bulletSpeed = 1f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
        {
            Destroy(collision.gameObject, 1f);
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        this.transform.position = new Vector2(transform.position.x - (bulletSpeed * Time.fixedDeltaTime),
            transform.position.y);  
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x < 10.8)
        {
            Destroy(this.gameObject);
        }
        
    }
}
