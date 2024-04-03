using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;
    private Vector2 currentPos;
    public Vector3 velocity = Vector3.zero;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, 
            new Vector3(currentPos.x, currentPos.y, transform.position.z), ref velocity, cameraSpeed);
    }

    public void MoveCameraPos(Vector2 roomPos)
    {
        currentPos = roomPos;
    }
}
