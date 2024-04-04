using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool hasWrench, hasWelderMask;
    public int roomLocation = 1;

    public void SetHasWrench(bool updateBool) => hasWrench = updateBool;

    public void SetHasWeldingMask(bool updateBool) => hasWelderMask = updateBool;

    public bool HasWelderMask()
    {
        return hasWelderMask;
    }

    public bool HasWrench()
    {
        return hasWrench;
    }

    public int GetCurrentRoomSelection ()
    {
        return roomLocation;
    }

    public void SetRoomLocation(int roomNum)
    {
        roomLocation = roomNum;
    }
}