using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMovement;
    private bool isFacingRight = true;

    [SerializeField] public float movementSpeed = 3.5f;
    [SerializeField] private Rigidbody2D rigidBody;

    public Animator animator;

    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        if (horizontalMovement != 0)
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
}
