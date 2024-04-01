using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class InteractableItem : MonoBehaviour
{
    public bool isWithinRange, needsWrench, needsWeldingMask;
    public UnityEvent interactionEvent;
    public KeyCode interactKey;
    public GameObject eIcon;
    public PlayerManager playerManager;

    private bool isDebugged = false;

    void Start() {
        eIcon.SetActive(false);
    }

    void Update() {
        if (isWithinRange && playerManager != null) {
            if ((needsWrench && playerManager.HasWrench()) || (needsWeldingMask && playerManager.HasWelderMask())) {
                if (Input.GetKeyDown(interactKey)) {
                    interactionEvent.Invoke();
                }
            } 
            else { 
                if (!isDebugged) {
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
        eIcon.SetActive(true);
    }

    public void DeNotifyPlayer() {
        eIcon.SetActive(false);
    }
}
