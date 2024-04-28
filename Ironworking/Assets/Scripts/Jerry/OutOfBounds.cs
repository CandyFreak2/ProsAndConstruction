using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public PlayerManager playerManager;
    public OutOfBoundsHolder boundsContainer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Fell Through");
            collision.gameObject.transform.position = boundsContainer.GetLevelSpawnAtIndex(playerManager.GetCurrentRoomSelection() - 1);
        }
    }
}