using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalMovement;
    public bool isFacingRight = true, isOnGround = false;
    public Animator animator;

    [SerializeField] public float movementSpeed = 3.5f;
    [SerializeField] public float ladderMovement = 1.5f;
    [SerializeField] private Rigidbody2D rigidBody;


    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        if (Mathf.Abs(horizontalMovement) > 0f && (!IsClimbingLadder() || IsClimbingPaused()))
        {
            Flip(horizontalMovement > 0);
        }
    }

    private void FixedUpdate()
    {
        if (!IsClimbingLadder() || IsAtBottom())
        {
            rigidBody.velocity = new Vector2(horizontalMovement * movementSpeed, rigidBody.velocity.y);
        }
        else if (IsClimbingLadder()/* && !isOnGround*/)
        {
            rigidBody.velocity = new Vector2(horizontalMovement * ladderMovement, rigidBody.velocity.y);
        }
    }

    private void Flip(bool isFacingRight)
    {
        if (this.isFacingRight != isFacingRight)
        {
            this.isFacingRight = isFacingRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    public void SetHorizontalMovement(float movement)
    {
        horizontalMovement = movement;
    }

    private bool IsClimbingLadder()
    {
        return GetComponent<LadderMovement>() != null && GetComponent<LadderMovement>().GetIsPlayerClimbing();
    }
    private bool IsClimbingPaused()
    {
        return GetComponent<LadderMovement>() != null && GetComponent<LadderMovement>().GetIsClimbPaused();
    }
    
    private bool IsAtBottom()
    {
        return GetComponent<LadderMovement>() != null && GetComponent<LadderMovement>().GetIsAtBottom();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}