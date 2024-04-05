using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayBeam : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private GameObject child;
    private int childCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        startPosX = this.transform.localPosition.x;
        startPosY = this.transform.localPosition.y;

        childCount = this.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            child = this.transform.GetChild(i).gameObject;
            child.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showBeam() 
    {
        this.transform.localPosition = new Vector3(startPosX, -1.9f, 0);
        for (int i = 0; i < childCount; i++)
        {
            child = this.transform.GetChild(i).gameObject;
            child.SetActive(true);
        }
    }
}
