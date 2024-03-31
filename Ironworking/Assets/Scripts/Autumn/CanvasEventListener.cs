using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasEventListener : MonoBehaviour
{
    Image wrench;
    Image weld;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.onObjectPickup += OnObjectPickup;
        wrench = this.transform.GetChild(0).gameObject.GetComponent<Image>();
        wrench.color = new Color(139f / 255, 150f / 255, 255f / 255, 0f);

        weld = this.transform.GetChild(1).gameObject.GetComponent<Image>();
        weld.color = new Color(255f / 255, 125f / 255, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnObjectPickup(int id) 
    {
        if (id == 0)
        {
            wrench.color = new Color(139f / 255, 150f / 255, 255f / 255, 1f);
        }
        if (id == 1)
        {
            weld.color = new Color(255f / 255, 125f / 255, 0f, 1f);
        }
    }

   /* void OnDisable() 
    {
        GameEvents.instance.onObjectPickup -= OnObjectPickup;
    }*/
}


/*https://www.youtube.com/watch?v=be4gDI8RZ2U*/