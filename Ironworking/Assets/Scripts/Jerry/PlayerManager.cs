using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool hasWrench, hasWelderMask, hasBeam;
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

    /*public void SetHasBeam(bool updateBool) => hasBeam = updateBool;

    public bool HasBeam()
    {
        return hasBeam;
    }*/

    public bool HasWelderMask()
    {
        return hasWelderMask;
    }

    public bool HasWrench()
    {
        return hasWrench;
    }
}
