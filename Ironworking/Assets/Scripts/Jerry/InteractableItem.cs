using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class InteractableItem : MonoBehaviour
{
    public bool isWithinRange, needsWrench, needsWeldingMask, needsSmallBeam, needsLargeBeam, noNeeds;
    public UnityEvent interactionEvent;
    public KeyCode interactKey;
    public KeyCode altInteractKey;
    public GameObject eIcon;
    public GameObject hint;
    public PlayerManager playerManager;


    private bool isDebugged = false;

    void Start() {
        playerManager = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
        if (eIcon != null)
        {
            eIcon.SetActive(false);
        }

        HideHintText();

        if (needsWeldingMask || needsWrench || needsSmallBeam || needsLargeBeam)
        {
            noNeeds = false;
        }
        else { noNeeds = true; }
    }

    void Update() {
        if (isWithinRange && playerManager != null) {
            if ((needsWrench && playerManager.HasWrench()) || (needsWeldingMask && playerManager.HasWelderMask())) {
                if (Input.GetKeyDown(interactKey) || Input.GetKeyDown(altInteractKey)) {
                    interactionEvent.Invoke();
                    if (needsWrench)
                    {
                        playerManager.PlayWrenchSound();
                    }
                    else if (needsWeldingMask)
                    {
                        playerManager.PlayWeldSound();
                    }
                    else 
                    {
                        playerManager.PlayInteractSound();
                    }
                }
            }
            else if ((needsLargeBeam && playerManager.HasLargeBeam()) || (needsSmallBeam && playerManager.HasSmallBeam()))
            {
                if (Input.GetKeyDown(interactKey) || Input.GetKeyDown(altInteractKey))
                {
                    interactionEvent.Invoke();
                }
            }
            else if (noNeeds)
            {
                if (Input.GetKeyDown(interactKey) || Input.GetKeyDown(altInteractKey))
                {
                    interactionEvent.Invoke();
                    playerManager.PlayInteractSound();
                }
            }
            else
            {
                if (!isDebugged)
                {
                    isDebugged = true;
                }
                if (Input.GetKeyDown(interactKey) || Input.GetKeyDown(altInteractKey))
                {
                    ShowHintText();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)  {
        if (collision.gameObject.CompareTag("Player")) {
            isWithinRange = true;
            NotifyPlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            isWithinRange = false;
            DeNotifyPlayer();
            HideHintText();
        }
    }

    public void NotifyPlayer() {
        if (eIcon != null)
        {
            eIcon.SetActive(true);
        }
    }

    public void DeNotifyPlayer() {
        if (eIcon != null)
        {
            eIcon.SetActive(false);
        }
    }

    public void ShowHintText() 
    {
        if (hint != null)
        {
            hint.SetActive(true);
        }
    }

    public void HideHintText()
    {
        if (hint != null)
        {
            hint.SetActive(false);
        }
    }
}
