using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISetter : MonoBehaviour
{
    Image wrench;
    Image weld;
    GameObject smallBeamCounter;
    GameObject largeBeamCounter;
    [SerializeField] bool wrenchUI = true;
    [SerializeField] bool weldUI = false;
    [SerializeField] bool beamUI = true;

    // Start is called before the first frame update
    void Start()
    {
        //switch to find by name
        if (wrenchUI)
        {
            wrench = this.transform.Find("UIWrench").GetComponent<Image>();
            wrench.color = new Color(wrench.color.r, wrench.color.g, wrench.color.b, 0.0f);
        }

        if (weldUI)
        {
            weld = this.transform.Find("UIWeld").GetComponent<Image>();
            weld.color = new Color(weld.color.r, weld.color.g, weld.color.b, 0.0f);
        }

        if (beamUI)
        {
            smallBeamCounter = this.transform.Find("SmallBeamCounter").gameObject;
            largeBeamCounter = this.transform.Find("LargeBeamCounter").gameObject;
        }
    }

    public void UpdateBeamText(bool isSmall, int numBeams) 
    {
        TMP_Text desc;
        if (isSmall && smallBeamCounter != null)
        {
            desc = smallBeamCounter.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
            desc.text = "x"+numBeams;
        }
        else if (largeBeamCounter != null) 
        {
            desc = largeBeamCounter.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
            desc.text = "x"+numBeams;
        }
    }

    public void ShowToolUI(int tool)
    {
        if (tool == 0)
        {
            wrench.color = new Color(wrench.color.r, wrench.color.g, wrench.color.b, 1.0f);
        }
        else if (tool ==1) 
        {
            weld.color = new Color(weld.color.r, weld.color.g, weld.color.b, 1.0f);
        }
    }
}
