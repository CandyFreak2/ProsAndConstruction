using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayText : MonoBehaviour
{
    [SerializeField]private TMP_Text desc;
    private Image popupTool;

    // Start is called before the first frame update
    void Start()
    {
        desc = this.transform.GetChild(0).gameObject.GetComponent<TMP_Text>(); 
        desc.enabled = false;
        popupTool = this.GetComponent<Image>();
    }

    public void showText() 
    {
        if (popupTool.color.a > 0f)
        {
            desc.enabled = true;
        }
    }
    public void hideText()
    {
        desc.enabled = false;
    }
}
