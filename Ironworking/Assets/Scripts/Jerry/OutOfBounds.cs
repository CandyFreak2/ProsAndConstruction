using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public PlayerManager playerManager;
    public GameObject[] levelRespawns;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Fell Through");
            collision.gameObject.transform.position = levelRespawns[playerManager.GetCurrentRoomSelection() - 1].transform.position;
        }
    }
}
