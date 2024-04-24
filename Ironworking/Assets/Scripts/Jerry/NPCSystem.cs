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

    public bool hasFinishedInteraction;

    private bool isTyping, isPlayerNear, canWrite, isFasterWords;
    private const float collegeLevelWordSpeed = 0.02f, collegeLevelDelay = 1.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerNear && dialoguePanel != null && !hasFinishedInteraction)
        {
            if (!dialoguePanel.activeInHierarchy && canWrite)
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(TypeFormat());
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftBracket) && Application.isEditor)
        {
            isFasterWords = !isFasterWords;
        }
    }

    public bool GetHasInteractionFinished()
    {
        return hasFinishedInteraction;
    }


    public void SetHasInteractionFinished(bool interactionUpdate)
    {
        hasFinishedInteraction = interactionUpdate;
    }

    public void NullifyText()
    {
        dialogueText.text = "";
        startingIndex = 0;
        dialoguePanel.SetActive(false);
    }

    public void GoToNextLine()
    {
        if (startingIndex < dialogue.Length - 1)
        {
            startingIndex++;
            dialogueText.text = "";
            StartCoroutine(TypeFormat());
        }
        else
        {
            NullifyText();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && dialoguePanel != null)
        {
            isPlayerNear = true;
            if (dialogueText.text == string.Empty)
            {
                canWrite = true;
            } 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && dialoguePanel != null)
        {
            isPlayerNear = false;
            if (dialogueText.text != string.Empty)
            {
                canWrite = false;
            }
        }
    }

    IEnumerator TypeFormat()
    {
        isTyping = true;
        foreach (char letter in dialogue[startingIndex].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(!isFasterWords ? wordSpeed : collegeLevelWordSpeed);
        }
        isTyping = false;

        yield return new WaitForSeconds(!isFasterWords ? delayBetweenLines : collegeLevelDelay);

        if (!isTyping)
        {
            GoToNextLine();
        }

        if (startingIndex == (dialogue.Length - 1))
        {
            hasFinishedInteraction = true;
            canWrite = false;
        }
    }
}
