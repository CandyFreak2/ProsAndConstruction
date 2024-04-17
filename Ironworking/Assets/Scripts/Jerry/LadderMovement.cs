using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    public float verticalMovement, movementSpeed;
    private bool isOnLadder, isClimbing, pauseClimbing;
    private Rigidbody2D rigidBody;
    private PlayerMovement playerMovement;

    public Animator animator;

    [SerializeField] private int collisionCounter = 0;
    [SerializeField] private bool goBackToGround = false;

    private float beamMaxY, beamMinY;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        verticalMovement = Input.GetAxis("Vertical");

        if (goBackToGround) 
        {
            rigidBody.gravityScale = 4f;
            pauseClimbing = true;
            isClimbing = false;
            playerMovement.SetHorizontalMovement(Input.GetAxisRaw("Horizontal"));
            if (GetIsAtBottom()) 
            {
                goBackToGround = false;
            }
        }
        else if (isOnLadder && Mathf.Abs(verticalMovement) > 0f)
        {
            isClimbing = true;
            pauseClimbing = false;
            playerMovement.SetHorizontalMovement(0f);
        }
        else if (isOnLadder) 
        {
            rigidBody.gravityScale = 0f;
            pauseClimbing = true;
        }
        else
        {
            rigidBody.gravityScale = 4f;
            pauseClimbing = true;
            playerMovement.SetHorizontalMovement(Input.GetAxisRaw("Horizontal"));
        }

        animator.SetBool("IsClimbing", isClimbing);
        if (GetIsAtBottom() || GetIsAtTop())
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
        if (isClimbing && !goBackToGround)
        {
            rigidBody.gravityScale = 0f;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, verticalMovement * movementSpeed);
        }
        else if(isOnLadder && !goBackToGround)
        {
            Debug.Log("ladder changed velocity");
            rigidBody.gravityScale = 0f;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = true;
            if ((collision.bounds.max.y == beamMaxY && beamMinY == collision.bounds.min.y) || collision.bounds.max.y <= GetComponent<Collider2D>().bounds.min.y + 0.25f)
            {
                goBackToGround = false;
            }
            beamMaxY = collision.bounds.max.y;
            beamMinY = collision.bounds.min.y;
            if (GetComponent<Collider2D>().bounds.center.y > beamMinY && GetComponent<Collider2D>().bounds.center.y < beamMaxY) 
            {
                isClimbing = true;
            }
            collisionCounter++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            if (collisionCounter > 0)//really this is counter - 1 >= 0
            {
                collisionCounter--;
            }

            goBackToGround = true;
            isOnLadder = false;
            isClimbing = false;
            playerMovement.SetHorizontalMovement(Input.GetAxisRaw("Horizontal"));

            if (collisionCounter > 0)
            {
                isOnLadder = true;
            }
        }
    }

    public bool GetIsPlayerClimbing()
    {
        return isClimbing;
    }

    public bool GetIsClimbPaused()
    {
        return isOnLadder;
    }

    public bool GetIsAtBottom()
    {
        return beamMinY >= GetComponent<Collider2D>().bounds.min.y - 0.12f;
    }

    public bool GetIsAtTop()
    {
        return beamMaxY <= GetComponent<Collider2D>().bounds.min.y + 0.05f;
    }
}