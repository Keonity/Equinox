﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public AudioClip jumpClip;

    public float runSpeed = 25f;

    float horizontalMove = 0f;

    bool jumpFlag = false;
    bool jump = false;

    public float teleportTime = 1f;
    bool teleported = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (jumpFlag)
        {
            animator.SetBool("isJumping", true);
            jumpFlag = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (animator.GetBool("isJumping") == false)
            {
                //AudioSource.PlayClipAtPoint(jumpClip, transform.position);
                jump = true;
                animator.SetBool("isJumping", true);
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {

            if (animator.GetBool("Teleport") == false)
            {
                //AudioSource.PlayClipAtPoint(teleportClip, transform.position);
                /*if (teleported)
                {
                    this.transform.position = new Vector3(transform.position.x - 49, transform.position.y + 0.2f, transform.position.z);
                    teleported = false;
                }
                else if (teleported == false)
                {
                    this.transform.position = new Vector3(transform.position.x + 49, transform.position.y + 0.2f, transform.position.z);
                    teleported = true;
                }*/
                StartCoroutine(Teleportation(teleportTime));
                animator.SetTrigger("Teleport");
            }

        }
    }

    IEnumerator Teleportation(float time)
    {
        yield return new WaitForSeconds(time);

        if (teleported)
        {
            this.transform.position = new Vector3(transform.position.x - 49, transform.position.y + 0.2f, transform.position.z);
            teleported = false;
        }
        else if (teleported == false)
        {
            this.transform.position = new Vector3(transform.position.x + 49, transform.position.y + 0.2f, transform.position.z);
            teleported = true;
        }

    }

    public void Death()
    {
        Destroy(this.gameObject, 1f);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Death")
        {
            animator.SetBool("isDead", true);
        }

        else if (LayerMask.LayerToName(collision.gameObject.layer) == "Enemy")
        {
            animator.SetBool("isDead", true);
        }

    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
        jump = false;
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        if (jump)
        {
            jumpFlag = true;
        }
    }
}
