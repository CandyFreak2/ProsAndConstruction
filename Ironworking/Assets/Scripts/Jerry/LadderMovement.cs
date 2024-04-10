using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    public float verticalMovement, movementSpeed;
    private bool isOnLadder, isClimbing, pauseClimbing;
    private Rigidbody2D rigidBody;
    private PlayerMovement playerMovement;

    private float startPosY;

    public Animator animator;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        verticalMovement = Input.GetAxis("Vertical");

        if (isOnLadder && Mathf.Abs(verticalMovement) > 0f)
        {
            isClimbing = true;
            pauseClimbing = false;
            playerMovement.SetHorizontalMovement(0f); 
        }
        else
        {
            rigidBody.gravityScale = 4f;
            pauseClimbing = true;
            playerMovement.SetHorizontalMovement(Input.GetAxisRaw("Horizontal"));
        }

        animator.SetBool("IsClimbing", isClimbing);
        if (startPosY >= transform.position.y && startPosY <= transform.position.y + 0.02f)
        {
            animator.SetBool("IsClimbing", false);
            pauseClimbing = false;
        }

        if (pauseClimbing && isClimbing)
        {
            animator.speed = 0f;
        }
        else
        {
            animator.speed = 1f;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rigidBody.gravityScale = 0f;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, verticalMovement * movementSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = true;
            /*startPosY = transform.position.y + 0.02f;*/
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = false;
            isClimbing = false;
            playerMovement.SetHorizontalMovement(Input.GetAxisRaw("Horizontal"));
        }
    }
}
