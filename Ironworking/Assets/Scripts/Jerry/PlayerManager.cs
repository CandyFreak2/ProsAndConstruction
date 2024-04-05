using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool hasWrench, hasWelderMask;
    private int smallBeams, largeBeams;

    // Start is called before the first frame update
    void Start()
    {
        smallBeams = 0;
        largeBeams = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
