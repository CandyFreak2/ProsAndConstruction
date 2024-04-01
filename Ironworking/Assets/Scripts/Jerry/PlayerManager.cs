using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool hasWrench, hasWelderMask;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
