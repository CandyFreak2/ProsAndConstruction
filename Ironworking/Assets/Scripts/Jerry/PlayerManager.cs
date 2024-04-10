using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool hasWrench, hasWelderMask;
    public int smallBeams, largeBeams;
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

    public int GetCurrentRoomSelection()
    {
        return roomLocation;
    }

    public void SetRoomLocation(int roomNum)
    {
        roomLocation = roomNum;
    }

public void AddSmallBeam()
    {
        smallBeams++;
        Debug.Log("Beam Count: " + smallBeams);
    }
    public void RemoveSmallBeam()
    {
        if (smallBeams > 0)
        {
            smallBeams--;
        }
    }

    public int SmallBeamCount()
    {
        return smallBeams;
    }

    public bool HasSmallBeam() 
    {
        return (smallBeams > 0);
    }

    public void AddLargeBeam()
    {
        largeBeams++;
    }
    public void RemoveLargeBeam()
    {
        if (largeBeams > 0)
        {
            largeBeams--;
        }
    }

    public int LargeBeamCount()
    {
        return largeBeams;
    }

    public bool HasLargeBeam()
    {
        return (largeBeams > 0);
    }
}
