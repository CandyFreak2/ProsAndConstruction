using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMovement;
    private bool isFacingRight = true;

    [SerializeField] public float movementSpeed = 3.5f;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform groundPos;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        Flip();
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(horizontalMovement * movementSpeed, rigidBody.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontalMovement < 0f || !isFacingRight && horizontalMovement > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
