using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;
    private Vector3 smoothPos;
    private float smoothSpeed = 0.5f;

    public GameObject rightBorder;
    public GameObject leftBorder;

    private float cameraHalfWidth;

    // Start is called before the first frame update
    void Start()
    {
        cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float borderLeft = leftBorder.transform.position.x + cameraHalfWidth;
        float borderRight = rightBorder.transform.position.x - cameraHalfWidth;

        smoothPos = Vector3.Lerp(this.transform.position,
            new Vector3(Mathf.Clamp(followTransform.position.x, borderLeft, borderRight),
            followTransform.position.y,
            this.transform.position.z), smoothSpeed);

        this.transform.position = smoothPos;
    }
}
