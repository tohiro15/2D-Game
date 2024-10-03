using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Attributes")]
    private float playerSpeed = 5f;
    private float jumpForce = 5f;

    [Header("Components")]
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator animator;

    [Header("Boolean values")]
    private bool isRunning;
    public bool isLeft;
    private bool doubleJump = false;

    private void Update()
    {
        Movement();
        Jump();
    }

    public void Movement()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * playerSpeed * Time.deltaTime;

        if (movement == 0)
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;
        }

        if (isRunning) animator.SetBool("run", true);
        else animator.SetBool("run", false);


        if (Input.GetAxis("Horizontal") > 0)
        {
            isLeft = false;
            sr.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            isLeft = true;
            sr.flipX = true;
        }
        
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(Mathf.Abs(rb.velocity.y) < 0.05f || doubleJump)
            {
                //animator.SetBool("jumping", true);
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                SoundManager.instance.playerChanell.PlayOneShot(SoundManager.instance.jumpSound);

                doubleJump = !doubleJump;
            }
        }

        else if (Mathf.Abs(rb.velocity.y) == 0f)
        {
            //animator.SetBool("jumping", false);

            doubleJump = false;
        }

    }
}
