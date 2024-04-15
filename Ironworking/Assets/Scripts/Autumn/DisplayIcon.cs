using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayIcon : MonoBehaviour
{
    public GameObject eIcon;
    // Start is called before the first frame update
    void Start()
    {
        if (eIcon != null)
        {
            eIcon.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (eIcon != null)
            {
                eIcon.SetActive(true);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (eIcon != null)
            {
                eIcon.SetActive(false);
            }
        }
    }
}
