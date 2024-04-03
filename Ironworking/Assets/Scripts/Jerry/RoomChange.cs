using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    [SerializeField] private Vector2 previousRoom;
    [SerializeField] private Vector2 nextRoom;
    [SerializeField] private CameraMovement cameraController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.transform.position.x < transform.position.x)
                cameraController.MoveCameraPos(nextRoom);
            else
                cameraController.MoveCameraPos(previousRoom);
        }
    }
}
