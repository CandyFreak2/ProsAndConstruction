using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class InteractableItem : MonoBehaviour
{
    public bool isWithinRange, needsWrench, needsWeldingMask;
    public UnityEvent interactionEvent;
    public KeyCode interactKey;
    public GameObject eIcon;

    private PlayerManager playerManager;

    void Start()
    {
        eIcon.SetActive(false);
    }

    void Update()
    {
        if (isWithinRange && (needsWrench || needsWeldingMask))
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactionEvent.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isWithinRange = true;
            NotifyPlayer();
            Debug.Log("Player Within Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isWithinRange = false;
            DeNotifyPlayer();
            Debug.Log("Player Is Not Within Range");
        }
    }

    public void NotifyPlayer()
    {
        eIcon.SetActive(true);
    }

    public void DeNotifyPlayer()
    {
        eIcon.SetActive(false);
    }
}
