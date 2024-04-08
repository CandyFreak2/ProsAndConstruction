using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCSystem : MonoBehaviour
{
    [Header("Dialogue Necessary")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    public int startingIndex;

    [Header("Event Speeds In Seconds")]
    public float wordSpeed;
    public float delayBetweenLines;

    private bool isTyping, isPlayerNear;
    private bool isFacingRight = true;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerNear && dialoguePanel != null) {
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
        startingIndex = 0;
        dialoguePanel.SetActive(false);
    }

    public void GoToNextLine() {
        if (startingIndex < dialogue.Length - 1) {
            startingIndex++;
            dialogueText.text = "";
            StartCoroutine(TypeFormat());
        } else {
            NullifyText();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && gameObject != null) {
            isPlayerNear = true;
            if ((collision.gameObject.GetComponent<Rigidbody2D>().transform.position.x < transform.position.x && isFacingRight) 
                || (collision.gameObject.GetComponent<Rigidbody2D>().transform.position.x > transform.position.x && !isFacingRight))
            {
                Flip();
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player") && gameObject != null) {
            isPlayerNear = false;
            NullifyText();
        }
    }

    IEnumerator TypeFormat() {
        isTyping = true;
        foreach(char letter in dialogue[startingIndex].ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        isTyping = false;

        yield return new WaitForSeconds(delayBetweenLines);

        if (!isTyping)
        {
            GoToNextLine();
        }
    }

    private void Flip()
    {
        if (isFacingRight || !isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
