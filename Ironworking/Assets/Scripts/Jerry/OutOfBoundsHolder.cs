using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsHolder : MonoBehaviour
{
    public GameObject[] levelRespawns;

    public Vector2 GetLevelSpawnAtIndex(int index)
    {
        return levelRespawns[index].transform.position;
    }
}
