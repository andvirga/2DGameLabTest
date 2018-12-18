using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;
    private bool facingRight = true;
    Animator anim;
    AudioSource audioSource;
    public AudioClip footstep;
    public AudioClip jump;
    Rigidbody2D rb;

    // Use this for initialization
    public void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void PlayFootStep()
    {
        Debug.Log("Footstep!");
        audioSource.clip = footstep;
        audioSource.Play();
    }


    public void PlayJump()
    {
        Debug.Log("Player Jumped!");
        audioSource.clip = jump;
        audioSource.Play();
    }

    private void FlipPlayer()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    // Update is called once per frame
    public void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Math.Abs(movement)); //--change the value of 'speed' in the animator object.
        rb.velocity = new Vector2(movement * movementSpeed, 0);

        if ((movement > 0 && !facingRight) || (movement < 0 && facingRight))
        {
            FlipPlayer();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpForce));
            anim.SetTrigger("Jump");
        }
    }
}
