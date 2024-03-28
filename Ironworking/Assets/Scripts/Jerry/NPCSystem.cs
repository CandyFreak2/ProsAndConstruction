using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCSystem : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    public int index;
    public float wordSpeed;
    public bool isPlayerNear;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerNear) {
            if (dialoguePanel.activeInHierarchy) {
                NullifyText();
            } else { 
                dialoguePanel.SetActive(true);
                StartCoroutine(TypeFormat());
            }
        }
    }

    public void NullifyText() {
        dialogueText.text = string.Empty;
        index = 0;
        dialoguePanel.SetActive(false);
    }

    public void GoToNextLine() {
        if (index < dialogue.Length - 1) {
            index++;
            dialogueText.text = "";
            StartCoroutine(TypeFormat());
        } else {
            NullifyText();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && gameObject != null) {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player") && gameObject != null) {
            isPlayerNear = false;
            NullifyText();
        }
    }

    IEnumerator TypeFormat() {
        foreach(char letter in dialogue[index].ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
}
