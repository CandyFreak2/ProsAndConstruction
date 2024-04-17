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

    public bool isOnLeftSide, IsOnTop;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector2 playerPos = collision.transform.position;
            Vector2 triggerPos = transform.position;

            bool isPlayerOnXAxisRight = playerPos.x > triggerPos.x;
            bool isPlayerOnYAxisUp = playerPos.y > triggerPos.y;

            if ((isOnLeftSide && !isPlayerOnXAxisRight) || (!isOnLeftSide && isPlayerOnXAxisRight) || (IsOnTop && !isPlayerOnYAxisUp) || (!IsOnTop && isPlayerOnYAxisUp))
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
