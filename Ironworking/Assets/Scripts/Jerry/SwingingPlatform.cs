using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingPlatform : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float moveSpeed, leftAngle, rightAngle;
    bool isMovingClockwise;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        isMovingClockwise = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    public void ChangeMovementDirection()
    {
        if (transform.rotation.z > rightAngle)
        {
            isMovingClockwise = false;
        }
        if (transform.rotation.z < leftAngle)
        {
            isMovingClockwise = true;
        }
    }

    public void MovePlatform()
    {
        ChangeMovementDirection();
        if (isMovingClockwise)
        {
            rigidBody.angularVelocity = moveSpeed;
        } 
        else 
        {
            rigidBody.angularVelocity = -1 * moveSpeed;
        }
    }
}
