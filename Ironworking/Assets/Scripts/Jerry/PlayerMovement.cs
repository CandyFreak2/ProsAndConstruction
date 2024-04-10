using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalMovement;
    public bool isFacingRight = true;

    [SerializeField] public float movementSpeed = 3.5f;
    [SerializeField] private Rigidbody2D rigidBody;

    public Animator animator;

    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        if (Mathf.Abs(horizontalMovement) > 0f)
        {
            Flip(horizontalMovement > 0);
        }
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(horizontalMovement * movementSpeed, rigidBody.velocity.y);
    }

    private void Flip(bool isFacingRight)
    {
        if (this.isFacingRight != isFacingRight)
        {
            this.isFacingRight = isFacingRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    // Set horizontal movement directly
    public void SetHorizontalMovement(float movement)
    {
        horizontalMovement = movement;
    }
}