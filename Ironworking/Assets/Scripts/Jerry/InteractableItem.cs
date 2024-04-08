using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class InteractableItem : MonoBehaviour
{
    public bool isWithinRange, needsWrench, needsWeldingMask, needsSmallBeam, needsLargeBeam, noNeeds;
    public UnityEvent interactionEvent;
    public KeyCode interactKey;
    public GameObject eIcon;
    public PlayerManager playerManager;

    private bool isDebugged = false;

    void Start() {
        if (eIcon != null)
        {
            eIcon.SetActive(false);
        }
        if (needsWeldingMask || needsWrench || needsSmallBeam || needsLargeBeam)
        {
            noNeeds = false;
        }
        else { noNeeds = true; }
    }

    void Update() {
        if (isWithinRange && playerManager != null) {
            if ((needsWrench && playerManager.HasWrench()) || (needsWeldingMask && playerManager.HasWelderMask())) {
                if (Input.GetKeyDown(interactKey)) {
                    interactionEvent.Invoke();
                }
            }
            else if ((needsLargeBeam && playerManager.HasLargeBeam()) || (needsSmallBeam && playerManager.HasSmallBeam()))
            {
                if (Input.GetKeyDown(interactKey))
                {
                    interactionEvent.Invoke();
                }
            }
            else if (noNeeds)
            {
                if (Input.GetKeyDown(interactKey))
                {
                    interactionEvent.Invoke();
                }
            }
            else
            {
                if (!isDebugged)
                {
                    Debug.Log("Missing Tool");
                    isDebugged = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)  {
        if (collision.gameObject.CompareTag("Player")) {
            isWithinRange = true;
            NotifyPlayer();
            Debug.Log("Player Within Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            isWithinRange = false;
            DeNotifyPlayer();
            Debug.Log("Player Is Not Within Range");
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
}
