using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    [SerializeField] private Vector2 previousRoom;
    [SerializeField] private Vector2 nextRoom;
    [SerializeField] private CameraMovement cameraController;
    [SerializeField] private PlayerManager playerManager;

    public int previousRoomNumber, nextRoomNumber;

    public bool isOnLeftSide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            float playerX = collision.transform.position.x;
            float triggerX = transform.position.x;

            if ((isOnLeftSide && playerX > triggerX) || (!isOnLeftSide && playerX < triggerX))
            {
                cameraController.MoveCameraPos(nextRoom);
                playerManager.SetRoomLocation(nextRoomNumber);
            }
            else
            {
                cameraController.MoveCameraPos(previousRoom);
                playerManager.SetRoomLocation(previousRoomNumber);
            }
        }
    }
}
