using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private UISetter ui;
    private bool hasWrench, hasWelderMask;
    public int smallBeams, largeBeams;
    
    public int roomLocation = 1;

    public void SetHasWrench(bool updateBool)
    {
        hasWrench = updateBool;
        if (hasWrench){ ui.ShowToolUI(0); }
    }

    public void SetHasWeldingMask(bool updateBool)
    {
        hasWelderMask = updateBool;
        if (hasWelderMask) { ui.ShowToolUI(1); }
    }

    void Awake() 
    {
        ui = GameObject.Find("Canvas").GetComponent<UISetter>();
    }

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
        ui.UpdateBeamText(true, smallBeams);
    }
    public void RemoveSmallBeam()
    {
        if (smallBeams > 0)
        {
            smallBeams--;
            ui.UpdateBeamText(true, smallBeams);
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
        ui.UpdateBeamText(false, largeBeams);
    }
    public void RemoveLargeBeam()
    {
        if (largeBeams > 0)
        {
            largeBeams--;
            ui.UpdateBeamText(false, largeBeams);
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
