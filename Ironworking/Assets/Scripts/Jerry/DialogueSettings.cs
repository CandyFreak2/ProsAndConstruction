using UnityEngine;

public class DialogueSettings : MonoBehaviour
{
    public GameObject npcCharacter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && npcCharacter.GetComponent<NPCSystem>().GetHasInteractionFinished())
        {
            NPCSystem[] interactions = npcCharacter.GetComponentsInChildren<NPCSystem>();
            foreach (NPCSystem interaction in interactions)
            {
                interaction.enabled = !interaction.enabled;
                interaction.SetHasInteractionFinished(false);
            }
        }
    }
}
